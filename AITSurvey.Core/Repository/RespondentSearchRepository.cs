using AITResearch.Core.Models;
using AITSurvey.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AITResearch.Core.Repository
{
    public class RespondentSearchRepository
    {
        public List<RespondentSearchResult> Search(RespondentSearchRequest search)
        {
            var respondents = new List<RespondentSearchResult>();

            try
            {
                // Create a new SqlConnection object with the connection string from the Database class
                var conn = new SqlConnection
                {
                    ConnectionString = Database.Connection.ConnectionString
                };

                var cmd = new SqlCommand("spGetRespondentSearchResult", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(search.FirstName) ? (object)DBNull.Value : search.FirstName);
                cmd.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(search.LastName) ? (object)DBNull.Value : search.LastName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(search.Email) ? (object)DBNull.Value : search.Email);

                // Open the database connection
                conn.Open();

                // Execute the SQL query and get the SqlDataReader object
                var reader = cmd.ExecuteReader();

                // Loop through the SqlDataReader and add each respondent to the respondents list
                while (reader.Read())
                {
                    var respondent = new RespondentSearchResult
                    {
                        Respondent = new Respondent
                        {
                            Id = reader.GetInt32("Id"),
                            SurveyId = reader.GetInt32("SurveyId"),
                            Email = reader.GetString("Email"),
                            MacAddress = reader.GetString("MacAddress"),
                            DateCreated = reader.GetDateTime("DateCreated"),
                        },
                        Profile = new RespondentProfile
                        {
                            Id = reader.GetInt32("RespondentProfileId"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            ContactNumber = reader.GetString("ContactNumber"),
                            DateOfBirth = reader.GetDateTime("DateOfBirth"),
                        }
                    };

                    respondents.Add(respondent);
                }

                // Close the database connection
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle the error
                // Here, re-throw the exception to the caller.
                throw new Exception($"An error occurred while loading Respondents data", ex);
            }

            // Return the options list
            return respondents;
        }

    }
}
