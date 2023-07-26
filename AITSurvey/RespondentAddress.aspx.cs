using AITResearch.Core.Implementation;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITResearch
{
    public partial class RespondentAddress : Page
    {
        // Create an instance of SelectListItemService and RespondentService classes to use their methods.
        private readonly SelectListItemService _selectListItemService;
        private readonly RespondentService _respondentService;

        public RespondentAddress()
        {
            _selectListItemService = new SelectListItemService();
            _respondentService = new RespondentService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the page is not a postback and load the state and address type dropdowns.
            if (!IsPostBack)
            {
                LoadState();
                LoadAddressType();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the respondent ID from the session.
                int respondentId = int.Parse(Session["RespondentId"].ToString());

                // Create a new address object with the entered data.
                var address = new Core.Models.Address
                {
                    DateCreated = DateTime.Now,
                    Postcode = txtPostcode.Text,
                    State = new Core.Models.State
                    {
                        Id = int.Parse(ddlState.SelectedValue)
                    },
                    Suburb = txtSuburb.Text,
                    AddressType = new Core.Models.AddressType
                    {
                        AddressTypeId = int.Parse(ddlAddressType.SelectedValue)
                    }
                };

                // Call the CreateAddress method to add the new address record to the database.
                _respondentService.CreateAddress(respondentId, address);

                // Redirect to the Questions page.
                Response.Redirect($"~/thankyou");
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            // Redirect to the Questions page.
            Response.Redirect($"~/thankyou");
        }

        private void LoadAddressType()
        {
            try
            {
                // Load the address type dropdown values using the SelectListItemService class.
                var list = (from s in _selectListItemService.LoadAddressType()
                            select new ListItem { Text = s.Text, Value = s.Value }).ToArray();
                if (list != null)
                {
                    ddlAddressType.Items.AddRange(list);
                    ddlAddressType.DataBind();
                }
            }
            catch (Exception)
            {
                //log
            }
        }

        private void LoadState()
        {
            try
            {
                // Load the state dropdown values using the SelectListItemService class.
                var list = (from s in _selectListItemService.LoadState()
                            select new ListItem { Text = s.Text, Value = s.Value }).ToArray();
                ddlState.Items.AddRange(list);
                ddlState.DataBind();
            }
            catch (Exception)
            {
                //log
            }
        }
    }
}
