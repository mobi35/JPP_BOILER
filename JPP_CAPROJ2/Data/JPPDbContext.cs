using JPP_CAPROJ2.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data
{
    public class JPPDbContext : DbContext
    {
        public JPPDbContext(DbContextOptions<JPPDbContext> options) : base(options) {  
       

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Service> Services { get; set; }
           public DbSet<Request> Requests { get; set; }
          public DbSet<Notification> Notifications { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<OrderedProducts> Orders { get; set; }
        public DbSet<Quotations> Quotations { get; set; }
    }
}


