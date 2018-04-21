using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PO;
using WangYc.Models.Repository.PO;

namespace WangYc.Repository.NHibernate.Repositories.PO {
   public class PurchaseOrderDetailRepository : Repository<PurchaseOrderDetail, int>, IPurchaseOrderDetailRepository {
        public PurchaseOrderDetailRepository(IUnitOfWork uow)
            : base(uow) { }
    }

}