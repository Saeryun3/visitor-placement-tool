using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{
    public class Group
    {
        public int GroupID { get; set; }
        public List<Visitor> visitors { get; set; }
        public Group(List<Visitor> visitors)
        {
            this.visitors = visitors;
        }

        public List<Visitor> AdultsAtEvent(Event @event)
        {
            List<Visitor> adults = new List<Visitor>();

            foreach (Visitor visitor in visitors)
            {
                if (visitor.IsAdultAtEvent(@event))
                {
                    adults.Add(visitor);
                }
            }
            return adults;
        }

        public List<Visitor> ChildsAtEvent(Event @event)
        {
            List<Visitor> childs = new List<Visitor>();

            foreach (Visitor visitor in visitors)
            {
                if (!visitor.IsAdultAtEvent(@event))
                {
                    childs.Add(visitor);
                }
            }
            return childs;
        }

        public List<Visitor> AllowedVisitors(Event @event)
        {
            List<Visitor> allowedVisitors = new List<Visitor>();

            bool hasAllowedAdult = false;

            foreach (Visitor visitor in visitors)
            {
                if (visitor.ReachedDeadline(@event) && visitor.IsAdultAtEvent(@event))
                {
                    hasAllowedAdult = true;
                }
            }

            if (hasAllowedAdult)
            {
                foreach (Visitor visitor in visitors)
                {
                    if (visitor.ReachedDeadline(@event))
                    {
                        allowedVisitors.Add(visitor);
                    }
                }
            }
            return allowedVisitors;
        }

        public List<Visitor> RejectedVisitors(Event @event)
        {
            List<Visitor> rejectedVisitors = new List<Visitor>();

            foreach (Visitor visitor in visitors)
            {
                if (!AllowedVisitors(@event).Contains(visitor))
                {
                    rejectedVisitors.Add(visitor);
                }
            }
            return rejectedVisitors;
        }
    }
}