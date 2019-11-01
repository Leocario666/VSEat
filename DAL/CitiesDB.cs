using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }

        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Cities> GetCities()
        {
            List<Cities> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM cities";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Cities>();

                            Cities city = new Cities();

                            city.code = (int)dr["code"];
                            city.name = (string)dr["name"];

                            results.Add(city);
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

        public Cities GetCity(int code)
        {

            Cities city = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM cities WHERE code = @code";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@code", code);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            city = new Cities();

                            city.code = (int)dr["code"];
                            city.name = (string)dr["name"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }
    }
}