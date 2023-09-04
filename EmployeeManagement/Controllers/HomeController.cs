using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
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

        public ViewResult Index()
        {
            var employees= _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        public ViewResult Details()
        {
            //Employee emp= _employeeRepository.GetEmployee(1);

            //ViewData
            //ViewData["employees"] = emp;
            //ViewData["project"] = "Employee Management";
            //viewBag
            //ViewBag.Employees = emp;
            //ViewBag.title = "Employee Details";


            //viewModel
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }


    }
}