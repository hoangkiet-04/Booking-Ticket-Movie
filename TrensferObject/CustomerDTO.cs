using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketManagementSystem.TransferObject
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTime DateReg { get; set; }
     
    }
}