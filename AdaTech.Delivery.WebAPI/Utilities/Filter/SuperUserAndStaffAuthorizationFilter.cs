using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SuperUserAndStaffAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        bool isSuperUser = user.Claims.Any(c => c.Type == "IsSuperUser" && c.Value == "True");
        bool isStaff = user.Claims.Any(c => c.Type == "IsStaff" && c.Value == "True");

        if (!isSuperUser || !isStaff)
        {
            context.Result = new ForbidResult();
        }
    }
}
