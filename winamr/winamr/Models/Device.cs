using System;
using System.Collections.Generic;
using System.Text;

namespace winamr.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public bool IsDeviceEnable { get; set; }
    }
}
