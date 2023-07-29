using AITResearch.Core.Implementation;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITResearch
{
    public partial class RespondentProfile : Page
    {
        private readonly SelectListItemService _selectListItemService;
        private readonly RespondentService _respondentService;

        public RespondentProfile()
        {
            _selectListItemService = new SelectListItemService();
            _respondentService = new RespondentService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the survey and respondent IDs from session state
                int.TryParse(Session["SurveyId"]?.ToString(), out var surveyId);
                var respondentId = int.Parse(Session["RespondentId"].ToString());

                // Create a new respondent profile object with the data from the form fields 1300225464
                var profile = new Core.Models.RespondentProfile
                {
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Parse(txtBirthdayDate.Text),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    ContactNumber = txtContactNumber.Text,
                };

                // Call the respondent service to create the profile
                _respondentService.CreateProfile(respondentId, profile);

                // Redirect the user to the respondent address page
                Response.Redirect($"~/Thankyou");
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            // Redirect the user to the respondent address page if they choose to skip the profile creation
            Response.Redirect($"~/RespondentAddress");
        }

    }
}