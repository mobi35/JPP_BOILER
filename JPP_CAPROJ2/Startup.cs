using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JPP_CAPROJ2.Data;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;

namespace JPP_CAPROJ2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static bool IsSessionAvailable;

      

        public static string whatService;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
      //   services.AddDbContext<JPPDbContext>(options => options.UseInMemoryDatabase("JPPDbContext"));
           services.AddDbContext<JPPDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IQuotationRepository, QuotationRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(so => so.IdleTimeout = TimeSpan.FromSeconds(5000));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

           
            IsSessionAvailable = false;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Login/Index");
                app.UseHsts();
            }
            app.UseSession();
        
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
         // DbInitialize.Seed(app);
            //RotativaConfiguration.Setup(env);
        }
    }
}
