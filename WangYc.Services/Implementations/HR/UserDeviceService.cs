using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Implementations.HR {

    public class UserDeviceService : IUserDeviceService {

        private readonly IUserDeviceRepository _userDeviceRepository;
        private readonly IUnitOfWork _uow;

        public UserDeviceService(IUserDeviceRepository userDeviceRepository, IUnitOfWork uow) {

            this._userDeviceRepository = userDeviceRepository;
            this._uow = uow;
        }


        public IEnumerable<UserDevice> GetUserDeviceList(string userId, string deviceType, string sessionKey) {

            Query query = new Query();
            query.Add(Criterion.Create<UserDevice>(p => p.UserId, userId, CriteriaOperator.Equal));
            query.Add(Criterion.Create<UserDevice>(p => p.DeviceType, deviceType, CriteriaOperator.Equal));
            if (sessionKey == "") {
                query.Add(Criterion.Create<UserDevice>(p => p.SessionKey, sessionKey, CriteriaOperator.Equal));
            }
            IEnumerable<UserDevice> model = this._userDeviceRepository.FindBy(query);
            return model;
        }

        public UserDevice GetUserDevice(string userId, string deviceType, string sessionKey) {

            return this.GetUserDeviceList(userId, deviceType, sessionKey).LastOrDefault();
        }

        public UserDeviceView GetUserDeviceView(string userId, string deviceType, string sessionKey) {
 
            return this.GetUserDeviceList(userId, deviceType, sessionKey).LastOrDefault().ConvertToUserDeviceView();
        }

        public UserDeviceView CrateUserDevice(string userId, int timeout, string deviceType,string passkey) {

            UserDevice existsDevice = new UserDevice() {
                UserId = userId,
                CreateTime = DateTime.UtcNow,
                ActiveTime = DateTime.UtcNow,
                ExpiredTime = DateTime.UtcNow.AddMinutes(timeout),
                DeviceType = deviceType,
                SessionKey = passkey
            };
            this._userDeviceRepository.Save(existsDevice);
            return existsDevice.ConvertToUserDeviceView();
        }

        public void UpdateUserDevice(string userId, int timeout, string deviceType, string passkey) {

            UserDevice model = GetUserDevice(userId, deviceType, passkey);
            model.ExpiredTime = DateTime.UtcNow.AddMinutes(timeout);
            model.ActiveTime = DateTime.UtcNow;
            this._userDeviceRepository.Save(model);
        }


    }
}
