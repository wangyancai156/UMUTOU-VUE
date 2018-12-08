using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Mapping.HR {
   public static class UserDeviceMapper {
        public static UserDeviceView ConvertToUserDeviceView(this UserDevice model) {

            return Mapper.Map<UserDevice, UserDeviceView>(model);
        }

        public static IEnumerable<UserDeviceView> ConvertToUserDeviceView(this IEnumerable<UserDevice> model) {

            return Mapper.Map<IEnumerable<UserDevice>, IEnumerable<UserDeviceView>>(model);
        }
    }
}
