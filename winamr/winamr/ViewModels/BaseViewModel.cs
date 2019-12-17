using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using winamr.Models;
using winamr.Services;
using winamr.Contracts.Services.General;
using System.Threading.Tasks;

namespace winamr.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly IConnectionService _connectionService;
        protected readonly INavigationService _navigationService;
        protected readonly IDialogService _dialogService;

        #region Constructor

        public BaseViewModel(IConnectionService connectionService, INavigationService navigationService,
            IDialogService dialogService)
        {
            _connectionService = connectionService;
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        #endregion


        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region Virtual Method InitializeAsync

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
