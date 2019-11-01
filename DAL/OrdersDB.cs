using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class OrdersDB : IOrdersDB
    {
        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Orders> GetOrders(int idCustomer)
        {
            List<Orders> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM orders WHERE customers_id=@idCustomer";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idCustomer", idCustomer);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();


                            Orders order = new Orders();

                            order.id = (int)dr["id"];
                            order.status = (string)dr["status"];
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (DateTime)dr["delivery_time"];
                            order.customers_id = (int)dr["cusomers_id"];



                            results.Add(order);
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
        public Orders GetOrder(int id)
        {
            Orders order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM orders WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Orders();

                            order.id = (int)dr["id"];
                            order.status = (string)dr["status"];
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (DateTime)dr["delivery_time"];
                            order.customers_id = (int)dr["customers_id"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }
        public Orders AddOrder(Orders order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO orders(delivery_time,customers_id) values(@delivery_time,@customers_id); SELECT SCOPE_IDENTITY()";
                    
                    SqlCommand cmd = new SqlCommand(query, cn);
                             
                    cmd.Parameters.AddWithValue("@delivery_time", order.delivery_time);
                    cmd.Parameters.AddWithValue("@customers_id", order.customers_id);
                   
                    cn.Open();

                    order.id = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Orders order)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE orders Set delivery_time=@delivery_time WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@delivery_time", order.delivery_time);
                    

                    cn.Open();


                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public int DeleteOrder(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM orders WHERE id = @id";
               
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
