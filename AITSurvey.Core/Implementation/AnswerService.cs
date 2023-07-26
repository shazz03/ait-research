using AITResearch.Core.Models;
using AITResearch.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AITResearch.Core.Implementation
{
    public class AnswerService
    {
        private readonly AnswerRepository _answerRepository;
        public AnswerService()
        {
            _answerRepository = new AnswerRepository();
        }

        /// <summary>
        /// Inserts a list of answers into the answer repository.
        /// </summary>
        /// <param name="answers">The list of answers to insert.</param>
        public void InsertAnswers(List<Answer> answers)
        {

            // Flatten the SelectedOptions collection for all Answer objects into a sequence of anonymous objects
            // that contain the Answer object and the selected option.
            var selectedAnswers = answers.SelectMany(ans => ans.SelectedOptions,
                (ans, option) => new { ans, option });

            // Convert the Answers sequence to a list and loop over each anonymous object in the list.
            selectedAnswers.ToList().ForEach(o =>
            {
                // Call the InsertAnswer method for the selected option, passing in the corresponding Answer object's properties.
                _answerRepository.InsertAnswer(o.option.Id, o.option.Description, o.ans.Survey.Id, o.ans.RespondentId, o.ans.Question.Id);
            });

        }

        /// <summary>
        /// Retrieves a list of AnswerViewDto objects for the given respondent and survey.
        /// </summary>
        /// <param name="respondentId">The ID of the respondent to retrieve answers for.</param>
        /// <param name="surveyId">The ID of the survey to retrieve answers for.</param>
        /// <returns>A list of AnswerViewDto objects.</returns>
        public List<AnswerViewDto> GetAnswerView(int respondentId, int surveyId)
        {

            return _answerRepository.GetAnswerView(respondentId, surveyId);

        }

    }
}
