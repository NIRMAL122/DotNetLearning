﻿namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployee(int id);
    }
}
