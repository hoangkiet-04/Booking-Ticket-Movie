using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovieTicketManagementSystem.DataLayer;

namespace MovieTicketManagementSystem.BusinessLayer
{
    public class DashboardBL
    {
        private DatabaseLayer dataLayer = new DatabaseLayer();

        public int GetAvailableMoviesCount()
        {
            return dataLayer.GetAvailableMoviesCount();
        }

        public int GetTotalStaffsCount()
        {
            return dataLayer.GetTotalStaffsCount();
        }

        public int GetTotalBuysCount()
        {
            return dataLayer.GetTotalBuysCount();
        }

        public decimal GetTotalIncome()
        {
            return dataLayer.GetTotalIncome();
        }
    }
}
