using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketManagementSystem.TransferObject
{
    public class MovieDTO
    {
        public int ID { get; set; }
        public string MovieID { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Price { get; set; }
        public string Capacity { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
    }
}
