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
        public IConfiguration Configuration { get; }
        public Delivery_staffDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Delivery_staff> GetDelivery_staffs()
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
                    string query = "SELECT * FROM delivery_staff WHERE delivery_staff_Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
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

            return Delivery_staff;
        }

    }

}
