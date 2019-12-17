using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using winamr.Contracts.Services.General;
using winamr.Enums;
using winamr.Models;
using Xamarin.Forms;

namespace winamr.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private ObservableCollection<MainMenuItem> _menuItems;
        private readonly ISettingsService _settingsService;

        public MenuViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService,
            ISettingsService settingsService)
            : base(connectionService, navigationService, dialogService)
        {
            _settingsService = settingsService;
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        public string WelcomeText => "Hello " + _settingsService.UserNameSetting;

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                _settingsService.UserIdSetting = null;
                _settingsService.UserNameSetting = null;
                _navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            _navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Device Groups",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home
            });
            /*
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Pies",
                ViewModelToLoad = typeof(PieCatalogViewModel),
                MenuItemType = MenuItemType.Pies
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Cart",
                ViewModelToLoad = typeof(ShoppingCartViewModel),
                MenuItemType = MenuItemType.ShoppingCart
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Contact us",
                ViewModelToLoad = typeof(ContactViewModel),
                MenuItemType = MenuItemType.Contact
            });
            */
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Log out",
                ViewModelToLoad = typeof(LoginViewModel),
                MenuItemType = MenuItemType.Logout
            });
        }
    }
}
