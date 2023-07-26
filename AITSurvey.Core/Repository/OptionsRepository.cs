
using AITResearch.Core.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace AITResearch.Core.Repository
{
    // OptionsRepository class definition
    public class OptionsRepository
    {
        // LoadOptions method definition, which takes a question ID as an argument and returns a list of Option objects
        public List<Option> LoadOptions(int questionId)
        {
            // Create a new list to store the options
            var options = new List<Option>();

            try
            {
                // Create a new SqlConnection object with the connection string from the Database class
                var conn = new SqlConnection
                {
                    ConnectionString = Database.Connection.ConnectionString
                };

                // Create a new SqlCommand object with the SQL query and the question ID parameter
                var cmd = new SqlCommand(@"SELECT * FROM [Option] WHERE QuestionId = @QuestionId", conn);
                cmd.Parameters.Add(new SqlParameter("@QuestionId", questionId));

                // Open the database connection
                conn.Open();

                // Execute the SQL query and get the SqlDataReader object
                var reader = cmd.ExecuteReader();

                // Loop through the SqlDataReader and add each option to the options list
                while (reader.Read())
                {
                    options.Add(new Option
                    {
                        Id = (int)reader["Id"],
                        QuestionId = (int)reader["QuestionId"],
                        Description = reader["Description"]?.ToString(),
                    });
                }

                // Close the database connection
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle the error
                // Here, re-throw the exception to the caller.
                throw new Exception($"An error occurred while loading options for the question with ID {questionId}:{ex.Message}", ex);
            }

            // Return the options list
            return options;
        }

    }
}
