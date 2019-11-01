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
                    string query = "Select * FROM customers";
                    SqlCommand cmd = new SqlCommand(query, cn);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customers>();


                            Customers customer = new Customers();

                            customer.id = (int)dr["id"];
                            customer.first_name = (string)dr["first_name"];
                            customer.last_name = (string)dr["last_name"];
                            customer.login = (string)dr["login"];
                            customer.password = (string)dr["password"];
                            customer.city_code = (int)dr["city_code"];

                            

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

        public Customers GetCustomer(int id)
        {
            Customers customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM customers WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customers();

                            customer.id = (int)dr["id"];
                            customer.first_name = (string)dr["first_name"];
                            customer.last_name = (string)dr["last_name"];
                            customer.login = (string)dr["login"];
                            customer.password = (string)dr["password"];
                            customer.city_code = (int)dr["city_code"];
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

        public Customers AddCustomer(Customers customer)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO customers(first_name,last_name,login,password,city_code) values(@first_name,@last_name,@login,@password,@city_code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@first_name", customer.first_name);
                    cmd.Parameters.AddWithValue("@last_name", customer.last_name);
                    cmd.Parameters.AddWithValue("@login", customer.login);
                    cmd.Parameters.AddWithValue("@password", customer.password);
                    cmd.Parameters.AddWithValue("@city_code", customer.city_code);
                    

                    cn.Open();

                    customer.id = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }
        public int UpdateCustomer(Customers customer)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE customers Set first_name=@first_name, last_name=@last_name, login=@login, password=@password, city_code=@city_code WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@id", customer.id);
                    cmd.Parameters.AddWithValue("@first_name", customer.first_name);
                    cmd.Parameters.AddWithValue("@last_name", customer.last_name);
                    cmd.Parameters.AddWithValue("@login", customer.login);
                    cmd.Parameters.AddWithValue("@password", customer.password);
                    cmd.Parameters.AddWithValue("@city_code", customer.city_code);

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

        public int DeleteCustomer(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM customers WHERE id = @id";
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
