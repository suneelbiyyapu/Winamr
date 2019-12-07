using System;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace winamr.Contracts.Services.General
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        NetworkAccess NetworkAccess { get; }
        IEnumerable<ConnectionProfile> Profiles { get; }

        event EventHandler<ConnectivityChangedEventArgs> ConnectivityChanged;
    }
}
