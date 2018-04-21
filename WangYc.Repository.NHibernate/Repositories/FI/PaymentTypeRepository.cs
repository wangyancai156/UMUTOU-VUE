using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.FI;
using WangYc.Models.Repository.FI;

namespace WangYc.Repository.NHibernate.Repositories.FI {
    public class PaymentTypeRepository : Repository<PaymentType, int>, IPaymentTypeRepository {
        public PaymentTypeRepository(IUnitOfWork uow)
            : base(uow) { }
    }

}
