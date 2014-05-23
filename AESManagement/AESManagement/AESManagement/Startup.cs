using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AESManagement.Startup))]
namespace AESManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
