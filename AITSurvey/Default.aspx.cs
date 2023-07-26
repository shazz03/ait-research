using AITSurvey.Core;
using AITSurvey.Core.Implementation;
using System;
using System.Net.NetworkInformation;
using System.Web.UI;

namespace AITSurvey
{
    public partial class _Default : Page
    {
        private RespondentService _respondentService;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearSession();
            _respondentService = new RespondentService();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var surveyId = 2;
            Session[$"Questions-{surveyId}"] = null;
            Session["SurveyId"] = surveyId;
            try
            {
                // Create a new Respondent object with the input values
                var respondent = new Respondent
                {
                    DateCreated = DateTime.Now,
                    MacAddress = GetMacAddress(),
                };

                // Call the Create method of RespondentService to save the respondent in the database
                var respondentId = _respondentService.Create(surveyId, respondent);

                // Save the respondent ID in the Session object
                Session["RespondentId"] = respondentId;

            }
            catch (Exception ex)
            {
                //
            }
            Response.Redirect($"~/Questions");
        }

        private string GetMacAddress() 
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Check if the network interface has a valid MAC address and is not a loopback or virtual interface
                if (networkInterface.GetPhysicalAddress().ToString() != "" && !networkInterface.Name.ToLower().Contains("loopback") && !networkInterface.Name.ToLower().Contains("virtual"))
                {
                    return networkInterface.GetPhysicalAddress().ToString();
                }
            }
            return string.Empty;
        }

        private void ClearSession()
        {
            int.TryParse(Session["SurveyId"]?.ToString(), out var surveyId);
            Session[$"Answer_{surveyId}"] = null;
            Session["SurveyId"] = null;
            Session[$"Questions-{surveyId}"] = null;
        }
    }
}