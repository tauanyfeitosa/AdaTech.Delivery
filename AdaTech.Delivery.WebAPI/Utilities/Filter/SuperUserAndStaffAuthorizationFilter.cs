using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdaTech.Delivery.WebAPI.Utilities.Filter
{
    public class SuperUserAndStaffAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            bool isSuperUser = user.Claims.Any(c => c.Type == "IsSuperUser" && c.Value == "True");
            bool isStaff = user.Claims.Any(c => c.Type == "IsStaff" && c.Value == "True");
            bool isActivated = user.Claims.Any(c => c.Type == "IsActive" && c.Value == "True");
            bool isLogged = user.Claims.Any(c => c.Type == "IsLogged" && c.Value == "True");

            if (!isSuperUser || !isStaff || !isActivated || !isLogged)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
