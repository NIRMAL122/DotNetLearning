using EmployeeManagement.Models;
using EmployeeManagement.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

            //DI- injecting repo services
            builder.Services.AddScoped<IEmployeeRepository,SQLEmployeeRepository>();

            //CreateDBConnection
            builder.Services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("EmpDbConnection")));

            //AddIdentiy
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<AppDbContext>();


            //override password default settings
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
            });

            //logging
            builder.Services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog();
            });

            //adding authorization globally
            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                                        .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            //adding Claims Based authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role","true"));

                //custom authorization policy
                //options.AddPolicy("EditRolePolicy",
                //    policy => policy.RequireAssertion(context=>
                //        context.User.IsInRole("Admin")&&
                //        context.User.HasClaim(claim=>claim.Type=="Edit Role" && claim.Value=="true")||
                //        context.User.IsInRole("superAdmin")));


                //policy with custom requirement
                options.AddPolicy("EditRolePolicy",
                    policy => policy.AddRequirements(new ManageAdminRolesAndClaimsRequirement()));

                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Admin"));

            });

            //register cusotm handler class
            builder.Services.AddScoped<IAuthorizationHandler, CanEditOnlyOtherAdminRolesAndClaimsHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, SuperAdminHandler>();


            //configuring Google authentication
            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "462678562285-evtgkitbb3tcjpedt94ej3ub7ch6904g.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });


            var app = builder.Build();

           
            if (app.Environment.IsDevelopment())
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
                //app.UseHsts();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Error");

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}