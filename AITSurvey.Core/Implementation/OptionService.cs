using AITResearch.Core.Models;
using AITResearch.Core.Repository;
using System.Collections.Generic;

namespace AITResearch.Core.Implementation
{
    public  class OptionService
    {
        private readonly OptionsRepository _optionsRepository;
        public OptionService() {
            _optionsRepository = new OptionsRepository();
        }

        /// <summary>
        /// Loads the list of options for a given question.
        /// </summary>
        /// <param name="questionId">The ID of the question for which to load options.</param>
        /// <returns>A list of options for the specified question.</returns>
        public List<Option> LoadOptions(int questionId)
        {
            return _optionsRepository.LoadOptions(questionId);
        }
    }
}
