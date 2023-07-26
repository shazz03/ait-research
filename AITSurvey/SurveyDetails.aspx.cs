using AITSurvey.Core.Implementation;
using AITSurvey.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;

namespace AITSurvey
{
    public partial class SurveyDetails : System.Web.UI.Page
    {
        private readonly AnswerService _answerService;
        private int _surveyId;
        private int _respodentId;

        public SurveyDetails()
        {
            _answerService = new AnswerService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(Request.QueryString["surveyId"]?.ToString(), out _surveyId);
                int.TryParse(Request.QueryString["respondentId"]?.ToString(), out _respodentId);
                if (!IsPostBack)
                {
                    DisplayDetails();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message to the user
                lblMessage.Text = "An error occurred: " + ex.Message;
                btnBack.Visible = false;
            }
        }

        // This method is responsible for displaying the answers on the page
        private void DisplayDetails()
        {
            try
            {
                var answers = _answerService.GetAnswerView(_respodentId, _surveyId);
                if (answers?.Count == null)
                {
                    // If there are no answers in the session, display an error message and hide the navigation buttons
                    lblMessage.Text = "No record found";
                    return;
                }

                // Loop through all the answers and display each question and its selected options
                // Group the answers by their question text
                var answerGroups = answers.GroupBy(ans => ans.QuestionText);

                // Loop through each group of answers
                foreach (var answerGroup in answerGroups)
                {
                    // Add the question as a heading
                    pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("h5")
                    {
                        InnerText = answerGroup.Key // The question text is the key for this group
                    });

                    // Loop through each answer in this group and add it as a subheading
                    foreach (var ans in answerGroup)
                    {
                        pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("h6")
                        {
                            InnerText = ans.AnswerText
                        });
                    }

                    // Add a horizontal rule after the answers for this question
                    pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("hr"));
                }

            }
            catch (Exception ex)
            {
                // If there is an exception, display an error message and hide the navigation buttons
                lblMessage.Text = "An error occurred: " + ex.Message;
                btnBack.Visible = false;
            }
        }
    }
}
