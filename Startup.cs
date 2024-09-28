using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeePolls.Startup))]
namespace EmployeePolls
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
