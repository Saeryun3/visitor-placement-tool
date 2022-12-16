using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{

    public class VisitorGenerator
    {

        public List<Visitor> GenerateVisitors(int visitorCount, int groupID, DateTime eventdate)
        {
            List<Visitor> visitors = new List<Visitor>();
            for (int i = 1; i <= visitorCount; i++)
            {
                Random random = new Random();
                DateTime start = new DateTime(1950, 1, 1);

                int range = (DateTime.Today - start).Days;

                DateTime dateOfBirth = start.AddDays(random.Next(range));

                range = (eventdate - DateTime.Today).Days;
                DateTime dateOfRegistration = DateTime.Today.AddDays(random.Next(range));

                Visitor visitor = new Visitor(dateOfBirth, dateOfRegistration, "Visitor " + i);
                visitor.GroupID = groupID;
                visitors.Add(visitor);
            }
            return visitors;
        }
    }
}
