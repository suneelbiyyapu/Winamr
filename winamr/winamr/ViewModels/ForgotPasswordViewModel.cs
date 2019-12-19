using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using winamr.Contracts.Services.General;
using Xamarin.Forms;

namespace winamr.ViewModels
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        #region Properties


        #endregion

        #region Constructor

        public ForgotPasswordViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
            // handle this
        }

        #endregion

        #region Commands

        public ICommand ForgotPasswordCommand => new Command(OnForgotPasswordTapped);

        #endregion

        #region Virtual Method InitializeAsync

        public override async Task InitializeAsync(object data)
        {
            // PiesOfTheWeek = (await _catalogDataService.GetPiesOfTheWeekAsync()).ToObservableCollection();
            // return Task.FromResult(false);
        }

        #endregion

        #region Private Methods

        private void OnForgotPasswordTapped()
        {
            _navigationService.NavigateToAsync<LoginViewModel>();
        }

        #endregion
    }
}
