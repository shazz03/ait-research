
using System.Collections.Generic;

namespace AITResearch.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool? IsMandatory { get; set; }
        public Survey Survey { get; set; }
        public QuestionType Type { get; set; }
        public int MinOptionSelection { get; set; }
        public string DependsOnOptionIds { get; set; }
    }
}
