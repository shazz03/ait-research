using AITSurvey.Core.Models;
using AITSurvey.Core.Repository;
using System.Collections.Generic;

namespace AITSurvey.Core.Implementation
{
    public class RespondentSearchService
    {
       private readonly RespondentSearchRepository _respondentSearchRepository;
        public RespondentSearchService() {
            _respondentSearchRepository = new RespondentSearchRepository();
        }

        public List<RespondentSearchResult> Search(RespondentSearchRequest searchRequest)
        {
            return _respondentSearchRepository.Search(searchRequest);
        }
        
    }
}
