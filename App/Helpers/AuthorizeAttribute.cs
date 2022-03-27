

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using if3250_2022_19_filantropi_backend.Models;


namespace if3250_2022_19_filantropi_backend.Helpers
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
  public class AuthorizeAttribute : Attribute, IAuthorizationFilter
  {
    private readonly IList<Role> _roles;

    public AuthorizeAttribute(params Role[] roles)
    {
      _roles = roles ?? new Role[] { };
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var user = (User)context.HttpContext.Items["User"];
      // var user = true;
      if (user == null)
      {
        // not logged in
        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
      }
    }
  }
}
