using AITResearch.Core.Models;
using AITResearch.Core.Repository;
using System.Collections.Generic;

namespace AITSurvey.Core.Implementation
{
    public class SurveyService
    {
        private readonly SurveyRepository _surveyRepository;

        public SurveyService()
        {
            _surveyRepository = new SurveyRepository();
        }

        public List<Survey> GetSurveyList()
        {
           return _surveyRepository.GetSurveyList();
        }
    }
}
