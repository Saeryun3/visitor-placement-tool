using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{
    public class Box
    {
        public int maxVisitors = 30;
        public int maxRows = 3;
        public char BoxCode { get; set; }
        public List<Row> rows { get; set; }

        public Row assignedRow { get; set; }


        public bool HasPlaceableRowFor(int seatSize)
        {
            if (rows.Count < maxRows)
            {
                return true;
            }
            else
            {
                foreach (Row row in rows)
                {
                    if (seatSize <= row.RemainingSeatCount())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasPlaceOnFirstRowFor(int seatSize)
        {

            if (seatSize <= this.rows[0].RemainingSeatCount())
            {
                return true;
            }

            return false;
        }

        public void PlaceGroupIntoBox(Group group, Event @event)
        {
            List<Visitor> children = group.ChildsAtEvent(@event);
            List<Visitor> adults = group.AdultsAtEvent(@event);

            //plaats groep met kinderen
            if (children.Count > 0)
            {
                PlaceGroupWithChildren(adults, children);
            }
            //plaats groep volwassen
            else
            {
                PlaceGroupWithOnlyAdults(adults);
            }
        }

        public void PlaceGroupWithChildren(List<Visitor> adults, List<Visitor> children)
        {
            // Plaats eerst 1 volwassene met kinderen op een rij
            bool assignedRowBool = false;

            //zolang er geen aangewezen rij is 
            while (!assignedRowBool)
            {
                assignedRowBool = assigneRow(children, adults);
            }

            // Volwassene die overblijven nadat 1e volwassene en kinderen geplaats zijn
            int remainingAdultCount = adults.Count - 1;

            //Als er nog volwassenen zijn
            if (remainingAdultCount > 0)
            {
                // als er nog plek is voor overgebleven volwassen op aangewezen rij => plaats + vak gekeken

                if (remainingAdultCount <= assignedRow.RemainingSeatCount())
                {
                    for (int i = 1; i <= remainingAdultCount; i++)
                    {
                        assignedRow.PlaceVisitor(adults[i]);
                    }
                }
                else
                {
                    for (int i = 1; i <= remainingAdultCount; i++)
                    {
                        Row availableRow = FirstAvailableRow();
                        availableRow.PlaceVisitor(adults[i]);
                    }
                }
            }
        }

        public void PlaceGroupWithOnlyAdults(List<Visitor> adults)
        {
            bool placedAdults = false;

            foreach (Row row in rows)
            {
                //kijk of groep volwassenen in één rij kan
                if (adults.Count <= row.RemainingSeatCount())
                {
                    foreach (Visitor adult in adults)
                    {
                        row.PlaceVisitor(adult);
                    }

                    placedAdults = true;
                    break;
                }
            }
            //als volwassenen niet in één rij past => plaats visitor in de eerste volgende beschikbare rij 
            if (!placedAdults)
            {
                foreach (Visitor adult in adults)
                {
                    Row availableRow = FirstAvailableRow();
                    availableRow.PlaceVisitor(adult);
                }
            }
        }

        public bool assigneRow(List<Visitor> children, List<Visitor> adults)
        {
            foreach (Row row in rows)
            {
                //als de rij plek heeft voor kinderen en 1 volwassene => plaats 
                if (children.Count + 1 <= row.RemainingSeatCount())
                {
                    //wijs rij toe 
                    assignedRow = row;
                    // Plaats eerste volwassene 
                    Visitor firstAdult = adults[0];
                    assignedRow.PlaceVisitor(firstAdult);

                    // Plaats kinderen
                    foreach (Visitor child in children)
                    {
                        assignedRow.PlaceVisitor(child);
                    }
                    break;
                }

                if (assignedRow == null)
                {
                    CreateRow();
                }
            }

            return true;
        }

        public Row FirstAvailableRow()
        {
            foreach (Row row in this.rows)
            {
                if (row.RemainingSeatCount() > 0)
                {
                    return row;
                }
            }
            // nieuwe rij
            if (this.rows.Count < this.maxRows)
            {
                this.CreateRow();
                return this.FirstAvailableRow();
            }

            return null;
        }
        public int RemainingSeatCount()
        {
            return this.maxVisitors - TotalSeats();
        }

        public void CreateRow()
        {
            Row row = new Row();
            row.RowNumber = this.rows.Count + 1;
            row.seats = new List<Seat>();
            this.rows.Add(row);
        }

        
        

        public int TotalSeats()
        {
            int total = 0;

            foreach (Row row in rows)
            {
                total += row.seats.Count;
            }
            return total;
        }

    }
}