using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLySach_B3.Startup))]
namespace QuanLySach_B3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
