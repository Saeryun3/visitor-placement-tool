namespace Visitor_placement_tool
{
    public class Visitor
    {
        public int GroupID { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterTime { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }

        public Visitor(DateTime birthDate, DateTime registerTime, string name)
        {
            BirthDate = birthDate;
            RegisterTime = registerTime;
            Name = name;
            Reason = "";
        }

        public bool ReachedDeadline(Event @event)
        {
            if (this.RegisterTime <= @event.Deadline)
            {
                return true;
            }

            Reason = "Te laat aangemeld";
            return false;
        }

        public bool IsAdultAtEvent(Event @event)
        {
            if (@event.EventDate.Year - this.BirthDate.Year > 12)
            {
                return true;
            }
            else if (@event.EventDate.Year - this.BirthDate.Year == 12)
            {
                if (@event.EventDate.Month - this.BirthDate.Month > 0)
                {
                    return true;
                }
                else if (@event.EventDate.Month - this.BirthDate.Month == 0)
                {
                    return @event.EventDate.Day - this.BirthDate.Day >= 0;
                }
                else return false;
            }
            return false;
        }
    }
}