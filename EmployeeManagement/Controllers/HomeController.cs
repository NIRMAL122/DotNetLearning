using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> logger;

        public HomeController(IEmployeeRepository employeeRepository,
            IWebHostEnvironment hostEnvironment,
            ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            hostingEnvironment = hostEnvironment;
            this.logger= logger;
            
        }
        //[Route("")]
        //[Route("Homepage")]
        [AllowAnonymous]
        public ViewResult Index()
        {
            var employees= _employeeRepository.GetAllEmployees();
            return View(employees);
        }
        //[Route("detail/{id?}")]
        [AllowAnonymous]
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

            //throw new Exception("testing");

            //logger.LogTrace("Trace");
            //logger.LogDebug("Debug");
            //logger.LogInformation("Information");
            //logger.LogWarning("Warning");
            //logger.LogError("Error");
            //logger.LogCritical("Critical");

            Employee emp = _employeeRepository.GetEmployee(id.Value);
            if(emp== null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = emp,
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
                
                string uniqueFileName = ProcessUploadedFile(model);

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

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using(var fileStream= new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
                

            }
            return uniqueFileName;
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

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email= model.Email;
                employee.Department = model.Department;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                Employee updatedEmp= _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}