using winamr.Contracts.Services.General;

namespace winamr.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IConnectionService connectionService,
                             INavigationService navigationService,
                             IDialogService dialogService)
            : base(connectionService, navigationService, dialogService)
        {

        }
    }
}