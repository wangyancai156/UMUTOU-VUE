using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.HR {
    public class UserDeviceView {

        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ActiveTime { get; set; }

        public DateTime ExpiredTime { get; set; }

        public string DeviceType { get; set; }

        public string SessionKey { get; set; }
    }
}
