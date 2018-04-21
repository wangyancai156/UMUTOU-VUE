using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.FI;

namespace WangYc.Models.Repository.FI {
    public interface IPaymentRepository : IRepository<Payment, int> {
    }
}
