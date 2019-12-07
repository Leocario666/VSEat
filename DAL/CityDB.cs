using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public class CityDB : ICityDB
    {
        private string connectionString = "Server=153.109.124.35;Database=DNVSEatDB;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";
        public IConfiguration Configuration { get; }

        public CityDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<City> GetCities()
        {
            List<City> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM city";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City city = new City();

                            city.cityCode = (int)dr["code"];
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

        public City GetCity(int code)
        {

            City city = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM city WHERE cityCode = @code";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@code", code);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            city = new City();

                            city.cityCode = (int)dr["cityCode"];
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