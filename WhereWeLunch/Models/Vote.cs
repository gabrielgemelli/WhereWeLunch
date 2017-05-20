using System;
using WhereWeLunch.Models.Contracts;

namespace WhereWeLunch.Models
{
    public class Vote : IVote
    {
        public Vote() { }

        public Vote(int id, HungryProfessional hungryProfessional, Restaurant restaurant, DateTime votedOn) {
            ID = id;
            HungryProfessional = hungryProfessional;
            HungryProfessionalID = hungryProfessional.ID;
            Restaurant = restaurant;
            RestaurantID = restaurant.ID;
            VotedOn = votedOn;
        }

        public int ID { get; set; }

        public virtual HungryProfessional HungryProfessional { get; set; }
        public int HungryProfessionalID { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public int RestaurantID { get; set; }

        public DateTime VotedOn { get; set; }
    }
}