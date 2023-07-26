using AITResearch.Core.Implementation;
using AITResearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace AITResearch
{
    public partial class Review : System.Web.UI.Page
    {
        private readonly AnswerService _answerService;
        private int _surveyId;

        public Review()
        {
            _answerService = new AnswerService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(Session["SurveyId"]?.ToString(), out _surveyId);
                if (!IsPostBack)
                {
                    DisplayAnswers();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message to the user
                lblMessage.Text = "An error occurred: " + ex.Message;
                btnBack.Visible = false;
                btnSubmit.Visible = false;
            }
        }

        // This method is responsible for displaying the answers on the page
        private void DisplayAnswers()
        {
            try
            {
                var answers = (List<Answer>)Session[$"Answer_{_surveyId}"];
                if (answers?.Count == null)
                {
                    // If there are no answers in the session, display an error message and hide the navigation buttons
                    lblMessage.Text = "No Answer selected, please go back to select answers.";
                    btnBack.Visible = false;
                    btnSubmit.Visible = false;
                    return;
                }

                // Loop through all the answers and display each question and its selected options
                foreach (var ans in answers)
                {
                    pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("h5")
                    {
                        InnerText = ans.Question.Description
                    });

                    foreach (var opt in ans.SelectedOptions)
                    {
                        pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("h6")
                        {
                            InnerText = opt.Description,
                        });
                    }
                    pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("br"));
                    pnlQuestionAnswer.Controls.Add(new HtmlGenericControl("hr"));
                }
            }
            catch (Exception ex)
            {
                // If there is an exception, display an error message and hide the navigation buttons
                lblMessage.Text = "An error occurred: " + ex.Message;
                btnBack.Visible = false;
                btnSubmit.Visible = false;
            }
        }

        // This method is called when the Submit button is clicked
        protected void btnSubmit_Click(Object sender, EventArgs e)
        {
            try
            {
                var answers = (List<Answer>)Session[$"Answer_{_surveyId}"];

                // Insert each answer into the database using the AnswerService
                _answerService.InsertAnswers(answers);

                // Redirect the user to the thank you page after submitting the answers
                Response.Redirect(chkRegister.Checked? "~/RespondentProfile":"~/thankyou" );
            }
            catch (Exception ex)
            {
                // If there is an exception, display an error message and hide the navigation buttons
                lblMessage.Text = "An error occurred: " + ex.Message;
                btnBack.Visible = false;
                btnSubmit.Visible = false;
            }
        }

        // This method is called when the Exit button is clicked
        protected void btnExit_Click(Object sender, EventArgs e)
        {
            try
            {
                // Clear the session variables and redirect the user to the default page
                Session[$"Answer_{_surveyId}"] = null;
                Session["SurveyId"] = null;
                Session[$"Questions-{_surveyId}"] = null;
                Response.Redirect("~/default");
            }
            catch (Exception ex)
            {
                // If there is an exception, display an error message and hide the navigation buttons
                lblMessage.Text = "An error occurred: " + ex.Message;
                btnBack.Visible = false;
                btnSubmit.Visible = false;
            }
        }

    }
}
