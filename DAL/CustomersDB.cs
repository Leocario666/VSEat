using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CustomersDB : ICustomersDB
    {
        public IConfiguration Configuration { get; }
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Customers> GetCustomers()
        {
            List<Customers> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM Hotels";
                    SqlCommand cmd = new SqlCommand(query, cn);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Hotel>();


                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["idHotel"];
                            hotel.Name = (string)dr["Name"];
                            hotel.Description = (string)dr["Name"];
                            hotel.Location = (string)dr["Location"];
                            hotel.Category = (int)dr["Category"];
                            hotel.HasWifi = (bool)dr["HasWifi"];
                            hotel.HasParking = (bool)dr["HasParking"];

                            if (dr["Phone"] != null)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Email"] != null)
                                hotel.Email = (string)dr["Email"];
                            if (dr["Website"] != null)
                                hotel.Website = (string)dr["Website"];

                            results.Add(hotel);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;

        }
    }
}
