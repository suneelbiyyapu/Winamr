using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace winamr.Models
{
    public class DeviceGroup
    {
        public int DeviceGroupId { get; set; }
        public string DeviceGroupName { get; set; }
        public bool IsDeviceGroupEnable { get; set; }
        public ObservableCollection<Device> Devices { get; set; }
    }
}
