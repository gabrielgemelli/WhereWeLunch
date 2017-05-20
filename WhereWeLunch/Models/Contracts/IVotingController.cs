using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhereWeLunch.Models.Response;

namespace WhereWeLunch.Models.Contracts
{
    public interface IVotingController
    {
        VoteResponse Vote(Vote vote, IEntitiesContext context = null, DateTime? now = null);
    }
}