using AITSurvey.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AITSurvey
{
    public partial class Thankyou : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ClearSession();
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