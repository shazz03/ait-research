
namespace AITSurvey.Core.Models
{
    public class RespondentSearchRequest
    {
        /// <summary>
        /// Gets or sets the first name of the respondent.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the respondent.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the respondent.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the postcode of the respondent's address.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the suburb of the respondent's address.
        /// </summary>
        public string Suburb { get; set; }

        /// <summary>
        /// Gets or sets the ID of the state where the respondent's address is located.
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the age range that the respondent falls under.
        /// </summary>
        public int AgeRangeId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the gender of the respondent.
        /// </summary>
        public int GenderId { get; set; }

    }
}
