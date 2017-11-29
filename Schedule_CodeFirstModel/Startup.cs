using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(Schedule_CodeFirstModel.Startup))]
namespace Schedule_CodeFirstModel
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
