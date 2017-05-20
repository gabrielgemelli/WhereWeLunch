using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhereWeLunch.Models.Contracts
{
    public interface IEntitiesContext
    {
        DbSet<Vote> Votes { get; set; }
        int SaveChanges();
    }
}