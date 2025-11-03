using System.Web;
using System.Web.Http;


namespace GithubSearchApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(
                System.Web.SessionState.SessionStateBehavior.Required
            );
        }
    }
}

