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
        public IConfiguration Configuration { get; }
        public Order_dishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Order_dishes> GetOrders_dishes(int order_Id)
        {
            List<Order_dishes> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM order_dishes WHERE order_Id=@order_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order_Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_dishes>();


                            Order_dishes order_dishes = new Order_dishes();

                            order_dishes.order_Id = (int)dr["order_Id"];
                            order_dishes.dish_Id = (int)dr["dish_Id"];
                            order_dishes.quantity = (int)dr["quantity"];
                            order_dishes.price = Convert.ToSingle(dr["price"]);
                            order_dishes.delivery_staff_Id = (int)dr["delivery_staff_Id"];

                            results.Add(order_dishes);
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

        public List<Order_dishes> GetOrders_dishes_ds(int delivery_staff_Id)
        {
            List<Order_dishes> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * FROM order_dishes WHERE delivery_staff_Id=@delivery_staff_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@delivery_staff_Id", delivery_staff_Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_dishes>();


                            Order_dishes order_dishes = new Order_dishes();

                            order_dishes.order_Id = (int)dr["order_Id"];
                            order_dishes.dish_Id = (int)dr["dish_Id"];
                            order_dishes.quantity = (int)dr["quantity"];
                            order_dishes.price = Convert.ToSingle(dr["price"]);
                            order_dishes.delivery_staff_Id = (int)dr["delivery_staff_Id"];

                            results.Add(order_dishes);
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

        public Order_dishes GetOrder_dishes(int order_Id, int dish_Id)
        {
            Order_dishes order_dishes = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM order_dishes WHERE order_Id = @order_Id AND dish_Id = @dish_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@order_Id", order_Id);
                    cmd.Parameters.AddWithValue("@dish_Id", dish_Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order_dishes = new Order_dishes();

                            order_dishes.order_Id = (int)dr["order_Id"];
                            order_dishes.dish_Id = (int)dr["dish_Id"];
                            order_dishes.quantity = (int)dr["quantity"];
                            order_dishes.price = Convert.ToSingle(dr["price"]);
                            order_dishes.delivery_staff_Id = (int)dr["delivery_staff_Id"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order_dishes;
        }

        public Order_dishes AddOrder_dishes(Order_dishes order_dishes)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO order_dishes(order_Id,dish_Id,quantity,price,delivery_staff_Id) values(@order_Id,@dish_Id,@quantity,@price,@delivery_staff_Id);";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order_dishes.order_Id);
                    cmd.Parameters.AddWithValue("@dish_Id", order_dishes.dish_Id);
                    cmd.Parameters.AddWithValue("@quantity", order_dishes.quantity);
                    cmd.Parameters.AddWithValue("@price", order_dishes.price);
                    cmd.Parameters.AddWithValue("@delivery_staff_Id", order_dishes.delivery_staff_Id);

                    cn.Open();

                    cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order_dishes;
        }

        public int UpdateOrder_dishes(Order_dishes order_dishes)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE order_dishes Set quantity=@quantity, price=@price, delivery_staff_Id=@delivery_staff_Id WHERE order_Id = @order_Id AND dish_Id = @dish_Id";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@order_Id", order_dishes.order_Id);
                    cmd.Parameters.AddWithValue("@dish_Id", order_dishes.dish_Id);
                    cmd.Parameters.AddWithValue("@quantity", order_dishes.quantity);
                    cmd.Parameters.AddWithValue("@price", order_dishes.price);
                    cmd.Parameters.AddWithValue("@delivery_staff_Id", order_dishes.delivery_staff_Id);

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