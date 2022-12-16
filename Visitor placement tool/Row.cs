using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{
    public class Row
    {
        public int seatLimitMax = 10;
        public List<Seat> seats { get; set; }
        public int RowNumber { get; set; }

        public int RemainingSeatCount()
        {
            return this.seatLimitMax - seats.Count;
        }

        public void PlaceVisitor(Visitor visitor)
        {
            Seat seat = new Seat();
            seat.Visitor = visitor;
            seat.SeatNumber = this.seats.Count + 1;
            seat.RowNumber = this.RowNumber;
            this.seats.Add(seat);
        }      
    }
}
