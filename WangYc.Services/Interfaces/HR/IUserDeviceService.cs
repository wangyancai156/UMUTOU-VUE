using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IUserDeviceService {

        UserDeviceView GetUserDeviceView(string userId, string deviceType, string sessionKey);

        UserDeviceView CrateUserDevice(string userId, int timeout, string deviceType, string passkey);

        void UpdateUserDevice(string userId, int timeout, string deviceType, string passkey);


    }
}
