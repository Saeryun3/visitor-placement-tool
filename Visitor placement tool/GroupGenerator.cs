using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{
    public class GroupGenerator
    {
        public static List<Group> Creategroups(int visitors, DateTime eventDate)
        {
            List<Group> groups = new List<Group>();
            int generatedVisitors = 0;
            int groupID = 0;

            // als aangemaakte bezoekers aantal kleiner is dan opgegeven bezoekersaantal => blijf doorgaan
            while (generatedVisitors < visitors)
            {
                int remainingVisitorSize = visitors - generatedVisitors;

                Group group = Generategroup(remainingVisitorSize, groupID, eventDate);
                generatedVisitors += group.visitors.Count();


                groups.Add(group);
                groupID++;
            }

            return groups;
        }
        private static Group Generategroup(int remainingVisitorSize, int groupID, DateTime eventdate)
        {
            Random random = new Random();
            int visitorLimit = 10;

            // Limiteer bezoekers van een groep
            if (remainingVisitorSize < 10)
            {
                visitorLimit = remainingVisitorSize;
            }

            VisitorGenerator generator = new VisitorGenerator();
            Group group = new Group(generator.GenerateVisitors(random.Next(1, visitorLimit + 1), groupID, eventdate));
            group.GroupID = groupID;
            return group;
        }
    }
}