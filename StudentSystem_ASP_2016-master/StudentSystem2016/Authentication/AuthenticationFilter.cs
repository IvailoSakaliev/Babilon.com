using BissnessLogic.Sercises;
using System.Web.Mvc;

namespace StudentSystem2016.Authentication
{
    public class AuthenticationFilter 
        : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AuthenticationServise servise = new AuthenticationServise();
            if (servise.LoggedUser == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login/?ResirectUrl=" + filterContext.HttpContext.Request.Url);
                filterContext.Result = new EmptyResult();
                return;
            }
        }
    }
}