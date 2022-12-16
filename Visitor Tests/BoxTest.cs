using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Tests
{
    [TestClass]
    public class BoxTest
    {
        [TestMethod]
        public void HasRowForSeatsMaxRowsTrueTest()
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

            Row row2 = new Row()
            {
                seats = seats
            };

            List<Row> rows = new List<Row>();
            rows.Add(row);
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.HasRowForSeats(10);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasRowForSeatsFalseTest()
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

            List<Row> rows = new List<Row>();
            rows.Add(row);
            rows.Add(row);
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.HasRowForSeats(5);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasRowForSeatsTrueTest()
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

            List<Row> rows = new List<Row>();
            rows.Add(row);
            rows.Add(row);
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.HasRowForSeats(4);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetFirstRowTest()
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

            List<Row> rows = new List<Row>();
            rows.Add(row);
            rows.Add(row);
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.FirstAvailableRow();

            //assert
            Assert.IsTrue(result.Equals(rows[0]));
        }

        [TestMethod]
        public void GetFirstRowTest2()
        {
            //arrange
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
            rows.Add(row2);
            rows.Add(row2);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.FirstAvailableRow();

            //assert
            Assert.IsTrue(result.Equals(rows[1]));
        }

        [TestMethod]
        public void GetRemainingSeatCountTest() 
        {
            //arrange
            List<Seat> seats6 = new List<Seat>();
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());

            Row row = new Row()
            {
                seats = seats6
            };

            List<Row> rows = new List<Row>();
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.RemainingSeatCount();

            //assert
            Assert.IsTrue(result == 24);
        }

        [TestMethod]
        public void CreateRowTest()
        {
            //arrange
            List<Seat> seats6 = new List<Seat>();
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());

            Row row = new Row()
            {
                seats = seats6
            };

            List<Row> rows = new List<Row>();
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            box.CreateRow();

            //assert
            Assert.IsTrue(box.rows.Count == 2);
        }

        [TestMethod]
        public void TotalSeatsTest()
        {
            //arrange
            List<Seat> seats6 = new List<Seat>();
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());
            seats6.Add(new Seat());

            Row row = new Row()
            {
                seats = seats6
            };

            List<Row> rows = new List<Row>();
            rows.Add(row);

            Box box = new Box()
            {
                rows = rows
            };

            //act
            var result = box.TotalSeats();

            //assert
            Assert.IsTrue(result == 6);
        }
    }
}
