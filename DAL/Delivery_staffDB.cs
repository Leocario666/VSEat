using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Delivery_staffDB
    {
        public IConfiguration Configuration { get; }
        public Delivery_staffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Delivery_staff> GetDelivery_Staffs()
        {
            List<Delivery_staff> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM delivery_staff";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Delivery_staff>();

                            Delivery_staff ds = new Delivery_staff();

                            ds.id = (int)dr["id"];
                            ds.first_name = (string)dr["first_name"];
                            ds.last_name = (string)dr["last_name"];
                            ds.login = (string)dr["login"];
                            ds.password = (string)dr["password"];
                            ds.city_code = (int)dr["code"];
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

        public Delivery_staff GetDelivery_staff(int id)
        {
            Delivery_staff Delivery_staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM delivery_staff WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Delivery_staff = new Delivery_staff();

                            Delivery_staff.id = (int)dr["id"];
                            Delivery_staff.first_name = (string)dr["first_name"];
                            Delivery_staff.last_name = (string)dr["last_name"];
                            Delivery_staff.login = (string)dr["login"];
                            Delivery_staff.password = (string)dr["password"];
                            Delivery_staff.city_code = (int)dr["city_code"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Delivery_staff;
        }

    }

}
