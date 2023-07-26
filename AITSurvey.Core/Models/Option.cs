namespace AITResearch.Core.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
        public int ParentOptionId { get; set; }
    }
}
