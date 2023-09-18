using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed is an extension method to seed data into employee table
            base.OnModelCreating(modelBuilder); //calling "IdentityDbContext" base class onModelCreating method
            modelBuilder.seed();

            //for changing the ON DELETE property from Cascading to NoAction for foreign Keys
            foreach(var fk in modelBuilder.Model.GetEntityTypes()
                                           .SelectMany(e=>e.GetForeignKeys())) 
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }   
        }
    }
}
