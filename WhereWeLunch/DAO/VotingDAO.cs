using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using WhereWeLunch.Models;
using WhereWeLunch.Models.Contracts;

namespace WhereWeLunch.DAO
{
    public class VotingDAO
    {
        private IEntitiesContext db = null;

        public VotingDAO() { }

        public VotingDAO(IEntitiesContext context)
        {
            if (context == null)
                db = new EntitiesContext();
            else
                db = context;
        }

        public IList<Vote> Get(DateTime date)
        {
            return db.Votes.Include(a => a.Restaurant).Include(b => b.HungryProfessional).Where(v => v.VotedOn.Date == date.Date).ToList();
        }

        public IList<Vote> Get(string email, DateTime date)
        {
            //return db.Votes.Include(a => a.Restaurant).Include(b => b.HungryProfessional).Where(v => v.VotedOn.Date == date.Date && v.HungryProfessional.Email == email).ToList();
            return db.Votes.ToList();
        }

        public void Post(Vote vote)
        {
            db.Votes.Add(vote);
            db.SaveChanges();
        }
    }
}