using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_placement_tool
{
    public class Seat
    {
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public Visitor Visitor { get; set; }
    }
}
