using OrderService.Client.Models;
using OrderService.Client.Services;
using OrderService.Client.Services.Order;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace OrderService.Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IOrderService _orderService;

        public DelegateCommand GetOrderOptionsCommand { get; private set; }
        public DelegateCommand<string> ProcessOrderCommand { get; private set; }

        private ObservableCollection<string> _orderOptions;
        public ObservableCollection<string> OrderOptions
        {
            get => _orderOptions;
            set => SetProperty(ref _orderOptions, value);
        }

        private ObservableCollection<string> _orderResults;
        public ObservableCollection<string> OrderResults
        {
            get => _orderResults;
            set => SetProperty(ref _orderResults, value);
        }

        private Order _order;
        public Order Order
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }

        public MainWindowViewModel(IOrderService orderService)
        {
            OrderOptions = new ObservableCollection<string>();
            OrderResults = new ObservableCollection<string>();
            Order = new Order();

            GetOrderOptionsCommand = new DelegateCommand(() => GetOrderOptions());
            ProcessOrderCommand = new DelegateCommand<string>((x) => ProcessOrder(x));
            _orderService = orderService;
        }

        private async void GetOrderOptions()
        {
            var options = await _orderService.GetOrderOptions();

            OrderOptions.Clear();
            OrderOptions.AddRange(options);
        }

        private async void ProcessOrder(string orderOption)
        {
            var values = await _orderService.GetOrderedText(Order, orderOption);

            OrderResults.Clear();
            OrderResults.AddRange(values);
        }
    }
}
