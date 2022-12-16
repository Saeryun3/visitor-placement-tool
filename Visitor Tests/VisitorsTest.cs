namespace AlgoritmTests
{
    [TestClass]
    public class VisitorsTest
    {
        [TestMethod]
        public void VisitorConstructorTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";
            //act
            var visitor = new Visitor(birthDate, registerTime, name);
            //assert
            Assert.IsTrue(visitor.BirthDate == birthDate && visitor.RegisterTime == registerTime && visitor.Name == name);
        }
        [TestMethod]
        public void ReachedDeadlineTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 10);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023,12, 21);
            int maxVisitors = 600;

            //act
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var visitor = new Visitor(birthDate, registerTime, name);
            var result = visitor.ReachedDeadline(@event);

            //assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void NotReachedDeadlineTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 20);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023, 12, 19);
            int maxVisitors = 600;

            //act
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var visitor = new Visitor(birthDate, registerTime, name);
            var result = visitor.ReachedDeadline(@event);

            //assert
            Assert.IsFalse(result);
            Assert.IsTrue(visitor.Reason == "Te laat aangemeld");
        }
        [TestMethod]
        public void RegisteredOnDeadlineDateTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 21);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023, 12, 21);
            int maxVisitors = 600;

            //act
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var visitor = new Visitor(birthDate, registerTime, name);
            var result = visitor.ReachedDeadline(@event);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfVisitorIsAdultTest()
        {
            //arrange
            DateTime birthDate = new DateTime(1980, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 21);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023, 12, 21);
            int maxVisitors = 600;

            //act
            var visitor = new Visitor(birthDate, registerTime, name);
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var result = visitor.IsAdultAtEvent(@event);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfVisitorIsNotAdultTest()
        {
            //arrange
            DateTime birthDate = new DateTime(2020, 10, 10);
            DateTime registerTime = new DateTime(2023, 12, 21);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023, 12, 21);
            int maxVisitors = 600;

            //act
            var visitor = new Visitor(birthDate, registerTime, name);
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var result = visitor.IsAdultAtEvent(@event);

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfVisitorIsAdultAtAge12Test()
        {
            //arrange
            DateTime birthDate = new DateTime(2011, 12, 22);
            DateTime registerTime = new DateTime(2023, 12, 21);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023, 12, 21);
            int maxVisitors = 600;

            //act
            var visitor = new Visitor(birthDate, registerTime, name);
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var result = visitor.IsAdultAtEvent(@event);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfVisitorIsNotAdultAtAgeAlmost12Test()
        {
            //arrange
            DateTime birthDate = new DateTime(2011, 12, 23);
            DateTime registerTime = new DateTime(2023, 12, 21);
            string name = "Sam";

            DateTime eventDate = new DateTime(2023, 12, 22);
            DateTime deadline = new DateTime(2023, 12, 21);
            int maxVisitors = 600;

            //act
            var visitor = new Visitor(birthDate, registerTime, name);
            Event @event = new Event(eventDate, deadline, maxVisitors);
            var result = visitor.IsAdultAtEvent(@event);

            //assert
            Assert.IsFalse(result);
        }
    }
}