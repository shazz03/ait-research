using AITResearch.Core;
using AITResearch.Core.Implementation;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace AITResearch
{
    public partial class StaffLogin : Page
    {
        private readonly StaffService _staffService;
        public StaffLogin()
        {
            _staffService = new StaffService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(Object sender, EventArgs e)
        {
            try
            {
                // Clear the user session and message label
                lblMessage.Text = "";

                // Attempt to log in the user using the StaffService Login method
                var staffId = _staffService.Login(txtUserName.Text, txtPassword.Text);
                Session["StaffId"] = staffId.ToString();
            }
            catch (Exception)
            {
                // If an exception is thrown, clear the input fields and display the error message in the label
                txtPassword.Text = "";
                txtUserName.Text = "";
                lblMessage.Text = "Please enter valid Username or Password.";
                return;
            }

            // If the login is successful, redirect to the RespondentSearch page
            Response.Redirect($"~/RespondentSearch");
        }
    }
}