using AITResearch.Core;
using AITResearch.Core.Implementation;
using AITResearch.Core.Models;
using AITSurvey.Core.Implementation;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AITResearch
{
    public partial class RespondentSearch : Page
    {
        private readonly OptionService _optionService;
        private readonly QuestionService _questionService;
        private readonly SurveyService _surveyService;
        private readonly RespondentSearchService _respondentSearchService;
        public RespondentSearch()
        {
            _respondentSearchService = new RespondentSearchService();
            _optionService = new OptionService();
            _questionService = new QuestionService();
            _surveyService = new SurveyService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffId"] == null)
            {
                Response.Redirect("~/StaffLogin");
            }
            if (!IsPostBack)
            {
                LoadSurveys();
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
                Email = txtEmail.Text
            };

            var result = _respondentSearchService.Search(search);

            gvRespondent.DataSource = result;
            gvRespondent.DataBind();
        }


        private void LoadSearchableFields()
        {
            // load all questions with seachable field is enabled
            var questions = _questionService.LoadQuestions(int.Parse(ddlSurvey.SelectedValue));
            foreach (var question in questions)
            {
                
                if (!question.IsSearchable)
                    continue;

                var pnl = new Panel();
                pnl.Attributes.Add("class", "col-3 form-outline");

                if (question.Type.TypeName == TypeOptions.Text)
                {
                    var txtBox = new TextBox
                    {
                        ID = $"txt-{question.Id}",
                        CssClass = "form-control form-control-lg"
                    };
                    var lbl = new Label
                    {
                        Text = question.Title,
                        AssociatedControlID = $"txt-{question.Id}"
                       
                    };

                    pnl.Controls.Add(lbl);
                    pnl.Controls.Add(txtBox);
                }
                else
                {
                    var ddl = new DropDownList
                    {
                        ID= $"ddl-{question.Id}",
                        CssClass = "form-select form-select-lg mb-3"
                    };
                    ddl.Items.Add(new ListItem { Text = $"Select {question.Title}", Value = "0" });
                    var lbl = new Label
                    {
                        Text = question.Title,
                        AssociatedControlID = $"ddl-{question.Id}"
                    };
                    var options = _optionService.LoadOptions(question.Id);
                    foreach (var option in options)
                    {
                        ddl.Items.Add(new ListItem { Text = option.Description, Value = option.Id.ToString() });
                    }
                    pnl.Controls.Add(lbl);
                    pnl.Controls.Add(ddl);
                }

                pnlSearch.Controls.Add(pnl);
            }
        }

        /// <summary>
        /// Loads age group options into the dropdown list from the select list item service
        /// </summary>
        private void LoadSurveys()
        {
            try
            {
                // retrieve age group options from the select list item service and create a new list of ListItems
                var list = (from s in _surveyService.GetSurveyList()
                            select new ListItem { Text = s.Description, Value = s.Id.ToString() }).ToArray();
                // add the ListItems to the age group dropdown list and bind the data
                if (list != null)
                {
                    ddlSurvey.Items.Add(new ListItem { Text = "Select Survey", Value = "0" });
                    ddlSurvey.Items.AddRange(list);
                    ddlSurvey.DataBind();
                }
            }
            catch (Exception)
            {
                // catch any exceptions that occur during the loading of age group options
                //log
            }
        }


        protected void ddlSurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSearchableFields();
        }
    }
}