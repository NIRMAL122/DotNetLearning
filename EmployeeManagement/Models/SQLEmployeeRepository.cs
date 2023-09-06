namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public SQLEmployeeRepository(AppDbContext db)
        {
            _db = db;
        }
        
        public Employee AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee emp= _db.Employees.Find(id);
            if (emp != null)
            {
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _db.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _db.Employees.Find(id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp= _db.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

            return employee;

        }
    }
}
