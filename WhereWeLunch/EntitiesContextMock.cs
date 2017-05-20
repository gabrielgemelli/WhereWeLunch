using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhereWeLunch.Models;
using WhereWeLunch.Models.Contracts;

namespace WhereWeLunch
{
    public class EntitiesContextMock : IEntitiesContext
    {
        public virtual DbSet<Vote> Votes { get; set; }

        public int SaveChanges()
        {
            return 1;
        }
    }
}