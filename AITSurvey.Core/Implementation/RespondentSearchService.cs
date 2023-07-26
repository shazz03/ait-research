using AITResearch.Core.Models;
using AITResearch.Core.Repository;
using System.Collections.Generic;

namespace AITResearch.Core.Implementation
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
