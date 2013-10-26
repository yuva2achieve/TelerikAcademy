using Owin;

namespace _02.SayHelloAndShowAssemblyLocation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
