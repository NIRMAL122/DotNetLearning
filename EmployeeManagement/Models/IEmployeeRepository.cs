namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee(int id);

        public IEnumerable<Employee> GetAllEmployees();

        Employee AddEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }
}
