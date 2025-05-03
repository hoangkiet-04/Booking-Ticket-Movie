using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieTicketManagementSystem.DataLayer;
using MovieTicketManagementSystem.TransferObject;
namespace MovieTicketManagementSystem.BusinessLayer
{
    public class UserBL
    {
        private DatabaseLayer dataLayer = new DatabaseLayer();

        public UserDTO AuthenticateUser(string username, string password)
        {
            return dataLayer.AuthenticateUser(username, password);
        }

        public bool CheckUsernameExists(string username)
        {
            return dataLayer.CheckUsernameExists(username);
        }

        public void RegisterUser(UserDTO user)
        {
            dataLayer.RegisterUser(user);
        }
    }
}
