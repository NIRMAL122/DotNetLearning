namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public EmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name="Annalise", Department=Dept.IT, Email="AKeating@gmail.com" },
                new Employee() { Id = 2, Name="Laurel", Department=Dept.Payroll, Email="Laurel@gmail.com" },
                new Employee() { Id = 3, Name="Frank", Department=Dept.HR, Email="Frank@gmail.com" }
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id= _employeeList.Max(x => x.Id)+1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp=_employeeList.FirstOrDefault(e=>e.Id==id);
            if (emp!=null)
            {
                _employeeList.Remove(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.Name= employee.Name;
                emp.Email= employee.Email;
                emp.Department= employee.Department;
            }
            return emp;
        }
    }
}
