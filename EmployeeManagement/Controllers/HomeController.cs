using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        public ViewResult Details()
        {
            Employee emp= _employeeRepository.GetEmployee(1);

            //ViewData
            //ViewData["employees"] = emp;
            //ViewData["project"] = "Employee Management";
            //viewBag
            //ViewBag.Employees = emp;
            ViewBag.title = "Employee Details";

            return View(emp);
        }


    }
}