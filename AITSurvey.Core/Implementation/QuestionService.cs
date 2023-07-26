using AITSurvey.Core.Models;
using AITSurvey.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AITSurvey.Core.Implementation
{
    public class QuestionService
    {
        private QuestionRepository _questionAnswerRepository;

        public QuestionService()
        {
            // Create an instance of QuestionRepository to access the data layer
            _questionAnswerRepository = new QuestionRepository();
        }

        // Check if a given question is the last one in the list of questions
        public bool IsLastQuestion(Question question, List<Question> questions)
        {
            return question.Id == questions.LastOrDefault().Id;
        }

        // Check if a given question is the first one in the list of questions
        public bool IsFirstQuestion(Question question, List<Question> questions)
        {
            return question.Id == questions.FirstOrDefault().Id;
        }

        // Get the current question based on the given questionId
        public Question GetCurrentQuestion(int questionId, List<Question> questions)
        {
            // Find the question in the list by its Id, or return the first question if questionId is 0
            return questions.FirstOrDefault(q => q.Id == questionId) ?? questions.FirstOrDefault();
        }


        // Get the next question based on the current question, the list of questions, 
        // the selected options, and whether the current question was skipped
        public Question NextQuestion(List<Question> questions, List<Option> selectedOption,
                                     Question currentQuestion, bool isSkipped)
        {
            if (IsLastQuestion(currentQuestion, questions))
            {
                // If the current question is the last one in the list, return null to indicate the end of the survey
                return null;
            }

            // Get the next question in the list based on the current question
            var next = questions.SkipWhile(x => x != currentQuestion).Skip(1).DefaultIfEmpty(questions[0]).FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(next.DependsOnOptionIds))
            {
                // If the next question depends on certain option(s) of the selected options, check if the selected options
                // contain any of the required option Ids
                var dependsOnMultipleOptions = next.DependsOnOptionIds.Split(',');
                if (dependsOnMultipleOptions?.Count() > 0)
                {
                    var selectedOptionIds = selectedOption?.Select(s => s.Id.ToString());
                    var containsId = selectedOptionIds != null && dependsOnMultipleOptions.Any(dependsOnOption => selectedOptionIds.Contains(dependsOnOption));
                    if (!containsId)
                    {
                        // If the selected options do not contain any of the required option Ids, recursively call this method
                        // to get the next question again
                        return NextQuestion(questions, selectedOption, next, isSkipped);
                    }
                }
            }
            // Return the next question
            return next;
        }

        // Load the questions of a survey from the data layer using QuestionRepository
        public List<Question> LoadQuestions(int surveyId)
        {
            return _questionAnswerRepository.LoadQuestions(surveyId);
        }
    }

}
