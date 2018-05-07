using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PO;
using WangYc.Models.Repository.PO;
using WangYc.Repository.NHibernate.Repositories.PO;

namespace WangYc.Repository.NHibernate.Tests.PO {
    [TestClass]
    public class PurchaseOrderTests {

        private readonly IPurchaseOrderRepository _purchaseOrderRepoistroy;

        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepoistroy;

        private readonly IPurchaseTypeRepository _purchaseTypeRepoistroy;

        public PurchaseOrderTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._purchaseOrderRepoistroy = new PurchaseOrderRepository(uow);
            this._purchaseOrderDetailRepoistroy = new PurchaseOrderDetailRepository(uow);
            this._purchaseTypeRepoistroy = new PurchaseTypeRepository(uow);
        }

        [TestMethod]
        public void GetPurchaseOrder() {

            IEnumerable<PurchaseOrder> model = this._purchaseOrderRepoistroy.FindAll();
        }

        [TestMethod]
        public void GetPurchaseOrderDetail() {

            IEnumerable<PurchaseOrderDetail> model = this._purchaseOrderDetailRepoistroy.FindAll();
        }

        [TestMethod]
        public void GetPurchaseType() {

            IEnumerable<PurchaseType> model = this._purchaseTypeRepoistroy.FindAll();
        }

    }
}
