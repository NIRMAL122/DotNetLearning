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
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<CustomEmailConfirmationTokenProvider
                <ApplicationUser>>("CustomEmailConfirmation");



            //override password default settings
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;

                options.SignIn.RequireConfirmedEmail=true;
                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            
                options.Lockout.MaxFailedAccessAttempts= 5;
                options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromMinutes(10);
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
            //code extracted out because of security reasons
            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["GoogleClientId"];
                options.ClientSecret = builder.Configuration["GoogleClientSecret"];
            })
            .AddFacebook(options =>
            {
                options.AppId = builder.Configuration["FacebookAppId"];
                options.AppSecret = builder.Configuration["FacebookAppSecret"];
            });

            //to change token lifespan of all the tokens (default lifeSpan 1 day)
            builder.Services.Configure<DataProtectionTokenProviderOptions>(
                options => options.TokenLifespan = TimeSpan.FromHours(1));
            
            builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(
                options => options.TokenLifespan = TimeSpan.FromDays(2));

            //Encryption-Decryption
            builder.Services.AddSingleton<DataProtectionPurposeStrings>();

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