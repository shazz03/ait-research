
using System;

namespace AITSurvey.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public DateTime DateCreated { get; set; }
        public State State { get; set; }
        public AddressType AddressType { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
    }

    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string TypeName { get; set; }
    }
}
