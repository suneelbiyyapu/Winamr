using System;
using System.Collections.Generic;
using System.Text;
using winamr.Contracts.Services.General;
using XE = Xamarin.Essentials;

namespace winamr.Services
{
    public class ConnectionService : IConnectionService
    {
        public bool IsConnected => throw new NotImplementedException();

        public XE.NetworkAccess NetworkAccess => XE.Connectivity.NetworkAccess;

        public IEnumerable<XE.ConnectionProfile> Profiles => XE.Connectivity.ConnectionProfiles;

        public event EventHandler<XE.ConnectivityChangedEventArgs> ConnectivityChanged
        {
            add => XE.Connectivity.ConnectivityChanged += value;
            remove => XE.Connectivity.ConnectivityChanged -= value;
        }
    }
}
