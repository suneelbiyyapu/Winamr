using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using winamr.Contracts.Services.Data;
using winamr.Contracts.Services.General;
using Xamarin.Forms;

namespace winamr.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ISettingsService _settingsService;

        private string _userName;
        private string _password;


        #region Constructor

        public LoginViewModel(IConnectionService connectionService,
                              ISettingsService settingsService,
                              INavigationService navigationService,
                              IAuthenticationService authenticationService,
                              IDialogService dialogService)
            : base(connectionService, navigationService, dialogService)
        {
            _authenticationService = authenticationService;
            _settingsService = settingsService;
        }

        #endregion

        #region Properties

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand => new Command(OnLogin);
        public ICommand RegisterCommand => new Command(OnRegister);
        public ICommand ForgotPasswordCommand => new Command(OnForgotPassword);

        #endregion

        #region Private Methods

        private async void OnLogin()
        {
            /*
            IsBusy = true;
            if (_connectionService.IsConnected)
            {
            
                var authenticationResponse = await _authenticationService.Authenticate(UserName, Password);

                if (authenticationResponse.IsAuthenticated)
                {
                */

            // we store the Id to know if the user is already logged in to the application
            _settingsService.UserIdSetting = "Test User"; // authenticationResponse.User.Id;
            _settingsService.UserNameSetting = "Test User"; // authenticationResponse.User.FirstName;

            //IsBusy = false;
            await _navigationService.NavigateToAsync<MainViewModel>();
            /*
                }
                
            }
            else
            {
                IsBusy = false;
                await _dialogService.ShowDialog(
                    "This username/password combination isn't known",
                    "Error logging you in",
                    "OK");
            }
            */
        }

        private void OnRegister()
        {
            _navigationService.NavigateToAsync<RegistrationViewModel>();
        }

        private void OnForgotPassword()
        {
            _navigationService.NavigateToAsync<ForgotPasswordViewModel>();
        }

        #endregion
    }
}
