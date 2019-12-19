using System;
using System.Diagnostics;
using System.Windows.Input;
using winamr.Contracts.Services.Data;
using winamr.Contracts.Services.General;
using Xamarin.Forms;

namespace winamr.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ISettingsService _settingsService;

        string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        string mobileNum;
        public string MobileNum
        {
            get { return mobileNum; }
            set
            {
                if (mobileNum != value)
                {
                    mobileNum = value;
                    OnPropertyChanged(nameof(MobileNum));
                }
            }
        }

        string passWord;
        public string PassWord
        {
            get { return passWord; }
            set
            {
                if (passWord != value)
                {
                    passWord = value;
                    OnPropertyChanged(nameof(PassWord));
                }
            }
        }



        public RegistrationViewModel(IConnectionService connectionService,
                                     INavigationService navigationService,
                                     IDialogService dialogService,
                                     IAuthenticationService authenticationService,
                                     ISettingsService settingsService)
            : base(connectionService, navigationService, dialogService)
        {
            _authenticationService = authenticationService;
            _settingsService = settingsService;

        }

        public ICommand SignUpCommand => new Command(OnSignUp);
        public ICommand LoginCommand => new Command(OnLogin);

        private async void OnSignUp()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // Make an API call to register an user
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnLogin()
        {
            await _navigationService.NavigateToAsync<LoginViewModel>();
        }
    }
}
