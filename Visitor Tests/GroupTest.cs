using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmTests
{
    [TestClass]
    public class GroupTest
    {
        [TestMethod]
        public void GroupConstructorTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            //act
            Group group = new Group(visitors);

            //assert
            Assert.IsTrue(group.visitors.Count == visitors.Count);
            Assert.IsTrue(group.visitors[0].Name == visitors[0].Name &&
                group.visitors[0].BirthDate == visitors[0].BirthDate &&
                group.visitors[0].RegisterTime == visitors[0].RegisterTime);
        }
        [TestMethod]
        public void CheckAdultsInGroupWithAdultAndChildren()
        {
            //arrange
            DateTime birthDate1 = new DateTime(1980, 10, 10);
            DateTime birthDate2 = new DateTime(2023, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate1, registerTime, name);     
            Visitor visitor2 = new Visitor(birthDate2, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.AdultsAtEvent(@event);
            
            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(group.visitors[0].Name == visitors[0].Name &&
                group.visitors[0].BirthDate == visitors[0].BirthDate &&
                group.visitors[0].RegisterTime == visitors[0].RegisterTime);
        }

        [TestMethod]
        public void CheckAdultsInGroupWithOnlyAdults()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.AdultsAtEvent(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(group.visitors[0].Name == visitors[0].Name &&
                group.visitors[0].BirthDate == visitors[0].BirthDate &&
                group.visitors[0].RegisterTime == visitors[0].RegisterTime);
        }

        [TestMethod]
        public void CheckAdultsInGroupWithOnlyChildren()
        {
            //arrange
            DateTime birthDate = new DateTime(2023, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.AdultsAtEvent(@event);

            //assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CheckChildrenInGroupWithAdultAndChildren()
        {
            //arrange
            DateTime birthDate1 = new DateTime(1980, 10, 10);
            DateTime birthDate2 = new DateTime(2023, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate1, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate2, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.ChildsAtEvent(@event);

            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(group.visitors[0].Name == visitors[0].Name &&
                group.visitors[0].BirthDate == visitors[0].BirthDate &&
                group.visitors[0].RegisterTime == visitors[0].RegisterTime);
        }

        [TestMethod]
        public void CheckChildrenInGroupWithOnlyAdults()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.ChildsAtEvent(@event);

            //assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CheckChildrenInGroupWithOnlyChildren()
        {
            //arrange
            DateTime birthDate = new DateTime(2023, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.ChildsAtEvent(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(group.visitors[0].Name == visitors[0].Name &&
                group.visitors[0].BirthDate == visitors[0].BirthDate &&
                group.visitors[0].RegisterTime == visitors[0].RegisterTime);
        }

        [TestMethod]
        public void AllowedVisitorsWithAdultsTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.AllowedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Equals(visitors[0]));
            Assert.IsTrue(result[1].Equals(visitors[1]));
        }

        [TestMethod]
        public void AllowedVisitorsWithChildrenTest()
        {
            //arrange
            DateTime birthDate = new DateTime(2022, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.AllowedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void AllowedVisitorsWithAdultsAndChildrenTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            DateTime birthDate2 = new DateTime(2022, 10, 10);
            string name2 = "Jack";

            Visitor visitor = new Visitor(birthDate, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate2, registerTime, name2);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.AllowedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Equals(visitors[0]));
            Assert.IsTrue(result[1].Equals(visitors[1]));
        }

        [TestMethod]
        public void AllowedVisitorsWithAdultsWithOneRegisteredAfterDeadLineTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            DateTime registerTime2 = new DateTime(2023, 12, 20);
            string name2 = "Jack";

            Visitor visitor = new Visitor(birthDate, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate, registerTime2, name2);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.AllowedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Equals(visitors[0]));
        }

        [TestMethod]
        public void AllowedVisitorsWithAdultsAndChildrenWithOneRegisteredAfterDeadLineTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            DateTime registerTime2 = new DateTime(2023, 12, 20);
            DateTime birthDate2 = new DateTime(2022, 10, 10);
            string name2 = "Jack";

            Visitor visitor = new Visitor(birthDate, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate2, registerTime2, name2);

            DateTime eventDate = new DateTime(2023, 12, 20);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, registerTime, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.AllowedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Equals(visitors[0]));
        }

        [TestMethod]
        public void RejectedVisitorsWithAdultsTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 20);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            DateTime deadline = new DateTime(2023, 12, 17);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.RejectedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Equals(visitors[0]));
            Assert.IsTrue(result[1].Equals(visitors[1]));
        }

        [TestMethod]
        public void RejectedVisitorsWithChildrenTest()
        {
            //arrange
            DateTime birthDate = new DateTime(2022, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 20);
            string name = "Sam";
            Visitor visitor = new Visitor(birthDate, registerTime, name);

            DateTime eventDate = new DateTime(2023, 12, 20);
            DateTime deadline = new DateTime(2023, 12, 17);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group = new Group(visitors);

            //act
            var result = group.RejectedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Equals(visitors[0]));
            Assert.IsTrue(result[1].Equals(visitors[1]));
        }

        [TestMethod]
        public void RejectedVisitorsWithAdultsAndChildrenTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 20);
            string name = "Sam";

            DateTime birthDate2 = new DateTime(2022, 10, 10);
            string name2 = "Jack";

            Visitor visitor = new Visitor(birthDate, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate2, registerTime, name2);

            DateTime eventDate = new DateTime(2023, 12, 20);
            DateTime deadline = new DateTime(2023, 12, 17);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.RejectedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result[0].Equals(visitors[0]));
            Assert.IsTrue(result[1].Equals(visitors[1]));
        }

        [TestMethod]
        public void RejectedVisitorsWithAdultsWithOneRegisteredAfterDeadLineTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            DateTime registerTime2 = new DateTime(2023, 12, 20);
            string name2 = "Jack";

            Visitor visitor = new Visitor(birthDate, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate, registerTime2, name2);

            DateTime eventDate = new DateTime(2023, 12, 20);
            DateTime deadline = new DateTime(2023, 12, 17);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.RejectedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Equals(visitors[1]));
        }

        [TestMethod]
        public void RejectedVisitorsWithAdultsAndChildrenWithOneRegisteredAfterDeadLineTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            DateTime registerTime2 = new DateTime(2023, 12, 20);
            DateTime birthDate2 = new DateTime(2022, 10, 10);
            string name2 = "Jack";

            Visitor visitor = new Visitor(birthDate, registerTime, name);
            Visitor visitor2 = new Visitor(birthDate2, registerTime2, name2);

            DateTime eventDate = new DateTime(2023, 12, 20);
            DateTime deadline = new DateTime(2023, 12, 17);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);

            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor2);
            Group group = new Group(visitors);

            //act
            var result = group.RejectedVisitors(@event);

            //assert
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Equals(visitors[1]));
        }
    }
}
