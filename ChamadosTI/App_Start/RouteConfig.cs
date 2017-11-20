using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChamadosTI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "chamado",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Chamado", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "usuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tipoChamado",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoChamado", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tipoStatus",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoStatus", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "tipoUsuario",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoUsuario", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
