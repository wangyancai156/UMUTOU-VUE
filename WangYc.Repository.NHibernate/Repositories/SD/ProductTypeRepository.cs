using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.SD;
using WangYc.Models.SD;

namespace WangYc.Repository.NHibernate.Repositories.SD {
    public class ProductTypeRepository : Repository<ProductType, int>, IProductTypeRepository {
        public ProductTypeRepository(IUnitOfWork uow)
            : base(uow) { }
    }

}
