using System;

namespace WhereWeLunch.Models
{
    public class VoteTotal
    {
        public DateTime Date { get; set; }
        public Restaurant Restaurant { get; set; }
        public int VotesQuantity { get; set; }
    }
}