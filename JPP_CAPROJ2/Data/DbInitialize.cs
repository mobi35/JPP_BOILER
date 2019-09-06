﻿using JPP_CAPROJ2.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<JPPDbContext>();

                var admin = new User {FullName="Bagito",PhoneNumber="09198882900" ,UserName = "admin", Password = "admin", Email = "Maeee",  Role = "employee" };
         
                context.Users.Add(admin);

                context.SaveChanges();
            }
        }
    }
}
