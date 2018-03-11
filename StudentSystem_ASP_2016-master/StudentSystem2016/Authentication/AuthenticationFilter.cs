using System.Web;
using System.Web.Mvc;

namespace StudentSystem2016.Authentication
{
    public class AuthenticationFilter 
        : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["LoggedUser"] == null )
            {
                filterContext.HttpContext.Response.Redirect("~/SingIN/Login");
            }
        }
    }
}