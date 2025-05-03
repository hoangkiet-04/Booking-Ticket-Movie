using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketManagementSystem.TransferObject
{
    public class StaffDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }
}
