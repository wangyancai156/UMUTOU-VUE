using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.FI;
using WangYc.Models.Repository.FI;
using WangYc.Repository.NHibernate.Repositories.FI;

namespace WangYc.Repository.NHibernate.Tests.FI {
    [TestClass]
    public class PaymentTests {

        private readonly IPaymentRepository _paymentRepository;

   
        public PaymentTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._paymentRepository = new PaymentRepository(uow);

        }

        [TestMethod]
        public void GetPayment() {

            IEnumerable<Payment> model = this._paymentRepository.FindAll();
        }

       
    }
}
