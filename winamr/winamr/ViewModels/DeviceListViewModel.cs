using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using winamr.Contracts.Services.General;
using winamr.Models;
using Xamarin.Forms;

namespace winamr.ViewModels
{
    public class DeviceListViewModel : BaseViewModel
    {


        #region Properties

        private ObservableCollection<DeviceGroup> _deviceGroups;
        public ObservableCollection<DeviceGroup> DeviceGroups
        {
            get => _deviceGroups;
            set
            {
                _deviceGroups = value;
                OnPropertyChanged();
            }
        }

        public bool isCreateDeviceGroupVisible;
        public bool IsCreateDeviceGroupVisible
        {
            get => isCreateDeviceGroupVisible;
            set
            {
                isCreateDeviceGroupVisible = value;
                OnPropertyChanged(nameof(IsCreateDeviceGroupVisible));
            }
        }

        public string deviceGroupName;
        public string DeviceGroupName
        {
            get => deviceGroupName;
            set
            {
                deviceGroupName = value;
                OnPropertyChanged(nameof(IsCreateDeviceGroupVisible));
            }
        }

        #endregion

        #region Constructor

        public DeviceListViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
            // handle this
            DeviceGroups = new ObservableCollection<DeviceGroup>();
            LoadDeviceGroups();

            this.IsCreateDeviceGroupVisible = false;
        }

        #endregion

        #region Commands

        /*
        public ICommand PieTappedCommand => new Command<Pie>(OnPieTapped);
        public ICommand AddToCartCommand => new Command<Pie>(OnAddToCart);
        */
        public ICommand AddDeviceGroupCommand => new Command(OnAddDeviceGroupTapped);
        public ICommand SaveCommand => new Command(OnSaveDeviceGroupTapped);
        public ICommand CancelCommand => new Command(OnCancelDeviceGroupTapped);
        public ICommand RemoveCommand => new Command(OnRemoveDeviceGroupTapped);
        public ICommand DeviceGroupTappedCommand => new Command(OnDeviceGroupTapped);
        public ICommand ToggleIsDeviceGroupEnableCommand => new Command(OnToggleIsDeviceGroupEnable);

        #endregion

        #region Virtual Method InitializeAsync

        public override Task InitializeAsync(object data)
        {
            // PiesOfTheWeek = (await _catalogDataService.GetPiesOfTheWeekAsync()).ToObservableCollection();
            return Task.FromResult(false);
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
        private async void OnAddDeviceGroupTapped(object addDeviceGroupTappedEventArgs)
        {
            this.IsCreateDeviceGroupVisible = true;
        }
        private async void OnDeviceGroupTapped(object deviceGroupTappedEventArgs)
        {
            var selectedDeviceGroup = ((deviceGroupTappedEventArgs as ItemTappedEventArgs)?.Item as DeviceGroup);
            await _navigationService.NavigateToAsync<DeviceViewModel>(selectedDeviceGroup);
        }

        private void OnToggleIsDeviceGroupEnable(object toggleDeviceGroupTappedEventArgs)
        {

        }

        private void OnSaveDeviceGroupTapped(object saveDeviceGroupTappedEventArgs)
        {
            ObservableCollection<Models.Device> lstDevice = new ObservableCollection<Models.Device>()
            {
                new Models.Device(){DeviceId=1, DeviceName="Device #1", DeviceType="Type1", IsDeviceEnable=true},
                new Models.Device(){DeviceId=2, DeviceName="Device #2", DeviceType="Type2", IsDeviceEnable=false},
                new Models.Device(){DeviceId=3, DeviceName="Device #3", DeviceType="Type3", IsDeviceEnable=true},
                new Models.Device(){DeviceId=4, DeviceName="Device #4", DeviceType="Type4", IsDeviceEnable=false},
                new Models.Device(){DeviceId=5, DeviceName="Device #5", DeviceType="Type5", IsDeviceEnable=true},
            };

            DeviceGroups.Add(new DeviceGroup
            {
                DeviceGroupId = DeviceGroups.Count + 1,
                DeviceGroupName = DeviceGroupName,
                IsDeviceGroupEnable = true,
                Devices = lstDevice
            });

            this.IsCreateDeviceGroupVisible = false;
        }

        private void OnCancelDeviceGroupTapped(object cancelDeviceGroupTappedEventArgs)
        {
            this.IsCreateDeviceGroupVisible = false;
        }

        private void OnRemoveDeviceGroupTapped(object removeDeviceGroupTappedEventArgs)
        {
            DeviceGroups.Remove(removeDeviceGroupTappedEventArgs as DeviceGroup);
        }

        private void LoadDeviceGroups()
        {
            ObservableCollection<Models.Device> lstDevice = new ObservableCollection<Models.Device>()
            {
                new Models.Device(){DeviceId=1, DeviceName="Device #1", DeviceType="Type1", IsDeviceEnable=true},
                new Models.Device(){DeviceId=2, DeviceName="Device #2", DeviceType="Type2", IsDeviceEnable=false},
                new Models.Device(){DeviceId=3, DeviceName="Device #3", DeviceType="Type3", IsDeviceEnable=true},
                new Models.Device(){DeviceId=4, DeviceName="Device #4", DeviceType="Type4", IsDeviceEnable=false},
                new Models.Device(){DeviceId=5, DeviceName="Device #5", DeviceType="Type5", IsDeviceEnable=true},
            };

            DeviceGroups.Add(new DeviceGroup
            {
                DeviceGroupId = 1,
                DeviceGroupName = "Device Group #1",
                IsDeviceGroupEnable = true,
                Devices = lstDevice
            });

            DeviceGroups.Add(new DeviceGroup
            {
                DeviceGroupId = 2,
                DeviceGroupName = "Device Group #2",
                IsDeviceGroupEnable = false,
                Devices = lstDevice
            });

            DeviceGroups.Add(new DeviceGroup
            {
                DeviceGroupId = 3,
                DeviceGroupName = "Device Group #3",
                IsDeviceGroupEnable = true,
                Devices = lstDevice
            });

            DeviceGroups.Add(new DeviceGroup
            {
                DeviceGroupId = 4,
                DeviceGroupName = "Device Group #4",
                IsDeviceGroupEnable = false,
                Devices = lstDevice
            });

            DeviceGroups.Add(new DeviceGroup
            {
                DeviceGroupId = 5,
                DeviceGroupName = "Device Group #5",
                IsDeviceGroupEnable = true,
                Devices = lstDevice
            });
        }

        #endregion
    }
}
