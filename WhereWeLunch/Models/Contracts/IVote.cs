using System;

namespace WhereWeLunch.Models.Contracts
{
    public interface IVote
    {
        int ID { get; set; }

        HungryProfessional HungryProfessional { get; set; }
        int HungryProfessionalID { get; set; }

        Restaurant Restaurant { get; set; }
        int RestaurantID { get; set; }

        DateTime VotedOn { get; set; }
    }
}