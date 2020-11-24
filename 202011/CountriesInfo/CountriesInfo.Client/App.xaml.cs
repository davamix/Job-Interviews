using Prism.Ioc;
using CountriesInfo.Client.Views;
using System.Windows;
using CountriesInfo.Core.Database;
using CountriesInfo.Core.Entities;
using CountriesInfo.Core.Services;

namespace CountriesInfo.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var context = this.Container.Resolve<CountryContext>();

            context.Database.EnsureCreated();

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<CountryContext>();
            containerRegistry.Register<IDataService<Country>, CountryService>();
            containerRegistry.Register<IDataService<Market>, MarketService>();
        }
    }
}
