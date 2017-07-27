using BaoCMS.Data.Entities;
using BaoCMS.Domain.Roles.DefaultRoles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BaoCMS.Domain.Users.Commands;
using BaoCMS.Framework.Commands;
using BaoCMS.Framework.Queries;
using BaoCMS.Reporting.Users;
using BaoCMS.Reporting.Users.Queries;

namespace BaoCMS.Data.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder EnsureDbCreated(this IApplicationBuilder app)
        {
            var dbContext = app.ApplicationServices.GetRequiredService<DbContext>();

            dbContext.Database.Migrate();
            
            return app;
        }

        public static async Task<IApplicationBuilder> EnsureIdentityCreatedAsync(this IApplicationBuilder app)
        {
            var commandSender = app.ApplicationServices.GetRequiredService<ICommandSender>();
            var queryDispatcher= app.ApplicationServices.GetRequiredService<IQueryDispatcher>();

            var query = new GetLoginUserModel
            {
                UserName = "admin",
                Password = "admin"
            };
            var user= await queryDispatcher.DispatchAsync<GetLoginUserModel, LoginUserModel>(query);
            if (user == null)
            {
                await commandSender.SendAsync<CreateUser>(new CreateUser()
                {
                    UserName="admin",
                    Email= "admin@default.com",
                    Password = "admin"
                });
            }
            //var userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            //var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<Role>>();

            //if (!await roleManager.RoleExistsAsync(Administrator.Name))
            //{
            //    await roleManager.CreateAsync(new Role
            //    {
            //        Id = Administrator.Id,
            //        Name = Administrator.Name
            //    });
            //}

            //var adminEmail = "admin@default.com";

            //if (await userManager.FindByEmailAsync(adminEmail) == null)
            //{
            //    var user = new User { UserName = adminEmail, Email = adminEmail };
            //    await userManager.CreateAsync(user, "admin");
            //}

            //var adminUser = await userManager.FindByEmailAsync(adminEmail);

            //if (!await userManager.IsInRoleAsync(adminUser, Administrator.Name))
            //{
            //    await userManager.AddToRoleAsync(adminUser, Administrator.Name);
            //}

            return app;
        }
    }
}
