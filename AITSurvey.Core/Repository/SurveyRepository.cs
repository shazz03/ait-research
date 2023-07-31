using AITResearch.Core.Models;
using AITSurvey.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace AITResearch.Core.Repository
{
    public class SurveyRepository
    {
        public List<Survey> GetSurveyList()
        {
            var list = new List<Survey>();

            try
            {
                using (var myConnection = new SqlConnection(Database.Connection.ConnectionString))
                {
                    var command = new SqlCommand("SELECT * FROM Survey", myConnection);

                    myConnection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Survey
                            {
                                Title = reader.GetString("Title"),
                                Id = reader.GetInt32("Id"),
                                Description = reader.GetString("Description"),
                                DateCreated = reader.GetDateTime("DateCreated")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw new Exception("An error occurred while loading the surveys.", ex);
            }

            return list;
        }
    }
}
