using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CardsAndDecks.WebMVC.Startup))]
namespace CardsAndDecks.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
