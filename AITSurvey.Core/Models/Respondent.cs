using System;

namespace AITResearch.Core
{
    public class Respondent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string MacAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public int SurveyId { get; set; }
    }
}
