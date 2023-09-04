namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public EmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name="Annalise", Department="Crime", Email="AKeating@gmail.com" },
                new Employee() { Id = 2, Name="Laurel", Department="Crime Student", Email="Laurel@gmail.com" },
                new Employee() { Id = 3, Name="Frank", Department="Hitman", Email="Frank@gmail.com" }
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
