using AITSurvey.Core.Implementation;
using AITSurvey.Core.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AITSurvey
{
    public partial class RespondentSearch : Page
    {
        private readonly OptionService _optionService;
        private readonly SelectListItemService _selectListItemService;
        private readonly RespondentSearchService _respondentSearchService;
        public RespondentSearch()
        {
            _selectListItemService = new SelectListItemService();
            _respondentSearchService = new RespondentSearchService();
            _optionService = new OptionService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffId"] == null)
            {
                Response.Redirect("~/StaffLogin");
            }
            if (!IsPostBack)
            {
                LoadAgeGroup();
                LoadState();
                LoadGender();
                LoadRoomTypeOption();
                LoadInRoomServiceOption();
                LoadServicesOption();
                LoadHealthInsuranceOption();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void Search()
        {
            var search = new RespondentSearchRequest
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                AgeRangeId = int.Parse(ddlAgeGroup.SelectedValue),
                StateId = int.Parse(ddlState.SelectedValue),
                Suburb = txtSuburb.Text,
                Postcode = txtPostcode.Text,
                GenderId = int.Parse(ddlGender.SelectedValue),
                Email = txtEmail.Text
            };

            var result = _respondentSearchService.Search(search);

            gvRespondent.DataSource = result;
            gvRespondent.DataBind();
        }

        /// <summary>
        /// Loads age group options into the dropdown list from the select list item service
        /// </summary>
        private void LoadAgeGroup()
        {
            try
            {
                // retrieve age group options from the select list item service and create a new list of ListItems
                var list = (from s in _optionService.LoadOptions(SearchListQuestionIdOptions.Gender)
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the age group dropdown list and bind the data
                if (list != null)
                {
                    ddlGender.Items.Add(new ListItem { Text = "Age Group", Value = "0" });
                    ddlAgeGroup.Items.AddRange(list);
                    ddlAgeGroup.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of age group options
                //log
            }
        }

        /// <summary>
        /// Loads Gender options into the dropdown list from the select list item service
        /// </summary>
        private void LoadGender()
        {
            try
            {
                // retrieve state options from the select list item service and create a new list of ListItems
                var list = (from s in _optionService.LoadOptions(SearchListQuestionIdOptions.Gender)
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the state dropdown list and bind the data
                if (list != null)
                {
                    ddlGender.Items.Add(new ListItem { Text = "Gender", Value = "0" });
                    ddlGender.Items.AddRange(list);
                    ddlGender.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of state options
                //log
            }
        }

        /// <summary>
        /// Loads State options into the dropdown list from the select list item service
        /// </summary>
        private void LoadState()
        {
            try
            {
                // retrieve state options from the select list item service and create a new list of ListItems
                var list = (from s in _selectListItemService.LoadState()
                            select new ListItem { Text = s.Text, Value = s.Value }).ToArray();
                // add the ListItems to the state dropdown list and bind the data
                if (list != null)
                {
                    ddlState.Items.AddRange(list);
                    ddlState.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of state options
                //log
            }
        }


        /// <summary>
        /// Loads RoomType options into the dropdown list from the select list item service
        /// </summary>
        private void LoadRoomTypeOption()
        {
            try
            {
                // retrieve state options from the select list item service and create a new list of ListItems
                var list = (from s in _optionService.LoadOptions(SearchListQuestionIdOptions.RoomType)
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the state dropdown list and bind the data
                if (list != null)
                {
                    ddlRoomType.Items.Add(new ListItem { Text = "Room Type", Value = "0" });
                    ddlRoomType.Items.AddRange(list);
                    ddlRoomType.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of state options
                //log
            }
        }

        /// <summary>
        /// Loads InRoomService options into the dropdown list from the select list item service
        /// </summary>
        private void LoadInRoomServiceOption()
        {
            try
            {
                // retrieve state options from the select list item service and create a new list of ListItems
                var list = (from s in _optionService.LoadOptions(SearchListQuestionIdOptions.InRoomService)
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the state dropdown list and bind the data
                if (list != null)
                {
                    ddlRoomService.Items.Add(new ListItem { Text = "In-Room Service", Value = "0" });
                    ddlRoomService.Items.AddRange(list);
                    ddlRoomService.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of state options
                //log
            }
        }

        /// <summary>
        /// Loads InRoomService options into the dropdown list from the select list item service
        /// </summary>
        private void LoadServicesOption()
        {
            try
            {
                // retrieve state options from the select list item service and create a new list of ListItems
                var list = (from s in _optionService.LoadOptions(SearchListQuestionIdOptions.Services)
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the state dropdown list and bind the data
                if (list != null)
                {
                    ddlServices.Items.Add(new ListItem { Text = "Services", Value = "0" });
                    ddlServices.Items.AddRange(list);
                    ddlServices.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of state options
                //log
            }
        }

        /// <summary>
        /// Loads RoomType options into the dropdown list from the select list item service
        /// </summary>
        private void LoadHealthInsuranceOption()
        {
            try
            {
                // retrieve state options from the select list item service and create a new list of ListItems
                var list = (from s in _optionService.LoadOptions(SearchListQuestionIdOptions.HealthInsurance)
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the state dropdown list and bind the data
                if (list != null)
                {
                    ddlHealthInsurance.Items.Add(new ListItem { Text = "Private Health Insurance", Value = "0" });
                    ddlHealthInsurance.Items.AddRange(list);
                    ddlHealthInsurance.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of state options
                //log
            }
        }

    }
}