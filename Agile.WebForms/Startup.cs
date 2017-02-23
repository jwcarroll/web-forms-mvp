using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agile.WebForms.Startup))]
namespace Agile.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
