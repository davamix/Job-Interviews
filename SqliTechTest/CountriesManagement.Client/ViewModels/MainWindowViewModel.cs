using CoutriesManagement.Core.DTOs;
using CoutriesManagement.Core.Entities;
using CoutriesManagement.Core.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace CountriesManagement.Client.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private readonly IDataService<Country> _countryService;
        private readonly IDataService<Market> _marketService;

        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set => SetProperty(ref _selectedCountry, value);
        }

        private ObservableCollection<Country> _coutries;
        public ObservableCollection<Country> Countries
        {
            get => _coutries;
            set => SetProperty(ref _coutries, value);
        }

        private ObservableCollection<Market> _markets;
        public ObservableCollection<Market> Markets
        {
            get => _markets;
            set => SetProperty(ref _markets, value);
        }

        private ObservableCollection<CountryMarket> _selectedMarkets;
        public ObservableCollection<CountryMarket> SelectedMarkets
        {
            get => _selectedMarkets;
            set => SetProperty(ref _selectedMarkets, value);
        }

        public DelegateCommand CountrySelectedCommand { get; private set; }
        public DelegateCommand<CountryMarket> MarketActiveCheckedCommand { get; private set; }
        public DelegateCommand SaveChangesCommand { get; private set; }
        public DelegateCommand AddCountryCommand { get; private set; }
        public DelegateCommand<object> DeleteCountryCommand { get; private set; }

        public MainWindowViewModel(IDataService<Country> countryService, IDataService<Market> marketService)
        {
            _countryService = countryService;
            _marketService = marketService;

            Countries = new ObservableCollection<Country>();
            Markets = new ObservableCollection<Market>();
            SelectedMarkets = new ObservableCollection<CountryMarket>();

            CountrySelectedCommand = new DelegateCommand(() => ShowCountryInfo());
            MarketActiveCheckedCommand = new DelegateCommand<CountryMarket>((x) => SaveActiveMarket(x));
            SaveChangesCommand = new DelegateCommand(() => SaveChanges());
            AddCountryCommand = new DelegateCommand(() => AddCountry());
            DeleteCountryCommand = new DelegateCommand<object>((x) => DeleteCountry(x));

            LoadCountries();
        }

        private async void ShowCountryInfo()
        {
            if (SelectedCountry != null)
            {
                LoadMarkets();

                var country = await _countryService.Get(SelectedCountry.Id);

                SelectedCountry = country;

                LoadSelectedMarkets();
            }
        }

        private async void SaveActiveMarket(CountryMarket countryMarket)
        {
            //Now 'countryMarket' always is null... ¯\_(ツ)_/¯
            if (countryMarket == null) return;

            if (countryMarket.IsActive)
            {
                var market = await _marketService.Get(countryMarket.MarketId);
                SelectedCountry.Markets.Add(market);
            }
            else
            {
                var market = SelectedCountry.Markets.First(x => x.Code == countryMarket.Code);
                SelectedCountry.Markets.Remove(market);
            }
        }

        private void SaveChanges()
        {
            if (SelectedCountry != null)
            {
                if (SelectedCountry.Id > 0)
                {
                    _countryService.Update(SelectedCountry.Id, SelectedCountry);
                }
                else
                {
                    _countryService.Create(SelectedCountry);
                    LoadCountries();
                }
            }
        }

        private async void LoadCountries()
        {
            Countries.Clear();

            var countries = await _countryService.GetAll();

            foreach (var c in countries)
            {
                Countries.Add(c);
            }
        }

        private async void LoadMarkets()
        {
            Markets.Clear();

            var markets = await _marketService.GetAll();

            foreach (var m in markets)
            {
                Markets.Add(m);
            }
        }

        private async void LoadSelectedMarkets()
        {
            SelectedMarkets.Clear();

            var markets = await _marketService.GetAll();

            foreach (var market in Markets)
            {
                var mDto = new CountryMarket { MarketId = market.Id, Code = market.Code };

                mDto.IsActive = SelectedCountry.Markets.Any(x => x.Code == market.Code);

                SelectedMarkets.Add(mDto);
            }
        }

        private void AddCountry()
        {
            SelectedCountry = new Country();
        }

        private void DeleteCountry(object x)
        {
            //Binding reference error
        }
    }
}
