using AITResearch.Core.Models;
using AITSurvey.Core.Repository;
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
                var cmd = new SqlCommand($@"SELECT qt.TypeName, q.Description, q.Title, q.MinOptionSelection, q.SortOrder, s.Title, q.Id, q.SurveyId, q.DependsOnOptionIds, q.IsMandatory,q.QuestionTypeId AS TypeId, q.IsSearchable, qv.ValidationType, qv.Id as ValidationTypeId
                 FROM  dbo.Question q INNER JOIN dbo.QuestionType qt ON q.QuestionTypeId = qt.Id 
				 INNER JOIN dbo.Survey s ON q.SurveyId = s.Id
				   Left JOIN dbo.QuestionValidationGroup qv ON q.ValidationGroupId = qv.Id where SurveyId=@SurveyId order by SortOrder", conn);

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
                        Id = reader.GetInt32("Id"),
                        Title = reader.GetString("Title"),
                        Description = reader.GetString("Description"),
                        SortOrder = reader.GetInt32("SortOrder"),
                        IsMandatory = reader.GetBoolean("IsMandatory"),
                        IsSearchable = reader.GetBoolean("IsSearchable"),

                        Type = new QuestionType
                        {
                            Id = reader.GetInt32("TypeId"),
                            TypeName = reader.GetString("TypeName"),
                        },
                        Survey = new Survey
                        {
                            Id = reader.GetInt32("SurveyId"),
                            Title = reader.GetString("Title"),
                        },
                        // Set the minimum option selection and dependent option ID properties
                        MinOptionSelection =
                        string.IsNullOrWhiteSpace(reader["MinOptionSelection"].ToString()) ? 0 : (int)reader["MinOptionSelection"],
                        DependsOnOptionIds = reader["DependsOnOptionIds"].ToString()
                    };

                    if (!string.IsNullOrEmpty(reader.GetString("ValidationType")))
                    {
                        question.ValidationGroup = new AITSurvey.Core.Models.QuestionValidationGroup
                        {
                            ValidationType = reader.GetString("ValidationType"),
                            Id = reader.GetInt32("ValidationTypeId")
                        };
                    }

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
