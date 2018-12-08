using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;

namespace WangYc.Repository.NHibernate.Repositories.HR {
    public class UserDeviceRepository : Repository<UserDevice, int>, IUserDeviceRepository {
        public UserDeviceRepository(WangYc.Core.Infrastructure.UnitOfWork.IUnitOfWork uow)
            : base(uow) { }
    }
}
