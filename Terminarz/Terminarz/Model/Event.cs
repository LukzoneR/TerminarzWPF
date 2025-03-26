using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminarz.Model
{
    class Event
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
    }
}
