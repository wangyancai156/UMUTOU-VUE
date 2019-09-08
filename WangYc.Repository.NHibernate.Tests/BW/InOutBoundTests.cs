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
        private readonly IArrivalReceiptRepository _arrivalReceiptRepository;
        private readonly IArrivalReceiptDetailRepository _arrivalReceiptDetailRepository;
        private readonly IInOutReasonRepository _inOutReasonRepository;
        private readonly ISpotInventoryRepository _spotInventoryRepository;


        public InOutBoundTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._inOutBoundRepository = new InOutBoundRepository(uow);
            this._arrivalReceiptRepository = new ArrivalReceiptRepository(uow);
            this._arrivalReceiptDetailRepository = new ArrivalReceiptDetailRepository(uow);
            this._inOutReasonRepository = new InOutReasonRepository(uow);
            this._spotInventoryRepository = new SpotInventoryRepository(uow);
        }

        [TestMethod]
        public void GetInOutBound() {

            IEnumerable<InOutBound> model = this._inOutBoundRepository.FindAll();
        }


        [TestMethod]
        public void GetArrivalReceipt() {

            IEnumerable<ArrivalReceipt> model = this._arrivalReceiptRepository.FindAll();
        }


        [TestMethod]
        public void GetArrivalReceiptDetail() {

            IEnumerable<ArrivalReceiptDetail> model = this._arrivalReceiptDetailRepository.FindAll();
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