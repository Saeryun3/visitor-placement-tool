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

        public bool HasRowForSeats(int seatSize)
        {
            if(rows.Count < maxRows)
            {
                return true;
            } 
            else
            {
                foreach(Row row in rows)
                {
                    if(seatSize <= row.RemainingSeatCount())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Row FirstAvailableRow()
        {
            foreach(Row row in this.rows)
            {
                if(row.RemainingSeatCount() > 0)
                {
                    return row;
                }
            }
            // nieuwe rij
            if(this.rows.Count < this.maxRows)
            {
                this.CreateRow();
                return this.FirstAvailableRow();
            }

            return null;
        }
        public int RemainingSeatCount()
        {
            int sum = 0;

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