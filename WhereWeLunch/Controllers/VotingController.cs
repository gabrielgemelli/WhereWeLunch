using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using WhereWeLunch.DAO;
using WhereWeLunch.Models;
using WhereWeLunch.Models.Contracts;
using WhereWeLunch.Models.Response;

namespace WhereWeLunch.Controllers
{
    public class VotingController : ApiController, IVotingController
    {

        public virtual bool HungryProfessionalUsernameVotedToday(string email)
        {
            var dao = new VotingDAO();
            return dao.Get(email, DateTime.Now).Any();
        }

        #region private methods

        private bool IsBeforeNoon(DateTime? now = null)
        {
            if (now.HasValue)
            {
                return now.Value.Hour < 12;
            }

            return DateTime.Now.Hour < 12;
        }

        private VoteTotal GetRestaurantMostVoted(DateTime date)
        {
            var mostVoted = this.GetRestaurantsMostVoted(date);

            if (mostVoted != null && mostVoted.Any()) return mostVoted.FirstOrDefault();

            return default(VoteTotal);
        }

        private IList<VoteTotal> GetRestaurantsMostVotedThisWeek()
        {
            var mostVotedThisWeek = new List<VoteTotal>();

            var dayOfWeekToday = (int)DateTime.Today.DayOfWeek;

            if (dayOfWeekToday > 0)
            {
                for (var dow = 1; dow <= dayOfWeekToday; dow++)
                {
                    var mostVoted = this.GetRestaurantMostVoted(DateTime.Today.AddDays(-dow));

                    if (mostVoted != null) mostVotedThisWeek.Add(mostVoted);
                }
            }

            return mostVotedThisWeek.OrderByDescending(a => a.Date).ToList();
        }

        private string CanVote(Vote vote, DateTime? now = null)
        {
            if (vote == null || vote.HungryProfessional == null)
            {
                return "Object can not be null!";
            }

            if (String.IsNullOrWhiteSpace(vote.HungryProfessional.Email))
            {
                return "User not logged in!";
            }

            if (this.HungryProfessionalUsernameVotedToday(vote.HungryProfessional.Email))
            {
                return "You already voted today!";
            }

            if (!this.IsBeforeNoon(now))
            {
                return "Voting is avaliable until noon!";
            }

            return string.Empty;
        }

        #endregion

        public virtual VoteResponse Vote(Vote vote, IEntitiesContext context = null, DateTime? now = null)
        {
            var canVote = this.CanVote(vote, now);

            if (!string.IsNullOrWhiteSpace(canVote))
            {
                return new VoteResponse { ResponseCode = HttpStatusCode.Forbidden, StatusIsSuccessful = false, ResponseResult = canVote };
            }

            vote.HungryProfessional = new HungryProfessionalDAO().Get(vote.HungryProfessional.Email);
            vote.VotedOn = now ?? DateTime.Now;

            var dao = new VotingDAO(context);

            dao.Post(vote);

            return new VoteResponse { ResponseCode = HttpStatusCode.OK, StatusIsSuccessful = true };
        }

        // POST api/<controller>
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public VoteResponse Post([FromBody]Vote vote)
        {
            return Vote(vote);
        }

        [System.Web.Http.HttpGet]
        [ValidateAntiForgeryToken]
        public IList<VoteTotal> GetRestaurantsMostVoted(DateTime date)
        {
            var dao = new VotingDAO();
            var votes = dao.Get(date);
            var votesGroupBy = votes.GroupBy(a => a.RestaurantID);
            var votesSelect = votesGroupBy.Select(a => new VoteTotal { Date = date, Restaurant = a.First().Restaurant, VotesQuantity = a.Count() });

            return votesSelect.OrderByDescending(a=>a.VotesQuantity).ToList();
        }

        [System.Web.Http.HttpGet]
        [ValidateAntiForgeryToken]
        public IList<Restaurant> GetRestaurantsToVoting()
        {
            var restaurants = new List<Restaurant>();

            if (IsBeforeNoon())
            {
                restaurants = new RestaurantController().Get().ToList();

                var mostVotedThisWeek = GetRestaurantsMostVotedThisWeek().ToList();

                restaurants.RemoveAll(a => mostVotedThisWeek.Exists(b => b.Restaurant.ID == a.ID));
            }

            return restaurants;
        }
    }
}