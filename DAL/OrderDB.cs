using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class OrderDB : IOrderDB
    {
        public IConfiguration Configuration { get; }
        public OrderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Order> GetOrders(int customer_Id)
        {
            List<Order> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM order WHERE customer_Id=@customer_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@customer_Id", customer_Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();


                            Order order = new Order();

                            order.order_Id = (int)dr["order_Id"];
                            order.status = (string)dr["status"];
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (DateTime)dr["delivery_time"];
                            order.customer_Id = (int)dr["customer_Id"];



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
        public Order GetOrder(int order_Id)
        {
            Order order = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM order WHERE order_Id = @order_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@order_Id", order_Id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.order_Id = (int)dr["order_Id"];
                            order.status = (string)dr["status"];
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (DateTime)dr["delivery_time"];
                            order.customer_Id = (int)dr["customer_Id"];
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
        public Order AddOrder(Order order)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO order(delivery_time,customer_Id) values(@delivery_time,@customer_Id); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@delivery_time", order.delivery_time);
                    cmd.Parameters.AddWithValue("@customerId", order.customer_Id);
                   
                    cn.Open();

                    order.order_Id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE order Set delivery_time=@delivery_time, status = @status WHERE order_Id = @order_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order.order_Id);
                    cmd.Parameters.AddWithValue("@status", order.status);
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
    }
}
