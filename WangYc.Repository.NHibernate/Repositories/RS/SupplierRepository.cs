using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.RS;
using WangYc.Models.RS;

namespace WangYc.Repository.NHibernate.Repositories.RS {
   public class SupplierRepository : Repository<Supplier, int>, ISupplierRepository {
        public SupplierRepository(IUnitOfWork uow)
            : base(uow) { }
    }

}