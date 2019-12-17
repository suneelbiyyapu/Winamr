using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using winamr.Contracts.Services.General;
using winamr.Models;

namespace winamr.ViewModels
{
    public class DeviceViewModel : BaseViewModel
    {
        #region Properties

        private DeviceGroup _devices;

        public DeviceGroup Devices
        {
            get => _devices;
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public DeviceViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
            // handle this
        }

        #endregion

        #region Commands

        /*
        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);
        public ICommand AddToCartCommand => new Command<Pie>(OnAddToCart);
        */

        #endregion

        #region Virtual Method InitializeAsync

        public override async Task InitializeAsync(object data)
        {
            // PiesOfTheWeek = (await _catalogDataService.GetPiesOfTheWeekAsync()).ToObservableCollection();
            Devices = (DeviceGroup)data;
            //return Task.FromResult(false);
        }

        #endregion

        #region Private Methods

        /*
        private void OnPieTapped(Pie selectedPie)
        {
            _navigationService.NavigateToAsync<PieDetailViewModel>(selectedPie);
        }

        private async void OnAddToCart(Pie selectedPie)
        {
            MessagingCenter.Send(this, MessagingConstants.AddPieToBasket, selectedPie);
            await _dialogService.ShowDialog("Pie added to your cart", "Success", "OK");
        }
        */

        #endregion
    }
}
