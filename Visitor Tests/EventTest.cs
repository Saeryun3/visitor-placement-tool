using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_placement_tool;

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
            DateTime BirthDate = new DateTime(2020, 02, 21);
            DateTime registerTime = new DateTime(2020, 01, 01);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, registerTime, name);
            List<Visitor> visitorsCount5 = new List<Visitor>();
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);

            List<Visitor> visitorsCount2 = new List<Visitor>();
            visitorsCount2.Add(visitor);
            visitorsCount2.Add(visitor);

            List<Visitor> visitorsCount6 = new List<Visitor>();
            visitorsCount6.Add(visitor);
            visitorsCount6.Add(visitor);
            visitorsCount6.Add(visitor);
            visitorsCount6.Add(visitor);
            visitorsCount6.Add(visitor);
            visitorsCount6.Add(visitor);

            List<Visitor> visitorsCount4 = new List<Visitor>();
            visitorsCount4.Add(visitor);
            visitorsCount4.Add(visitor);
            visitorsCount4.Add(visitor);
            visitorsCount4.Add(visitor);

            List<Visitor> visitorsCount1 = new List<Visitor>();
            visitorsCount1.Add(visitor);

            Group group1 = new Group(visitorsCount4);
            Group group2 = new Group(visitorsCount6);
            Group group3 = new Group(visitorsCount2);
            Group group4 = new Group(visitorsCount5);
            Group group5 = new Group(visitorsCount1);


            List<Group> groups = new List<Group>
            {
                group1,
                group2,
                group3,
                group4,
                group5,
            };
            //act
            @event.SortGroups(ref groups);
            //assert
            Assert.AreEqual(groups[0].visitors.Count, group2.visitors.Count);
            Assert.AreEqual(groups[1].visitors.Count, group4.visitors.Count);
            Assert.AreEqual(groups[2].visitors.Count, group1.visitors.Count);
            Assert.AreEqual(groups[3].visitors.Count, group3.visitors.Count);
            Assert.AreEqual(groups[4].visitors.Count, group5.visitors.Count);
        }

        [TestMethod]
        public void GetAssignedBoxTest()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            DateTime BirthDate = new DateTime(2020, 02, 21);
            DateTime registerTime = new DateTime(2020, 01, 01);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, registerTime, name);
            List<Visitor> visitorsCount5 = new List<Visitor>();
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);

            Group group = new Group(visitorsCount5);
            
            List<Seat> seats6 = new List<Seat>();
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            List<Seat> seats10 = new List<Seat>();
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());


            //act
            Row row = new Row()
            {
                seats = seats10
            };

            Row row2 = new Row()
            {
                seats = seats6
            };

            List<Row> rows = new List<Row>();
            rows.Add(row);
            rows.Add(row);
            rows.Add(row);

            List<Row> rows1 = new List<Row>();
            rows.Add(row2);
            rows.Add(row2);
            rows.Add(row);

            //heeft geen plek
            Box box1 = new Box()
            {
                rows = rows
            };

            //heeft 8 plekken
            Box box2 = new Box()
            {
                rows = rows1
            };

            List<Box> boxes = new List<Box>();
            boxes.Add(box1);
            boxes.Add(box2);

            @event.boxes = boxes;

            //act
            var result = @event.GetAssignedBox(group);
            var expected = box2;

            //assert
            Assert.IsTrue(result.Equals(expected));
        }

        [TestMethod]
        public void GetAssignedBoxWithOnlyFullBoxesTest()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            DateTime BirthDate = new DateTime(2020, 02, 21);
            DateTime registerTime = new DateTime(2020, 01, 01);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, registerTime, name);
            List<Visitor> visitorsCount5 = new List<Visitor>();
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);
            visitorsCount5.Add(visitor);

            Group group = new Group(visitorsCount5);
            List<Seat> seats10 = new List<Seat>();
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());
            seats10.Add(new Seat());


            //act
            Row row = new Row()
            {
                seats = seats10
            };

            List<Row> rows = new List<Row>();
            rows.Add(row);
            rows.Add(row);
            rows.Add(row);

            //heeft geen plek
            Box box = new Box()
            {
                rows = rows
            };

            List<Box> boxes = new List<Box>();
            boxes.Add(box);
            boxes.Add(box);

            @event.boxes = boxes;

            //act
            var result = @event.GetAssignedBox(group);
            var expected = @event.boxes[2];

            //assert
            Assert.IsTrue(result.Equals(expected));
        }

        [TestMethod]
        public void FilterAllowedVisitorsTest()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            DateTime BirthDate = new DateTime(1990, 02, 21);
            DateTime OnTimeRegistered = new DateTime(2020, 01, 01);
            DateTime ToLateRegistered = new DateTime(2023, 12, 12);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, OnTimeRegistered, name);
            Visitor visitor2 = new Visitor(BirthDate, ToLateRegistered, name);
            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor2);
            visitors.Add(visitor2);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);

            List<Visitor> visitors2 = new List<Visitor>();
            visitors2.Add(visitor2);
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);

            Group group = new Group(visitors);
            Group group2 = new Group(visitors2);

            List<Group> groups = new List<Group>();
            groups.Add(group);
            groups.Add(group2);

            //act
            @event.FilterAllowedVisitors(groups);
            int expected = 7;
            int result = @event.AllowedVisitors.Count;

            //assert
            Assert.AreEqual(expected, result);  
        }

        [TestMethod]
        public void FilterRejectedFilters()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 100;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            DateTime BirthDate = new DateTime(1990, 02, 21);
            DateTime OnTimeRegistered = new DateTime(2020, 01, 01);
            DateTime ToLateRegistered = new DateTime(2023, 12, 12);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, OnTimeRegistered, name);
            Visitor visitor2 = new Visitor(BirthDate, ToLateRegistered, name);
            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor2);
            visitors.Add(visitor2);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);

            List<Visitor> visitors2 = new List<Visitor>();
            visitors2.Add(visitor2);
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);

            Group group = new Group(visitors);
            Group group2 = new Group(visitors2);

            List<Group> groups = new List<Group>();
            groups.Add(group);
            groups.Add(group2);

            //act
            @event.FilterRejectedVisitors(groups);
            int expected = 3;
            int result = @event.RejectedVisitors.Count;

            //assert
            Assert.AreEqual(expected, result);
            foreach(var visitorItem in @event.RejectedVisitors)
            {
                Assert.IsTrue(visitorItem.Reason == "Te laat aangemeld");
            }
        }

        [TestMethod]
        public void RejectOverbookedVisitors()
        {
            //arrange
            DateTime eventDate = new DateTime(2023, 12, 21);
            DateTime deadline = new DateTime(2023, 12, 11);
            int maximumVisitorsAllowed = 7;
            Event @event = new Event(eventDate, deadline, maximumVisitorsAllowed);
            DateTime BirthDate = new DateTime(1990, 02, 21);
            DateTime OnTimeRegistered = new DateTime(2020, 01, 01);
            string name = "Hans";
            Visitor visitor = new Visitor(BirthDate, OnTimeRegistered, name);
            List<Visitor> visitors = new List<Visitor>();
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);
            visitors.Add(visitor);

            List<Visitor> visitors2 = new List<Visitor>();
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);
            visitors2.Add(visitor);

            Group group = new Group(visitors);
            Group group2 = new Group(visitors2);

            List<Group> groups = new List<Group>();
            groups.Add(group);
            groups.Add(group2);


            //act
            @event.FilterAllowedVisitors(groups);
            @event.RejectOverbookedVisitors(groups);

            var expected = 3;
            var result = @event.RejectedVisitors.Count;

            //Assert
            Assert.AreEqual(expected, result);
            foreach (var visitorItem in @event.RejectedVisitors)
            {
                Assert.IsTrue(visitorItem.Reason == "Overboekt");
            }
        }

    }
}
