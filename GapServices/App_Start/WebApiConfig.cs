using GapCommon.Interfaces.Bll;
using GapCompositionRoot;
using GapServices.App_Start.Filters;
using GapServices.App_Start.Helper;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;

namespace GapServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Container
            var container = Composer.BuildContainer();

            config.DependencyResolver = new UnityResolver(container);

            IUserTokens authentications = container.Resolve<IUserTokens>();
            IUsers users = container.Resolve<IUsers>();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Filters.Add(new AuthenticationExtendedAttribute(authentications));
            config.Filters.Add(new AuthorizationFilterExtended(users));
            config.Filters.Add(new FilterExtendedAttribute());
            config.Filters.Add(new ExceptionExtendedAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors();

            config.Formatters.JsonFormatter.SupportedMediaTypes
           .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}