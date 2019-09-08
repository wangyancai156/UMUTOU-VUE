using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;

namespace WangYc.Repository.NHibernate.Repositories.BW {
    public class ArrivalNoticeRepository : Repository<ArrivalNotice, int>, IArrivalNoticeRepository {
        public ArrivalNoticeRepository(IUnitOfWork uow)
            : base(uow) { }
    }
}
