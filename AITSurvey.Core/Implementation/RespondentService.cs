using AITResearch.Core.Repository;
using System;
using AITResearch.Core.Models;

namespace AITResearch.Core.Implementation
{
    // This class contains methods to create, read, update, and delete Respondent records
    public class RespondentService
    {
        private RespondentRepository _respondentRepository;

        // Constructor to initialize an instance of RespondentRepository class
        public RespondentService()
        {
            _respondentRepository = new RespondentRepository();
        }

        // Method to create a new Respondent record in the database
        public int Create(int surveyId, Respondent respondent)
        {
            try
            {
                var respondentId = _respondentRepository.InsertRespondent(surveyId, respondent);
                return respondentId;
            }
            catch (Exception ex)
            {
                // Handle any other exceptions here
                throw new Exception("An error occurred while saving the respondent data.", ex);
            }
        }

        // Method to create a new RespondentProfile record for a Respondent in the database
        public int? CreateProfile(int respondentId, RespondentProfile respondentProfile)
        {
            try
            {
                if (respondentProfile != null && respondentId > 0)
                {
                    return _respondentRepository.InsertRespondentProfile(respondentId, respondentProfile);
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle any other exceptions here
                throw new Exception("An error occurred while saving the respondent data.", ex);
            }
        }
    }
}
