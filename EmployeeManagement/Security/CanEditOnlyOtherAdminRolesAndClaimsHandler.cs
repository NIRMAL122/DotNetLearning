using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EmployeeManagement.Security
{
    public class CanEditOnlyOtherAdminRolesAndClaimsHandler:
        AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CanEditOnlyOtherAdminRolesAndClaimsHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor ??
                throw new ArgumentNullException(nameof(httpContextAccessor));
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            ManageAdminRolesAndClaimsRequirement requirement)
        {
            
            if(context.User==null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            
            
            //var authFilterContext = context.Resource as AuthorizationFilterContext;
            //if (authFilterContext == null)
            //{
            //    return Task.CompletedTask;
            //}

            string loggedInAdminId =
                context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            string adminIdBeingEdited = httpContextAccessor.HttpContext.Request.Query["userId"].ToString();

            if(context.User.IsInRole("Admin")&&
                context.User.HasClaim(claim=>claim.Type=="Edit Role" && claim.Value=="true")&&
                adminIdBeingEdited.ToLower()!= loggedInAdminId.ToLower())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
