using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    class Order_dishesDB : IOrder_dishesDB
    {
        public IConfiguration Configuration { get; }
        public Order_dishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Order_dishes> GetOrders_dishes(int order_id)
        {
            
        }

        public Order_dishes GetOrder_dishes(int order_id, int dishes_id)
        {
            Order_dishes order_dishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM order_dishes WHERE order_id = @order_id AND dishes_id = @dishes_id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@dishes_id", dishes_id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hotel = new Hotel();

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
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }

        public Order_dishes AddOrder_dishes(Order_dishes Order_dishes)
        {
            
        }

        public int UpdateOrder_dishes(Order_dishes Order_dishes)
        {
            
        }

        public int DeleteOrder_dishes(int order_id, int dishes_id)
        {
            
        }

    }
}
