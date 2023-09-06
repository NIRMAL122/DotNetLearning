using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void seed (this ModelBuilder mb)
        {
            mb.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name= "Mark",
                    Department= Dept.IT,
                    Email="mark@gmail.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Laural",
                    Department = Dept.HR,
                    Email = "Laural@gmail.com"
                }
             );

        }
    }
}
