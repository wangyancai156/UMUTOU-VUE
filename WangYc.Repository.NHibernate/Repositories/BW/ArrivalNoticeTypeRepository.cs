using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;

namespace WangYc.Repository.NHibernate.Repositories.BW {
    public class ArrivalNoticeTypeRepository:Repository<ArrivalNoticeType,int>, IArrivalNoticeTypeRepository {
        public ArrivalNoticeTypeRepository( IUnitOfWork uow )
            : base(uow) { }
    }
}
