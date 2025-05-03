using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MovieTicketManagementSystem.DataLayer;
using MovieTicketManagementSystem.TransferObject;

namespace MovieTicketManagementSystem.BusinessLayer
{
    public class staffData
    {
        private DatabaseLayer dataLayer = new DatabaseLayer();

        public List<StaffDTO> staffDataListData()
        {
            return dataLayer.GetStaffData();
        }
    }
}