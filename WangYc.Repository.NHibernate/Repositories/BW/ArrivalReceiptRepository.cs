using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;

namespace WangYc.Repository.NHibernate.Repositories.BW {
   public class ArrivalReceiptRepository : Repository<ArrivalReceipt, int>, IArrivalReceiptRepository {
        public ArrivalReceiptRepository(IUnitOfWork uow)
            : base(uow) { }
    }
}
