using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Repository.NHibernate.Repositories.BW;

namespace WangYc.Repository.NHibernate.Tests.BW {
    [TestClass]
    public class InOutBoundTests {

        private readonly IInOutBoundRepository _inOutBoundRepository;
        private readonly IPurchaseReceiptRepository _purchaseReceiptRepository;
        private readonly IPurchaseReceiptDetailRepository _purchaseReceiptDetailRepository;
        private readonly IInOutReasonRepository _inOutReasonRepository;
        private readonly ISpotInventoryRepository _spotInventoryRepository;


        public InOutBoundTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._inOutBoundRepository = new InOutBoundRepository(uow);
            this._purchaseReceiptRepository = new PurchaseReceiptRepository(uow);
            this._purchaseReceiptDetailRepository = new PurchaseReceiptDetailRepository(uow);
            this._inOutReasonRepository = new InOutReasonRepository(uow);
            this._spotInventoryRepository = new SpotInventoryRepository(uow);
        }

        [TestMethod]
        public void GetInOutBound() {

            IEnumerable<InOutBound> model = this._inOutBoundRepository.FindAll();
        }


        [TestMethod]
        public void GetPurchaseReceipt() {

            IEnumerable<PurchaseReceipt> model = this._purchaseReceiptRepository.FindAll();
        }


        [TestMethod]
        public void GetPurchaseReceiptDetail() {

            IEnumerable<PurchaseReceiptDetail> model = this._purchaseReceiptDetailRepository.FindAll();
        }

        [TestMethod]
        public void GetInOutReason() {

            IEnumerable<InOutReason> model = this._inOutReasonRepository.FindAll();
        }

        [TestMethod]
        public void GetSpotInventory() {

            IEnumerable<SpotInventory> model = this._spotInventoryRepository.FindAll();
        }
    }
}