using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.FI;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.FI;
using WangYc.Services.Implementations.FI;
using WangYc.Services.Interfaces.FI;

namespace WangYc.Services.Tests.FI {
    [TestClass]
    public class PaymentTests {

        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IPaymentTypeService _paymentTypeService;

        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;
        public PaymentTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._paymentTypeRepository = new PaymentTypeRepository(uow);
            this._paymentTypeService = new PaymentTypeService(this._paymentTypeRepository, uow);

            this._paymentRepository = new PaymentRepository(uow);
            this._paymentService = new PaymentService(this._paymentRepository, uow);


        }

        [TestMethod]
        public void GetPayment() {

            this._paymentService.GetPaymentViewByAll();
        }

        [TestMethod]
        public void GetPaymentType() {

            this._paymentTypeService.GetPaymentTypeViewByAll();

        }
    }
}
