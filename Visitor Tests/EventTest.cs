using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Tests
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void CreateBoxTest()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            int oldCount = @event.boxes.Count;
            //act
            @event.CreateBox();
            //assert
            Assert.AreEqual(oldCount + 1, @event.boxes.Count);
        }
        [TestMethod]
        public void GetFirstBoxCodeTest()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            char firstCharacter;
            //act
            firstCharacter = @event.GetNextBoxCode();
            //assert
            Assert.IsTrue(firstCharacter == 'A');
        }
        [TestMethod]
        public void GetNextBoxCodeTest()
        {
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            @event.CreateBox();
            @event.CreateBox();
            @event.CreateBox();
            char nextCharacter;
            //act
            nextCharacter = @event.GetNextBoxCode();
            //assert
            Assert.IsTrue(nextCharacter == 'D');
        }
        [TestMethod]
        public void SortGroupsTest()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            List<Visitor> visitors = new List<Visitor>();
            DateTime BirthDate = new DateTime(1998, 02, 21);
            DateTime registerTime = new DateTime(2020, 01, 01);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, registerTime, name);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group1 = new Group(visitors);
            visitors.Clear();
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group2 = new Group(visitors);
            visitors.Clear();
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group3 = new Group(visitors);
            visitors.Clear();
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            Group group4 = new Group(visitors);
            visitors.Clear();
            visitors.Add(visitor);
            Group group5 = new Group(visitors);
            visitors.Clear();
            List<Group> groups = new List<Group>
            {
                group1,
                group2,
                group3,
                group4,
                group5,
            };
            //act
            @event.SortGroups(new List<Group>());
            //assert
            Assert.AreEqual(groups[0].visitors.Count, group4.visitors.Count);
            Assert.AreEqual(groups[1].visitors.Count, group2.visitors.Count);
            Assert.AreEqual(groups[2].visitors.Count, group1.visitors.Count);
            Assert.AreEqual(groups[3].visitors.Count, group3.visitors.Count);
            Assert.AreEqual(groups[4].visitors.Count, group5.visitors.Count);
        }

    }
}
