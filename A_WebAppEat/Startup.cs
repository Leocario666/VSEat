using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace A_WebAppEat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession();

            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerDB, CustomerDB>();
            services.AddScoped<IDelivery_staffManager, Delivery_staffManager>();
            services.AddScoped<IDelivery_staffDB, Delivery_staffDB>();
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IRestaurantDB, RestaurantDB>();
            services.AddScoped<IDishManager, DishManager>();
            services.AddScoped<IDishDB, DishDB>();
            services.AddScoped<IOrder_dishesManager, Order_dishesManager>();
            services.AddScoped<IOrder_dishesDB, Order_dishesDB>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDB, OrderDB>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Customer}/{action=Transition}/{id?}");
            });
        }
    }
}