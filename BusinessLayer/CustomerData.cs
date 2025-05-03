using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace MovieTicketManagementSystem.BusinessLayer
{
    public class customerData
    {
        string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\OneDrive\Tài liệu\Movie.mdf"";Integrated Security=True;Connect Timeout=30";

        public int ID { get; set; }
        public string MovieID { get; set; }
        public int SeatNumber { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public float Change { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<customerData> GetCustomerList()
        {
            List<customerData> list = new List<customerData>();

            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string query = "SELECT * FROM buy_tickets WHERE status = 'PAID'";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new customerData
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            MovieID = reader["movie_id"].ToString(),
                            SeatNumber = Convert.ToInt32(reader["seat_number"]),
                            Price = Convert.ToSingle(reader["price"]),
                            Amount = Convert.ToSingle(reader["amount"]),
                            Change = Convert.ToSingle(reader["change"]),
                            Status = reader["status"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["created_at"])
                        });
                    }
                }
            }

            return list;
        }
    }
}