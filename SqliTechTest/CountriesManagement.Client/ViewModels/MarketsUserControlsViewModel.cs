using CoutriesManagement.Core.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CountriesManagement.Client.ViewModels
{
    public class MarketsUserControlsViewModel : BindableBase
    {
        private ObservableCollection<Market> _markets;
        public ObservableCollection<Market> Markets
        {
            get => _markets;
            set => SetProperty(ref _markets, value);
        }

        private ObservableCollection<Market> _selectedMarkets;
        public ObservableCollection<Market> SelectedMarkets
        {
            get => _selectedMarkets;
            set => SetProperty(ref _selectedMarkets, value);
        }

        public MarketsUserControlsViewModel()
        {
            Markets = new ObservableCollection<Market>();
            SelectedMarkets = new ObservableCollection<Market>();

        }
    }
}
