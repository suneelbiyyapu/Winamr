using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace winamr.Models
{
    public class DeviceGroupList
    {
        public ObservableCollection<DeviceGroup> DeviceGroups { get; set; }
    }
}
