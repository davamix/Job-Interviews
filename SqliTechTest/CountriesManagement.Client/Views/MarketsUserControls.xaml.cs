using CoutriesManagement.Core.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CountriesManagement.Client.Views
{
    /// <summary>
    /// Interaction logic for MarketsUserControls
    /// </summary>
    public partial class MarketsUserControls : UserControl
    {
        public static readonly DependencyProperty MarketsProperty = DependencyProperty.Register(
            "Markets",
            typeof(ObservableCollection<Market>),
            typeof(MarketsUserControls));

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems",
            typeof(Market),
            typeof(MarketsUserControls));

        public ObservableCollection<Market> Markets
        {
            get { return (ObservableCollection<Market>)GetValue(MarketsProperty); }
            set { SetValue(MarketsProperty, value); }
        }
        public MarketsUserControls()
        {
            InitializeComponent();
        }
    }
}
