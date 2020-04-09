Busing Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MotorCycle.Startup))]
namespace MotorCycle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
