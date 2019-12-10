using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Delivery_staffDB : IDelivery_staffDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        private IConfiguration Configuration { get; }
        public Delivery_staffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // ******************************************************* //
        // Method which controls deliverer's login and password at the connection
        // ******************************************************* //
        public bool isUserValid(Delivery_staff ds)
        {
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // Open the command
                    cn.Open();

                    // The query 
                    string query = "SELECT * FROM delivery_staff WHERE login='" + ds.login + "' and password='" + ds.password + "'";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    // Execute the command
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Control if the data reader can read with the table with the given parameters
                    if (dr.Read())
                    {
                        return true;    //login and password correct
                    }
                    else
                    {
                        return false;   //login or password correct
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // ************************************************************** //
        // Method which gets a list of all deliverers
        // ************************************************************** //
        public List<Delivery_staff> GetDelivery_staffs()
        {
            // Creation of the list 
            List<Delivery_staff> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM delivery_staff";

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
                                results = new List<Delivery_staff>();

                            Delivery_staff ds = new Delivery_staff();

                            ds.delivery_staff_Id = (int)dr["delivery_staff_Id"];
                            ds.first_name = (string)dr["first_name"];
                            ds.last_name = (string)dr["last_name"];
                            ds.login = (string)dr["login"];
                            ds.password = (string)dr["password"];
                            ds.cityCode = (int)dr["cityCode"];

                            results.Add(ds);
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
        // Method which gets a Delivery_Staff by his Id
        // ******************************************************* //
        public Delivery_staff GetDelivery_staff(int id)
        {
            // Creation of an object Delivery_staff
            Delivery_staff Delivery_staff = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "SELECT * FROM delivery_staff WHERE delivery_staff_Id = @id";
                    
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
                            Delivery_staff = new Delivery_staff();

                            Delivery_staff.delivery_staff_Id = (int)dr["delivery_staff_Id"];
                            Delivery_staff.first_name = (string)dr["first_name"];
                            Delivery_staff.last_name = (string)dr["last_name"];
                            Delivery_staff.login = (string)dr["login"];
                            Delivery_staff.password = (string)dr["password"];
                            Delivery_staff.cityCode = (int)dr["cityCode"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            // Return the delivery_Staff
            return Delivery_staff;
        }

    }

}
