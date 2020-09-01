using Prism.Ioc;
using OrderService.Client.Views;
using System.Windows;
using OrderService.Client.Services.Order;
using OrderService.Client.Services.Request;

namespace OrderService.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterServices(containerRegistry);
        }

        private static void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRequestService, RequestService>();
            containerRegistry.Register<IOrderService, Services.Order.OrderService>();
        }
    }
}
