using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLKhachSan.Startup))]
namespace QLKhachSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
