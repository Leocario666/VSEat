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
        public List<Customer> GetCustomers()
        {
            List<Customer> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM customer";
                    SqlCommand cmd = new SqlCommand(query, cn);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();


                            Customer customer = new Customer();

                            customer.customer_Id = (int)dr["customer_Id"];
                            customer.first_name = (string)dr["first_name"];
                            customer.last_name = (string)dr["last_name"];
                            customer.login = (string)dr["login"];
                            customer.password = (string)dr["password"];
                            customer.address = (string)dr["address"];
                            customer.cityCode = (int)dr["cityCode"];

                            

                            results.Add(customer);
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

        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM customer WHERE customer_Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
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

            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO customer(first_name,last_name,login,password,address,cityCode) values(@first_name,@last_name,@login,@password,@address,@cityCode); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@first_name", customer.first_name);
                    cmd.Parameters.AddWithValue("@last_name", customer.last_name);
                    cmd.Parameters.AddWithValue("@login", customer.login);
                    cmd.Parameters.AddWithValue("@password", customer.password);
                    cmd.Parameters.AddWithValue("@address", customer.address);
                    cmd.Parameters.AddWithValue("@cityCode", customer.cityCode);
                    

                    cn.Open();

                    customer.customer_Id = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }
        
    }
}
