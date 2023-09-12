using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger= logger;
        }
        
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult= HttpContext.Features.Get<IStatusCodeReExecuteFeature>();  
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMsg = "Sorry, the Page Could not Found";
                    _logger.LogWarning($"404 Error Occured. Path ={statusCodeResult.OriginalPath}" +
                        $" and queryString={statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }

        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            //retrieve exception Details
            var exceptionDetails =
                HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError($"The path {exceptionDetails.Path} " +
                $"threw an exception {exceptionDetails.Error}");
            //ViewBag.ExcPath = exceptionDetails.Path;
            //ViewBag.ExcMsg = exceptionDetails.Error.Message;
            //ViewBag.StackTrace = exceptionDetails.Error.StackTrace;

            return View("Error");
        }
    }

   
}
