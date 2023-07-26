
using System;
using System.Collections.Generic;

namespace AITResearch.Core.Models
{
    public class Answer
    {
        public int RespondentId { get; set; }
        public Question Question { get; set; }
        public Survey Survey { get; set; }
        public List<Option> SelectedOptions { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
