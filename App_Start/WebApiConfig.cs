using System.Web.Http.Cors;
using System.Web.Http;

namespace GithubSearchApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            {
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                var cors = new EnableCorsAttribute(
                    origins: "http://localhost:4200",
                    headers: "*",
                    methods: "*"
                );
                cors.SupportsCredentials = true;
                config.EnableCors(cors);
            }
        }
    }
}