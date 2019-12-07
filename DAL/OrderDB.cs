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
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }
        public OrderDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which gets a list of orders by his Customer Id
        // ******************************************************* //
        public List<Order> GetOrders(int customer_Id)
        {
            // Creation of the list 
            List<Order> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "Select * FROM order WHERE customer_Id=@customer_Id";

                    // Saving the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@customer_Id", customer_Id);

                    // Open the command
                    cn.Open();

                    // Execute the reader
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
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
            // Return the list
            return results;
        }
        // ******************************************************* //
        // Method which gets an order by his Id
        // ******************************************************* //
        public Order GetOrder(int order_Id)
        {
            // Create an object order
            Order order = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Conexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM order WHERE order_Id = @order_Id";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@order_Id", order_Id);

                    // Open the command
                    cn.Open();

                    // Execute the reader
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
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
            // Return the order
            return order;
        }
        // ******************************************************* //
        // Method which adds an order
        // ******************************************************* //
        public Order AddOrder(Order order)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "INSERT INTO order(delivery_time,customer_Id) values(@delivery_time,@customer_Id); SELECT SCOPE_IDENTITY()";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@delivery_time", order.delivery_time);
                    cmd.Parameters.AddWithValue("@customerId", order.customer_Id);
                   
                    // Open the command
                    cn.Open();

                    order.order_Id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the order
            return order;
        }
        // ******************************************************* //
        // Method which update an order
        // ******************************************************* //
        public int UpdateOrder(Order order)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "UPDATE order Set delivery_time=@delivery_time, status = @status WHERE order_Id = @order_Id";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order.order_Id);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@delivery_time", order.delivery_time);


                    // Open the command
                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the result
            return result;
        }
    }
}
