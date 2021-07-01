using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mercadito.Startup))]
namespace mercadito
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
