using Microsoft.AspNetCore.Mvc.Filters;
using Logger;
using Microsoft.AspNetCore.Mvc;

namespace Players.Custom
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        private ILog _ILog;
        public CustomExceptionHandler()
        {
            _ILog = Logger.Log.getInstance();
        }
        public void OnException(ExceptionContext context)
        {
            _ILog.LogException(context.Exception.ToString());
            context.ExceptionHandled= true;
            context.Result = new RedirectResult("/Home/Error");
        }
    }
}
