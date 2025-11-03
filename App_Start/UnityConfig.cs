using GithubSearchApi.Services;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace GithubSearchApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IGitHubService, GitHubService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmailService, EmailService>(new HierarchicalLifetimeManager());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}