using OrderService.Client.Services;
using OrderService.Client.Services.Order;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace OrderService.Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IOrderService _orderService;

        public DelegateCommand GetOrderOptionsCommand { get; private set; }

        private ObservableCollection<string> _orderOptions;
        public ObservableCollection<string> OrderOptions
        {
            get => _orderOptions;
            set => SetProperty(ref _orderOptions, value);
        }


        public MainWindowViewModel(IOrderService orderService)
        {
            OrderOptions = new ObservableCollection<string>();

            GetOrderOptionsCommand = new DelegateCommand(() => GetOrderOptions());
            _orderService = orderService;
        }

        private async void GetOrderOptions()
        {
            var options = await _orderService.GetOrderOptions();

            OrderOptions.Clear();
            OrderOptions.AddRange(options);
        }
    }
}
