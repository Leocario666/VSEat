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
        public List<Order> GetOrders(int idCustomer)
        {
            // Create the list
            List<Order> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "Select * FROM [order] WHERE customer_Id=@idCustomer";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@idCustomer", idCustomer);

                    // Open the command
                    cn.Open();

                    // Execute the command
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
                            order.totalPrice = Convert.ToSingle(dr["totalPrice"]);
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (string)dr["delivery_time"];
                            order.customer_Id = (int)dr["customer_Id"];
                            order.delivery_staff_Id = (int)dr["delivery_staff_Id"];

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
                    string query = "SELECT * FROM [order] WHERE order_Id = @order_Id";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@order_Id", order_Id);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
                        if (dr.Read())
                        {
                            order = new Order();

                            order.order_Id = (int)dr["order_Id"];
                            order.status = (string)dr["status"];
                            order.totalPrice = Convert.ToSingle(dr["totalPrice"]);
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (string)dr["delivery_time"];
                            order.customer_Id = (int)dr["customer_Id"];
                            order.delivery_staff_Id = (int)dr["delivery_staff_Id"];
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
        // ****************************************************************** //
        // Method which gets a list of orders by id of delivery Staff
        // ****************************************************************** //
        public List<Order> GetOrders_ds(int delivery_staff_Id)
        {
            // Create the list
            List<Order> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "Select * FROM [order] WHERE delivery_staff_Id=@delivery_staff_Id ORDER BY status DESC, delivery_time ASC";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@delivery_staff_Id", delivery_staff_Id);

                    // Open the command
                    cn.Open();

                    // Execute the command
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
                            order.totalPrice = Convert.ToSingle(dr["totalPrice"]);
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (string)dr["delivery_time"];
                            order.customer_Id = (int)dr["customer_Id"];
                            order.delivery_staff_Id = (int)dr["delivery_staff_Id"];

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
        // ************************************************************** //
        // Method which gets a list of all orders
        // ************************************************************** //
        public List<Order> GetOrders()
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
                    string query = "SELECT * FROM [order]";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    // Open the command
                    cn.Open();

                    // Execute the command
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
                            order.totalPrice = Convert.ToSingle(dr["totalPrice"]);
                            order.created_at = (DateTime)dr["created_at"];
                            order.delivery_time = (string)dr["delivery_time"];
                            order.customer_Id = (int)dr["customer_Id"];
                            order.delivery_staff_Id = (int)dr["delivery_staff_Id"];

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
        // Method which adds an order
        // ******************************************************* //
        public int AddOrder(Order order)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "INSERT INTO [order](delivery_time,customer_Id,totalPrice,delivery_staff_Id) values(@delivery_time,@customer_Id,@totalPRice,@delivery_staff_Id); SELECT SCOPE_IDENTITY()";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@delivery_time", order.delivery_time);
                    cmd.Parameters.AddWithValue("@customer_Id", order.customer_Id);
                    cmd.Parameters.AddWithValue("@totalPrice", order.totalPrice);
                    cmd.Parameters.AddWithValue("@delivery_staff_Id", order.delivery_staff_Id);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    order.order_Id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the order
            return order.order_Id;
        }
        // ******************************************************* //
        // Method which updates an order
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
                    string query = "UPDATE [order] Set status = @status WHERE order_Id = @order_Id";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order.order_Id);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    


                    // Open the command
                    cn.Open();

                    // Execute the command
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
