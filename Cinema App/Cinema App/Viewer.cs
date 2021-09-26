using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_App
{
    class Viewer
    {
        public int Id { get; set; }
        public string ViewerName { get; set; }
        public string ViewerSurname { get; set; }
        public string SeatNumber { get; set; }
        public string SelectedMovie { get; set; }
    }
}
