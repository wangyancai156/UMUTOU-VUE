using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.FI;
using WangYc.Models.Repository.HR;
using WangYc.Models.Repository.PO;
using WangYc.Models.Repository.RS;
using WangYc.Models.Repository.SD;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.FI;
using WangYc.Repository.NHibernate.Repositories.HR;
using WangYc.Repository.NHibernate.Repositories.PO;
using WangYc.Repository.NHibernate.Repositories.RS;
using WangYc.Repository.NHibernate.Repositories.SD;
using WangYc.Services.Implementations.PO;
using WangYc.Services.Interfaces.PO;
using WangYc.Services.Mapping.PO;

namespace WangYc.Services.Tests.PO {

    [TestClass]
    public class PurchaseOrderTest {

        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseTypeRepository _purchaseTypeRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUsersRepository _uersRepository;
        private readonly IPurchaseTypeService _purchaseTypeService;

        public PurchaseOrderTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._purchaseOrderRepository = new PurchaseOrderRepository(uow);
            this._purchaseTypeRepository = new PurchaseTypeRepository(uow);
            this._paymentTypeRepository = new PaymentTypeRepository(uow);
            this._supplierRepository = new SupplierRepository(uow);
            this._productRepository = new ProductRepository(uow);
            this._uersRepository = new UsersRepository(uow);
            this._purchaseTypeService = new PurchaseTypeService(this._purchaseTypeRepository, this._uersRepository, uow);
            this._purchaseOrderService = new PurchaseOrderService(this._purchaseOrderRepository, this._purchaseTypeRepository, this._paymentTypeRepository, this._supplierRepository, this._productRepository, uow);
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }

        [TestMethod]
        public void GetPurchaseOrder() {

            this._purchaseOrderRepository.FindAll().ConvertToPurchaseOrderView();
        }

        [TestMethod]
        public void GetPurchaseType() {

            this._purchaseTypeService.GetPurchaseTypeViewByAll();
        }
    }
}
