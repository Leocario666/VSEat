using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class Order_dishesDB : IOrder_dishesDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }
        public Order_dishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which gets a list of Order_dishes by Id order
        // ******************************************************* //
        public List<Order_dishes> GetOrders_dishes(int order_Id)
        {
            // Creation of the list
            List<Order_dishes> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "Select * FROM order_dishes WHERE order_Id=@order_Id";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order_Id);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_dishes>();


                            Order_dishes order_dishes = new Order_dishes();

                            order_dishes.order_Id = (int)dr["order_Id"];
                            order_dishes.dish_Id = (int)dr["dish_Id"];
                            order_dishes.quantity = (int)dr["quantity"];
                            order_dishes.price = Convert.ToSingle(dr["price"]);
                            

                            results.Add(order_dishes);
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
        // Method which gets an Order dishes by his primary key
        // ******************************************************* //
        public Order_dishes GetOrder_dishes(int order_Id, int dish_Id)
        {
            // Create an object order_dishes
            Order_dishes order_dishes = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM order_dishes WHERE order_Id = @order_Id AND dish_Id = @dish_Id";
                    
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@order_Id", order_Id);
                    cmd.Parameters.AddWithValue("@dish_Id", dish_Id);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
                        if (dr.Read())
                        {
                            order_dishes = new Order_dishes();

                            order_dishes.order_Id = (int)dr["order_Id"];
                            order_dishes.dish_Id = (int)dr["dish_Id"];
                            order_dishes.quantity = (int)dr["quantity"];
                            order_dishes.price = Convert.ToSingle(dr["price"]);
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the object
            return order_dishes;
        }

        // ************************************************************** //
        // Method which gets a list of all order_dishes
        // ************************************************************** //
        public List<Order_dishes> GetAllOrders_dishes()
        {
            // Creation of the list 
            List<Order_dishes> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM order_dishes";

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
                                results = new List<Order_dishes>();

                            Order_dishes order_dishes = new Order_dishes();

                            order_dishes.order_Id = (int)dr["order_Id"];
                            order_dishes.dish_Id = (int)dr["dish_Id"];
                            order_dishes.quantity = (int)dr["quantity"];
                            order_dishes.price = Convert.ToSingle(dr["price"]);

                            results.Add(order_dishes);
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
        // Method which adds an order dishes
        // ******************************************************* //
        public Order_dishes AddOrder_dishes(Order_dishes order_dishes)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "INSERT INTO order_dishes(order_Id,dish_Id,quantity,price) values(@order_Id,@dish_Id,@quantity,@price);";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order_dishes.order_Id);
                    cmd.Parameters.AddWithValue("@dish_Id", order_dishes.dish_Id);
                    cmd.Parameters.AddWithValue("@quantity", order_dishes.quantity);
                    cmd.Parameters.AddWithValue("@price", order_dishes.price);
                    

                    // Open the command
                    cn.Open();

                    // Execute the command
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the object
            return order_dishes;
        }
        // ******************************************************* //
        // Method which updates an order dishes
        // ******************************************************* //
        public int UpdateOrder_dishes(Order_dishes order_dishes)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "UPDATE order_dishes Set quantity=@quantity, price=@price WHERE order_Id = @order_Id AND dish_Id = @dish_Id";
                   
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order_dishes.order_Id);
                    cmd.Parameters.AddWithValue("@dish_Id", order_dishes.dish_Id);
                    cmd.Parameters.AddWithValue("@quantity", order_dishes.quantity);
                    cmd.Parameters.AddWithValue("@price", order_dishes.price);
                    

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