using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChamadosTI.Startup))]
namespace ChamadosTI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
