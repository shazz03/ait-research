﻿using AITSurvey.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AITSurvey.Core.Repository
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
                cmd.Parameters.AddWithValue("@AgeGroupId", search.AgeRangeId == 0 ? (object)DBNull.Value : search.AgeRangeId);
                cmd.Parameters.AddWithValue("@StateId", search.StateId == 0 ? (object)DBNull.Value : search.StateId);
                cmd.Parameters.AddWithValue("@GenderId", search.GenderId == 0 ? (object)DBNull.Value : search.GenderId);
                cmd.Parameters.AddWithValue("@Suburb", string.IsNullOrEmpty(search.Suburb) ? (object)DBNull.Value : search.Suburb);
                cmd.Parameters.AddWithValue("@Postcode", string.IsNullOrEmpty(search.Postcode) ? (object)DBNull.Value : search.Postcode);

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
                            Id = GetInt32("Id",reader),
                            SurveyId = GetInt32("SurveyId", reader),
                            Email = GetString("Email", reader),
                            MacAddress = GetString("MacAddress", reader),
                            DateCreated = reader.IsDBNull(reader.GetOrdinal("DateCreated")) ? default : reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                        },
                        Profile = new RespondentProfile
                        {
                            Id = GetInt32("RespondentProfileId", reader),
                            FirstName = GetString("FirstName", reader),
                            LastName = GetString("LastName", reader),
                            AgeGroup = new AgeGroup
                            {
                                AgeGroupName = GetString("AgeGroup", reader),
                                Id = GetInt32("AgeGroupId", reader)
                            },
                            Gender = new Gender
                            {
                                Id = GetInt32("GenderId", reader),
                                GenderName = GetString("Gender", reader)
                            },
                            ContactNumber = GetString("ContactNumber", reader),
                            DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? default : reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                        },
                        Address = new Address
                        {
                            Id = GetInt32("AddressId", reader),
                            State = new State
                            {
                                Id = GetInt32("StateId", reader),
                                StateName = GetString("State", reader)
                            },
                            Postcode = GetString("Postcode",reader),
                            Suburb = GetString("Suburb", reader),
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

        private string GetString(string columnName, SqlDataReader reader)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? default : reader.GetString(reader.GetOrdinal(columnName));
        }

        private int GetInt32(string columnName, SqlDataReader reader)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? default : reader.GetInt32(reader.GetOrdinal(columnName));
        }
    }
}
