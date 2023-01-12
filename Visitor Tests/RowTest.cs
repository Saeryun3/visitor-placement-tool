using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Tests
{
    [TestClass]
    public class RowTest
    {
        [TestMethod]
        public void RemaininingSeatCountTest()
        {
            //arrange
            List<Seat> seats = new List<Seat>();
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());

            //act
            Row row = new Row()
            {
                seats = seats
            };
            var result = row.RemainingSeatCount();
            var expected = 4;
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PlaceVisitorTest()
        {
            //arrange
            List<Seat> seats = new List<Seat>();
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());
            seats.Add(new Seat());

            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            //act
            Row row = new Row()
            {
                seats = seats
            };

            var visitor = new Visitor(birthDate, registerTime, name);

            row.PlaceVisitor(visitor);
            //assert
            Assert.IsTrue(row.RemainingSeatCount() == 3);
            Assert.IsTrue(row.seats.Last().Visitor.Name == "Sam" && row.seats.Last().Visitor.RegisterTime == new DateTime(2023, 12, 10) && row.seats.Last().Visitor.BirthDate == new DateTime(1980, 10, 10));
        }
    }
}
