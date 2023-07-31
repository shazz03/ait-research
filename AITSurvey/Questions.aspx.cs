using AITResearch.Core;
using AITResearch.Core.Implementation;
using AITResearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace AITResearch
{
    public partial class Questions : System.Web.UI.Page
    {
        private static Question _currentQuestion;
        private readonly QuestionService _questionAnswerService;
        private readonly OptionService _optionService;

        public Questions()
        {
            _questionAnswerService = new QuestionService();
            _optionService = new OptionService();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                int.TryParse(Request.QueryString["questionId"]?.ToString(), out var questionId);
                DisplayQuestion(questionId);
            }
            DisplayOptions();
        }

        // This method displays the question with the given question ID
        private void DisplayQuestion(int questionId)
        {
            // Try to parse the SurveyId from the Session
            int.TryParse(Session["SurveyId"]?.ToString(), out var surveyId);

            // If the SurveyId is not found in the Session, show an error message and hide buttons
            if (surveyId == 0)
            {
                lblTitle.Text = "Invalid Survey Id.";
                btnSkip.Visible = false;
                btnSubmit.Visible = false;
                return;
            }

            // Load the questions for the given surveyId
            var questions = LoadQuestions(surveyId);

            // Get the current question and display its description
            _currentQuestion = _questionAnswerService.GetCurrentQuestion(questionId, questions);
            if (questionId == 0)
            {
                Response.Redirect($"~/questions?questionId={_currentQuestion.Id}");
            }
            lblTitle.Text = _currentQuestion.Description;

            // Display appropriate buttons based on current question
            DisplayActions(questions);
        }

        // This method displays appropriate buttons based on the current question
        private void DisplayActions(List<Question> questions)
        {
            // Hide the Back button if the current question is the first question
            if (_questionAnswerService.IsFirstQuestion(_currentQuestion, questions))
            {
                btnBack.Visible = false;
            }

            // Change the text of the Submit button to "Review & Submit" if the current question is the last question
            if (_questionAnswerService.IsLastQuestion(_currentQuestion, questions))
            {
                btnSubmit.Text = "Review & Submit";
            }

            //hide skip button if the question is mandatory in this case consumer will have to select option instead of skipping the whole question
            if (_currentQuestion.IsMandatory)
            {
                btnSkip.Visible = false;
            }
        }

        // This method loads the questions for the given surveyId from the Session or the database
        public List<Question> LoadQuestions(int surveyId)
        {
            // Try to get the questions from the Session
            var questions = (List<Question>)Session[$"Questions-{surveyId}"];
            if (questions != null)
                return questions;

            // If questions are not found in the Session, load them from the database and store in Session
            questions = _questionAnswerService.LoadQuestions(surveyId);
            Session[$"Questions-{surveyId}"] = questions;
            return questions;
        }

        // This method displays the options for the current question
        private void DisplayOptions()
        {
            // Load the options for the current question
            var options = _optionService.LoadOptions(_currentQuestion.Id);

            // Convert the options to ListItems
            var listItem = (from option in options
                            select new ListItem { Text = option.Description, Value = option.Id.ToString() }).ToList();

            // Render the options as RadioButtons if the current question is of type SingleChoice
            if (_currentQuestion.Type.TypeName == TypeOptions.SingleChoice)
            {
                RenderRadioOptions(listItem);
            }
            // Render the options as CheckBoxes if the current question is of type MultipleChoice
            else if (_currentQuestion.Type.TypeName == TypeOptions.MultipleChoice)
            {
                RenderCheckboxOptions(listItem);
            }
            else if (_currentQuestion.Type.TypeName == TypeOptions.Text)
            {
                RenderInputTextOption();
            }
        }

        // This method renders the options as a RadioButtonList
        private void RenderInputTextOption()
        {
            var textBox = new TextBox
            {
                ID = "txtData",
                CssClass = "form-control form-control-lg",
               
            };

            if(_currentQuestion.ValidationGroup != null) {
                textBox.TextMode = (TextBoxMode)Enum.Parse(typeof(TextBoxMode), _currentQuestion.ValidationGroup.ValidationType);
            }

            pnlOptions.Controls.Add(textBox);
        }



        // This method renders the options as a RadioButtonList
        private void RenderRadioOptions(List<ListItem> listItems)
        {
            var radioList = new RadioButtonList
            {
                ID = "rdbList",
                CssClass = "form-control form-check-input-custom"
            };
            radioList.Items.AddRange(listItems.ToArray());

            pnlOptions.Controls.Add(radioList);
        }

        // This method renders the options as a CheckBoxList
        private void RenderCheckboxOptions(List<ListItem> listItems)
        {
            var checkBoxList = new CheckBoxList
            {
                ID = "checkBoxList",
                CssClass = "form-control form-check-input-custom"
            };
            checkBoxList.Items.AddRange(listItems.ToArray());

            pnlOptions.Controls.Add(checkBoxList);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PerformButtonAction(false);
        }
        protected void btnSkip_Click(object sender, EventArgs e)
        {
            PerformButtonAction(true);
        }

        private void PerformButtonAction(bool isSkipped)
        {
            // Get the list of questions from session
            var questions = (List<Question>)Session[$"Questions-{_currentQuestion.Survey.Id}"];

            // Get the respondent ID from session
            int.TryParse(Session["RespondentId"]?.ToString(), out int respondentId);

            // Get the selected options
            var selectedOption = GetSelectedOption();
            if (selectedOption == null && !isSkipped)
            {
                return;
            }

            if (isSkipped)
            {
                selectedOption = null;
            }

            // Manage the answer session
            ManageAnswerSession(respondentId, selectedOption, isSkipped);

            // Move to the next question
            Next(questions, selectedOption, isSkipped);
        }


        private void ManageAnswerSession(int respondentId, List<Option> selectedOption, bool isSkipped)
        {
            // If no option is selected, return
            if (selectedOption?.Count == 0)
                return;

            // Get the list of answers from session or create a new list if none exists
            var answers = (List<Answer>)Session[$"Answer_{_currentQuestion.Survey.Id}"] ?? new List<Answer>();

            // Create a new answer object
            var currentAnswer = new Answer { DateCreated = DateTime.Now, Question = _currentQuestion, Survey = _currentQuestion.Survey, SelectedOptions = selectedOption, RespondentId = respondentId };

            // Check if an answer for the current question already exists, and remove it if it does
            var existingAnswer = answers.Where(a => a.Question.Id == _currentQuestion.Id)?.FirstOrDefault();
            if (existingAnswer != null)
            {
                answers.Remove(existingAnswer);
            }

            // Add the current answer to the answer list, unless the question was skipped
            if (!isSkipped)
            {
                answers.Add(currentAnswer);
            }

            // Store the updated answer list in session
            Session[$"Answer_{_currentQuestion.Survey.Id}"] = answers;
        }

        private List<Option> GetSelectedOption()
        {
            // Create a new list to hold the selected options
            var selectedOption = new List<Option>();
            var messageText = "";
            // If the current question is a single-choice question, get the selected radio button
            if (_currentQuestion.Type.TypeName == TypeOptions.SingleChoice)
            {
                messageText = OptionSelectionRadio(selectedOption);
            }
            // If the current question is a multiple-choice question, get the selected checkboxes
            else if (_currentQuestion.Type.TypeName == TypeOptions.MultipleChoice)
            {
                messageText = OptionSelectionCheckbox(selectedOption);
            }
            else if (_currentQuestion.Type.TypeName == TypeOptions.Text)
            {
                messageText = OptionInputText(selectedOption);
            }
            if (!string.IsNullOrWhiteSpace(messageText))
            {
                lblMessage.Text = messageText;
                return null;
            }
            // Return the list of selected options
            return selectedOption;
        }

        private void Next(List<Question> questions, List<Option> selectedOption, bool isSkipped)
        {
            // Get the next question in the survey
            var next = _questionAnswerService.NextQuestion(questions, selectedOption, _currentQuestion, isSkipped);

            // If the current question is the last question in the survey, redirect to the review page
            if (next == null || _questionAnswerService.IsLastQuestion(_currentQuestion, questions))
            {
                Session[$"Questions-{_currentQuestion.Survey.Id}"] = null;
                Response.Redirect($"~/Review");
            }
            // Otherwise, redirect to the next question
            else
            {
                Response.Redirect($"~/Questions?questionId={next.Id}");
            }
        }

        private string OptionSelectionRadio(List<Option> selectedOption)
        {
            // Find the radio button list control in the panel
            var radioControl = (RadioButtonList)pnlOptions.FindControl("rdbList");
            // If no option is selected, show error message and return
            if (radioControl.SelectedIndex == -1)
            {
                return "Please select at least 1 option.";
            }
            // If radio button list control is found
            if (radioControl != null)
            {
                // Add the selected option to the list
                selectedOption.Add(new Option { Id = int.Parse(radioControl.SelectedValue), QuestionId = _currentQuestion.Id, Description = radioControl.SelectedItem.Text });
            }
            // If no option is selected
            if (selectedOption.Count == 0)
            {
                return "Please select at least 1 option.";
            }

            return string.Empty;
        }

        private string OptionSelectionCheckbox(List<Option> selectedOption)
        {
            // Find the checkbox list control in the panel
            var checkBoxControl = (CheckBoxList)pnlOptions.FindControl("checkBoxList");
            // Loop through each item in the checkbox list control
            foreach (ListItem lst in checkBoxControl.Items)
            {
                // If an item is selected
                if (lst.Selected == true)
                {
                    // Add the selected option to the list
                    selectedOption.Add(new Option { Id = int.Parse(lst.Value), QuestionId = _currentQuestion.Id, Description = lst.Text });
                }
            }
            // If the number of selected options is less than the minimum required
            if (selectedOption.Count < _currentQuestion.MinOptionSelection)
            {
                return $"Please select atleast {_currentQuestion.MinOptionSelection} option.";
            }
            return string.Empty;
        }

        private string OptionInputText(List<Option> selectedOption)
        {
            // Find the checkbox list control in the panel
            var txtBoxControl = (TextBox)pnlOptions.FindControl("txtData");
            // Loop through each item in the checkbox list control

            if (string.IsNullOrWhiteSpace(txtBoxControl.Text))
            {
                return $"{_currentQuestion.Title} should not be empty.";
            }

            // Add the selected option to the list
            selectedOption.Add(new Option { QuestionId = _currentQuestion.Id, Description = txtBoxControl.Text });

            return string.Empty;
        }

    }
}