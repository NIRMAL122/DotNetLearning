using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
            IWebHostEnvironment hostEnvironment)
        {
            _employeeRepository = employeeRepository;
            hostingEnvironment = hostEnvironment;
            
        }
        //[Route("")]
        //[Route("Homepage")]
        public ViewResult Index()
        {
            var employees= _employeeRepository.GetAllEmployees();
            return View(employees);
        }
        //[Route("detail/{id?}")]
        public ViewResult Details(int? id)
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
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath= Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                }

                Employee newEmp = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.AddEmployee(newEmp);
                return RedirectToAction("details", new { id = newEmp.Id });

            }

            return View(); 
        }


        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee emp = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Department = emp.Department,
                ExistingPhotoPath = emp.PhotoPath
            };
            return View(employeeEditViewModel);
        }

    }
}