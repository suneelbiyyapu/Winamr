using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using winamr.Contracts.Services.General;

namespace winamr.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        #region Properties


        #endregion

        #region Constructor

        public MyProfileViewModel(IConnectionService connectionService,
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
            // return Task.FromResult(false);
        }

        #endregion

        #region Private Methods


        #endregion
    }
}
