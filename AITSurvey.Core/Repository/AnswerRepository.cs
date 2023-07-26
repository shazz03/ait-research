using AITResearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AITResearch.Core.Repository
{
    public class AnswerRepository
    {
        // Insert the selected options for a question in the database
        public void InsertAnswer(int optionId, string answerText, int surveyId, int respondentId, int questionId)
        {
            try
            {
                using (var con = new SqlConnection(Database.Connection.ConnectionString))
                {
                    con.Open();
                    using (var insertCommand = new SqlCommand("INSERT INTO Answer (SurveyId, OptionId, QuestionId, RespondentId, DateCreated, AnswerText) VALUES (@SurveyId, @OptionId, @QuestionId, @RespondentId, @DateCreated, @AnswerText)", con))
                    {
                        insertCommand.Parameters.Add(new SqlParameter("@SurveyId", surveyId));
                        insertCommand.Parameters.Add(new SqlParameter("@QuestionId", questionId));
                        insertCommand.Parameters.Add(new SqlParameter("@RespondentId", respondentId));
                        insertCommand.Parameters.Add(new SqlParameter("@DateCreated", DateTime.Now));
                        insertCommand.Parameters.Add(new SqlParameter("@AnswerText", answerText));
                        insertCommand.Parameters.Add(new SqlParameter("@OptionId", optionId));
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Throw an exception with a meaningful message
                throw new Exception($"An error occurred while inserting options for the question with ID {questionId}: {ex.Message}", ex);
            }
        }

        public List<AnswerViewDto> GetAnswerView(int respondentId, int surveyId)
        {
            // Create a new list to store the options
            var answers = new List<AnswerViewDto>();

            try
            {
                // Create a new SqlConnection object with the connection string from the Database class
                var conn = new SqlConnection
                {
                    ConnectionString = Database.Connection.ConnectionString
                };

                // Create a new SqlCommand object with the SQL query and the question ID parameter
                var cmd = new SqlCommand(@"select Description as QuestionText, AnswerText from Answer a inner join Question q on a.QuestionId = q.Id WHERE a.RespondentId = @RespondentId and a.SurveyId =@SurveyId", conn);
                cmd.Parameters.Add(new SqlParameter("@RespondentId", respondentId));
                cmd.Parameters.Add(new SqlParameter("@SurveyId", surveyId));

                // Open the database connection
                conn.Open();

                // Execute the SQL query and get the SqlDataReader object
                var reader = cmd.ExecuteReader();

                // Loop through the SqlDataReader and add each option to the options list
                while (reader.Read())
                {
                    answers.Add(new AnswerViewDto
                    {
                        QuestionText = reader["QuestionText"]?.ToString(),
                        AnswerText = reader["AnswerText"]?.ToString(),
                    });
                }

                // Close the database connection
                conn.Close();
            }
            catch (Exception ex)
            {
                // Handle the error
                // Here, re-throw the exception to the caller.
                throw new Exception($"An error occurred while loading options for the respondent with ID {respondentId}:{ex.Message}", ex);
            }

            return answers;
        }
    }
}