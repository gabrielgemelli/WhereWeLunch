using Microsoft.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using WhereWeLunch.Controllers;
using WhereWeLunch.Models;
using WhereWeLunch.Models.Contracts;
using WhereWeLunch.Models.Response;
using Moq.Protected;

namespace WhereWeLunch.Tests.Controllers
{
    [TestClass()]
    public class VotingControllerTests
    {
        [TestMethod]
        public void VoteTestWithNullObject()
        {
            Vote vote = null;
            var context = new EntitiesContextMock();
            var controller = new VotingController();
            Assert.AreEqual(controller.Vote(vote, context).ResponseCode, System.Net.HttpStatusCode.Forbidden);
        }

        [TestMethod]
        public void VoteTestWithHungryProfessionalNullObject()
        {
            Vote vote = new Vote();
            var context = new EntitiesContextMock();
            var controller = new VotingController();
            Assert.AreEqual(controller.Vote(vote, context).ResponseCode, System.Net.HttpStatusCode.Forbidden);
        }

        [TestMethod]
        public void VoteTestWithHungryProfessionalEmailEmpty()
        {
            Vote vote = new Vote() { HungryProfessional = new HungryProfessional() };
            var context = new EntitiesContextMock();
            var controller = new VotingController();
            Assert.AreEqual(controller.Vote(vote, context).ResponseCode, System.Net.HttpStatusCode.Forbidden);
        }

        private DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            //dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        private static Mock<DbSet<T>> GetDbSetMock<T>(IEnumerable<T> items = null) where T : class
        {
            if (items == null)
            {
                items = new T[0];
            }

            var dbSetMock = new Mock<DbSet<T>>();
            var q = dbSetMock.As<IQueryable<T>>();

            q.Setup(x => x.GetEnumerator()).Returns(items.GetEnumerator);

            return dbSetMock;
        }

        [TestMethod]
        public void VoteTestWithAfterNoon()
        {
            var listVote = new List<Vote>();
            listVote.Add(new Vote(1, new HungryProfessional(1, "teste@teste.com.br", "12345"), new Restaurant(1, "teste"), DateTime.Now));

            var context = new Mock<EntitiesContext>();
            context.Setup(x => x.Votes).Returns(GetDbSetMock(listVote).Object);

            var professional = new HungryProfessional() { Email = "teste@teste.com.br" };
            var vote = new Vote() { HungryProfessional = professional };

            var dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 13, 0, 0);

            //var controller = new VotingController();
            var controller = new Mock<VotingController>();
            controller.Setup(x => x.HungryProfessionalUsernameVotedToday(professional.Email)).Returns(false);
            controller.Setup(x => x.Vote(vote, context.Object, dateTime)).Returns(new VoteResponse() { ResponseCode = System.Net.HttpStatusCode.Forbidden } );

            var result = controller.Object.Vote(vote, context.Object, dateTime);
            Assert.AreEqual(result.ResponseCode, System.Net.HttpStatusCode.Forbidden);
        }

    }
}