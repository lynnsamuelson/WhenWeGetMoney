using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhenWeGetMoney.Startup))]
namespace WhenWeGetMoney
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
