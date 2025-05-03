using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MovieTicketManagementSystem.TransferObject;
namespace MovieTicketManagementSystem.DataLayer
{
    public class DatabaseLayer
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\OneDrive\Tài liệu\Movie.mdf"";Integrated Security=True;Connect Timeout=30";

        public UserDTO AuthenticateUser(string username, string password)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT * FROM users WHERE username = @usern AND password = @pass";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                            {
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Role = reader["role"].ToString(),
                                Status = reader["status"].ToString(),
                                DateReg = Convert.ToDateTime(reader["date_reg"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool CheckUsernameExists(string username)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string checkUsername = "SELECT COUNT(*) FROM users WHERE username = @usern";
                using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void RegisterUser(UserDTO user)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string insertData = "INSERT INTO users (username, password, role, status, date_reg) VALUES(@usern, @pass, @role, @status, @date)";
                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                {
                    cmd.Parameters.AddWithValue("@usern", user.Username);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@status", user.Status);
                    cmd.Parameters.AddWithValue("@date", user.DateReg);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<MovieDTO> GetMovieData()
        {
            List<MovieDTO> listData = new List<MovieDTO>();
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT * FROM Movie WHERE delete_date IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listData.Add(new MovieDTO
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            MovieID = reader["movie_id"].ToString(),
                            MovieName = reader["movie_name"].ToString(),
                            Genre = reader["genre"].ToString(),
                            Price = reader["price"].ToString(),
                            Capacity = reader["capacity"].ToString(),
                            Status = reader["status"].ToString(),
                            Image = reader["movie_image"].ToString(),
                            Date = reader["created_at"].ToString()
                        });
                    }
                }
            }
            return listData;
        }

        public List<MovieDTO> GetAvailableMovieData()
        {
            List<MovieDTO> listData = new List<MovieDTO>();
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT * FROM Movie WHERE status = 'Available' AND delete_date IS NULL";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listData.Add(new MovieDTO
                        {
                            ID = Convert.ToInt32(reader["id"]),
                            MovieID = reader["movie_id"].ToString(),
                            MovieName = reader["movie_name"].ToString(),
                            Genre = reader["genre"].ToString(),
                            Price = reader["price"].ToString(),
                            Capacity = reader["capacity"].ToString(),
                            Status = reader["status"].ToString(),
                            Image = reader["movie_image"].ToString(),
                            Date = reader["created_at"].ToString()
                        });
                    }
                }
            }
            return listData;
        }

        public List<StaffDTO> GetStaffData()
        {
            List<StaffDTO> listData = new List<StaffDTO>();
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT * FROM users WHERE role = 'Staff' AND status != 'Deleted'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listData.Add(new StaffDTO
                        {
                            ID = (int)reader[0],
                            Username = reader[1].ToString(),
                            Password = reader[2].ToString(),
                            Role = reader[3].ToString(),
                            Status = reader[4].ToString()
                        });
                    }
                }
            }
            return listData;
        }

        public int GetAvailableMoviesCount()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT COUNT(id) as avMovie FROM Movie WHERE status = 'Available'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["avMovie"] != DBNull.Value)
                        {
                            return Convert.ToInt32(reader["avMovie"]);
                        }
                    }
                }
            }
            return 0;
        }

        public int GetTotalStaffsCount()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT COUNT(id) as totalStaff FROM users WHERE role = 'Staff' AND status = 'Active'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["totalStaff"] != DBNull.Value)
                        {
                            return Convert.ToInt32(reader["totalStaff"]);
                        }
                    }
                }
            }
            return 0;
        }

        public int GetTotalBuysCount()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT COUNT(id) as totalBuys FROM buy_tickets WHERE status = 'PAID'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["totalBuys"] != DBNull.Value)
                        {
                            return Convert.ToInt32(reader["totalBuys"]);
                        }
                    }
                }
            }
            return 0;
        }

        public decimal GetTotalIncome()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT SUM(price) as totalIncome FROM buy_tickets WHERE status = 'PAID'";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["totalIncome"] != DBNull.Value)
                        {
                            return Convert.ToDecimal(reader["totalIncome"]);
                        }
                    }
                }
            }
            return 0;
        }
    }
}