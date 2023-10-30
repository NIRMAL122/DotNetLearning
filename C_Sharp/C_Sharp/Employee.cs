using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    class Main
    {
        
        static void main(string[] args)
        {
            List<Employee> list = new List<Employee>
        {
            new Employee { EmpId = 1, Name = "John", Salary = 50000, Address = "123 Main St", Department = "HR" },
            new Employee { EmpId = 2, Name = "Alice", Salary = 60000, Address = "456 Elm St", Department = "IT" },
            new Employee { EmpId = 3, Name = "Bob", Salary = 55000, Address = "789 Oak St", Department = "Finance" }
        };

            Console.WriteLine(Search(list,"Name","John"));
            Console.WriteLine(Search(list,"EmpId","2"));
        }

        static List<Employee> Search(List<Employee> employees, string criteria, string value)
        {
            switch (criteria)
            {
                case "EmpId":
                    return employees.Where(e => e.EmpId.ToString() == value).ToList();
                case "Name":
                    return employees.Where(e => e.Name == value).ToList();
                case "Salary":
                    return employees.Where(e => e.Salary.ToString() == value).ToList();
                case "Address":
                    return employees.Where(e => e.Address == value).ToList();
                case "Department":
                    return employees.Where(e => e.Department == value).ToList();
                default:
                    return new List<Employee>();
            }
        }
    }
}
