using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CustomerDB : ICustomerDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }
        public CustomerDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which gets a customer by his Id
        // ******************************************************* //
        public Customer GetCustomer(int id)
        {
            // Creation of an object customer
            Customer customer = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM customer WHERE customer_Id = @id";
                    
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    // Open the command
                    cn.Open();

                    // Execute the command
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // The results
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.customer_Id = (int)dr["customer_Id"];
                            customer.first_name = (string)dr["first_name"];
                            customer.last_name = (string)dr["last_name"];
                            customer.login = (string)dr["login"];
                            customer.password = (string)dr["password"];
                            customer.address = (string)dr["address"];
                            customer.cityCode = (int)dr["cityCode"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the customer
            return customer;
        }
        // ******************************************************* //
        // Method which adds a customer
        // ******************************************************* //
        public Customer AddCustomer(Customer customer)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "INSERT INTO customer(first_name,last_name,login,password,address,cityCode) values(@First_name,@Last_name,@login,@password,@address,@cityCode); SELECT SCOPE_IDENTITY()";
                    
                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@First_name", customer.first_name);
                    cmd.Parameters.AddWithValue("@Last_name", customer.last_name);
                    cmd.Parameters.AddWithValue("@login", customer.login);
                    cmd.Parameters.AddWithValue("@password", customer.password);
                    cmd.Parameters.AddWithValue("@address", customer.address);
                    cmd.Parameters.AddWithValue("@cityCode", customer.cityCode);
                    
                    // Open the command
                    cn.Open();

                    // Execute the command
                    customer.customer_Id = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the customer
            return customer;
        }

        
        
    }
}
