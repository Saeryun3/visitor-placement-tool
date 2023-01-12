using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{
    public class Event
    {
        public DateTime EventDate { get; set; }
        public DateTime Deadline { get; set; }
        public List<Box> boxes { get; set; }
        public int MaximumVisitorsAllowed { get; set; }

        public List<Visitor> AllowedVisitors = new List<Visitor>();
        public List<Visitor> RejectedVisitors = new List<Visitor>();

        public Event(DateTime eventDate, DateTime deadline, int maximumVisitorsAllowed)
        {
            boxes = new List<Box>();
            EventDate = eventDate;
            Deadline = deadline;
            MaximumVisitorsAllowed = maximumVisitorsAllowed;
        }

        //public void CreateBox()
        //{
        //    Box box = new Box();
        //    box.rows = new List<Row>();
        //    box.CreateRow();
        //    box.BoxCode = this.GetNextBoxCode();
        //    this.boxes.Add(box);
        //}

        //public char GetNextBoxCode()
        //{
        //    if (boxes.Count > 0)
        //    {
        //        char boxCode = boxes.Last().BoxCode;
        //        return (char)((int)boxCode + 1);
        //    }
        //    else
        //    {
        //        return 'A';
        //    }
        //}

        public int TotalSeats()
        {
            int total = 0;

            foreach (Box box in boxes)
            {
                total += box.TotalSeats();
            }
            return total;
        }

        public void CreateBox()
        {
            Box box = new Box();
            box.rows = new List<Row>();
            box.CreateRow();
            box.BoxCode = GetNextBoxCode();
            boxes.Add(box);
        }

        public char GetNextBoxCode()
        {
            if (boxes.Count > 0)
            {
                char boxCode = boxes.Last().BoxCode;
                return (char)((int)boxCode + 1);
            }
            else
            {
                return 'A';
            }
        }

        public void PlaceGroups(List<Group> groups, Event @event)
        {
            foreach (Group group in groups)
            {
                //kijk in welke vak de groep geplaatst moet worden en plaats deze vervolgens in deze vak
                GetAssignedBox(group, @event).PlaceGroupIntoBox(group, this);
            }
        }

        public Box GetAssignedBox(Group group, Event @event)
        {
            // Als er geen toegewezen vak is, maak nieuwe aan en wijs toe;
            if (boxes.Count == 0)
            {
                CreateBox();
                return boxes.Last();
            }
            else
            {
                foreach (Box box in boxes)
                {
                    // Kijk of bezoekers van de groep passen in deze vak
                    if (group.visitors.Count <= box.RemainingSeatCount())
                    {
                        List<Visitor> children = group.ChildsAtEvent(@event);

                        //alleen als er volwassen zijn.
                        if (children.Count == 0)
                        {
                            return box;
                        }
                        // als er kinderen zijn
                        else
                        {
                            // kijkt of er minimaal 1 volwassene met de kinderen op een rij geplaats kan worden
                            if (box.HasPlaceOnFirstRowFor(children.Count + 1))
                            {
                                // Wijs toe en stop met loop
                                return box;
                            }
                        }
                    }
                }

                // Als er geen vak is toegewezen, maak nieuwe vak.
                CreateBox();
                return boxes.Last();
            }
        }
        

        public void SortGroups(ref List<Group> groups)
        {
            // Filter lege groepen voor het plaatsen
            groups = groups.Where(group => group.visitors.Count > 0).ToList();

            // Sorteren op grootste groep
            groups = groups.OrderByDescending(group => group.ChildsAtEvent(this).Count).ToList();
        }

        //public Box GetAssignedBox(Group group)
        //{
        //    // Als er geen toegewezen vak is, maak nieuwe aan en wijs toe;
        //    if (this.boxes.Count == 0)
        //    {
        //        this.CreateBox();
        //        return this.boxes.Last();
        //    }
        //    else
        //    {
        //        foreach (Box box in this.boxes)
        //        {
        //            // Kijk of bezoekers van de groep passen in deze vak
        //            if (group.visitors.Count <= box.RemainingSeatCount())
        //            {
        //                List<Visitor> children = group.ChildsAtEvent(this);

        //                //alleen als er volwassen zijn.
        //                if (children.Count == 0)
        //                {
        //                    return box;
        //                }
        //                // als er kinderen zijn
        //                else
        //                {
        //                    // kijkt of er minimaal 1 volwassene met de kinderen op een rij geplaats kan worden
        //                    if (box.HasPlaceOnFirstRowFor(children.Count + 1))
        //                    {
        //                        // Wijs toe en stop met loop
        //                        return box;
        //                    }
        //                }
        //            }
        //        }

        //        // Als er geen vak is toegewezen, maak nieuwe vak.
        //        this.CreateBox();
        //        return this.boxes.Last();
        //    }
        //}

       
        //    foreach (Group group in groups)
        ////TODO: Unit test
        //    {
        //        Box assignedBox = this.GetAssignedBox(group);
        //        List<Visitor> children = group.ChildsAtEvent(this);
        //        List<Visitor> adults = group.AdultsAtEvent(this);

        //        //plaats groep met kinderen
        //        if (children.Count > 0)
        //        {
        //            // Plaats eerst 1 volwassene met kinderen op een rij
        //            Row assignedRow = null;

        //            //zolang er geen aangewezen rij is 
        //            while (assignedRow == null)
        //            {
        //                //voor elke rij in aangewezen vak 
        //                foreach (Row row in assignedBox.rows)
        //                {
        //                    //als de rij plek heeft voor kinderen en 1 volwassene => plaats 
        //                    if (children.Count + 1 <= row.RemainingSeatCount())
        //                    {
        //                        //wijs rij toe 
        //                        assignedRow = row;
        //                        // Plaats eerste volwassene 
        //                        Visitor firstAdult = adults[0];
        //                        assignedRow.PlaceVisitor(firstAdult);

        //                        // Plaats kinderen
        //                        foreach (Visitor child in children)
        //                        {
        //                            assignedRow.PlaceVisitor(child);
        //                        }
        //                        break;
        //                    }
        //                }

        //                if (assignedRow == null)
        //                {
        //                    assignedBox.CreateRow();
        //                }
        //            }

        //            // Volwassene die overblijven nadat 1e volwassene en kinderen geplaats zijn
        //            int remainingAdultCount = adults.Count - 1;

        //            //Als er nog volwassenen zijn
        //            if (remainingAdultCount > 0)
        //            {
        //                // als er nog plek is voor overgebleven volwassen op aangewezen rij => plaats + vak gekeken

        //                if (remainingAdultCount <= assignedRow.RemainingSeatCount())
        //                {
        //                    for (int i = 1; i <= remainingAdultCount; i++)
        //                    {
        //                        assignedRow.PlaceVisitor(adults[i]);
        //                    }
        //                }
        //                else
        //                {
        //                    for (int i = 1; i <= remainingAdultCount; i++)
        //                    {
        //                        Row availableRow = assignedBox.FirstAvailableRow();
        //                        availableRow.PlaceVisitor(adults[i]);
        //                    }
        //                }
        //            }
        //        }
        //        //plaats groep volwassen
        //        else
        //        {

        //            bool placedAdults = false;

        //            foreach (Row row in assignedBox.rows)
        //            {
        //                //kijk of groep volwassenen in één rij kan
        //                if (adults.Count <= row.RemainingSeatCount())
        //                {
        //                    foreach (Visitor adult in adults)
        //                    {
        //                        row.PlaceVisitor(adult);
        //                    }

        //                    placedAdults = true;
        //                    break;
        //                }
        //            }
        //            //als volwassenen niet in één rij past => plaats visitor in de eerste volgende beschikbare rij 
        //            if (!placedAdults)
        //            {
        //                foreach (Visitor adult in adults)
        //                {
        //                    Row availableRow = assignedBox.FirstAvailableRow();
        //                    availableRow.PlaceVisitor(adult);
        //                }
        //            }
        //        }
        //    }


        public void FilterAllowedVisitors(List<Group> groups)
        {
            foreach (Group group in groups)
            {
                foreach (Visitor visitor in group.AllowedVisitors(this))
                {
                    AllowedVisitors.Add(visitor);
                }
            }
        }
        public void FilterRejectedVisitors(List<Group> groups)
        {
            foreach (Group group in groups)
            {
                foreach (Visitor visitor in group.RejectedVisitors(this))
                {
                    bool hasAllowedAdult = false;

                    foreach (Visitor visitor2 in group.visitors)
                    {
                        if (visitor2.ReachedDeadline(this) && visitor2.IsAdultAtEvent(this))
                        {
                            hasAllowedAdult = true;
                        }
                    }

                    if (group.AdultsAtEvent(this).Count == 0 || !hasAllowedAdult)
                    {
                        visitor.Reason = "Alleen kinderen niet toegestaan";
                    }

                    group.visitors.Remove(visitor);
                    RejectedVisitors.Add(visitor);
                }
            }
        }
        public void RejectOverbookedVisitors(List<Group> groups)
        {
            if (AllowedVisitors.Count > this.MaximumVisitorsAllowed)
            {
                //sorteer visitors op basis van laatst aangemeld om ze te verwijderen bij overboeking
                AllowedVisitors.OrderByDescending(visitor => visitor.RegisterTime);

                for (int i = 0; AllowedVisitors.Count > this.MaximumVisitorsAllowed; i++)
                {
                    Visitor visitor = AllowedVisitors[0];

                    visitor.Reason = "Overboekt";

                    foreach (Group group in groups)
                    {
                        if (group.GroupID == visitor.GroupID)
                        {
                            group.visitors.Remove(visitor);
                        }
                    }
                    // verwijder overboeking
                    AllowedVisitors.Remove(visitor);
                    RejectedVisitors.Add(visitor);
                }
            }
        }
    }
}