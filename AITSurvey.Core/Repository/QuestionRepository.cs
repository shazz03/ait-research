using AITResearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AITResearch.Core.Repository
{
    public class QuestionRepository
    {
        // Load questions by surveyId from the database
        public List<Question> LoadQuestions(int surveyId)
        {
            var conn = new SqlConnection
            {
                ConnectionString = Database.Connection.ConnectionString
            };

            try
            {
                // Create a SQL command to retrieve questions for the specified survey
                var cmd = new SqlCommand($@"SELECT dbo.QuestionType.TypeName, dbo.Question.Description, dbo.Question.MinOptionSelection, dbo.Question.SortOrder, dbo.Survey.Title, dbo.Question.Id, dbo.Question.SurveyId, dbo.Question.DependsOnOptionIds, dbo.Question.IsMandatory,dbo.Question.QuestionTypeId AS TypeId
                 FROM  dbo.Question INNER JOIN
                 dbo.QuestionType ON dbo.Question.QuestionTypeId = dbo.QuestionType.Id INNER JOIN
                 dbo.Survey ON dbo.Question.SurveyId = dbo.Survey.Id where SurveyId=@SurveyId order by SortOrder", conn);

                // Add the surveyId parameter to the command
                cmd.Parameters.Add(new SqlParameter("@SurveyId", surveyId));

                // Open the database connection and execute the command
                conn.Open();
                var reader = cmd.ExecuteReader();

                var questions = new List<Question>();
                while (reader.Read())
                {
                    // Create a new question object from the retrieved data
                    var question = new Question
                    {
                        Id = (int)reader["Id"],
                        Description = reader["Description"].ToString(),
                        SortOrder = (int)reader["SortOrder"],
                        //IsMandatory = (bool?)reader["IsMandatory"],
                        Type = new QuestionType
                        {
                            Id = (int)reader["TypeId"],
                            TypeName = reader["TypeName"].ToString(),
                        },
                        Survey = new Survey
                        {
                            Id = (int)reader["SurveyId"],
                            Title = reader["Title"].ToString(),
                        },
                        // Set the minimum option selection and dependent option ID properties
                        MinOptionSelection =
                        string.IsNullOrWhiteSpace(reader["MinOptionSelection"].ToString()) ? 0 : (int)reader["MinOptionSelection"],
                        DependsOnOptionIds = reader["DependsOnOptionIds"].ToString()
                    };

                    // Add the question to the list of questions
                    questions.Add(question);
                }

                // Return the list of questions
                return questions;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur and return an empty list of questions
                throw new Exception("Error loading questions: " + ex.Message, ex);
            }
            finally
            {
                // Close the database connection
                conn.Close();
            }
        }
    }
}
