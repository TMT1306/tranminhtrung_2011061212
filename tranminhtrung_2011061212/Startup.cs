using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tranminhtrung_2011061212.Startup))]
namespace tranminhtrung_2011061212
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
