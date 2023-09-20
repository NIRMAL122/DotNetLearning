﻿using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Security
{
    public class SuperAdminHandler :
        AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirement requirement)
        {
            if (context.User.IsInRole("superAdmin"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
