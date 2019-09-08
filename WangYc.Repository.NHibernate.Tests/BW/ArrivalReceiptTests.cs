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
    public class ArrivalReceiptTests {

        private readonly IArrivalReceiptRepository _arrivalReceiptRepository;
        private readonly IArrivalReceiptDetailRepository _arrivalReceiptDetailRepository;
        private readonly IArrivalNoticeDetailRepository _arrivalNoticeDetailRepository;
        private readonly IArrivalNoticeRepository _arrivalNoticeRepository;
        public ArrivalReceiptTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._arrivalReceiptRepository = new ArrivalReceiptRepository(uow);
            this._arrivalReceiptDetailRepository = new ArrivalReceiptDetailRepository(uow);
            this._arrivalNoticeDetailRepository = new ArrivalNoticeDetailRepository(uow);
            this._arrivalNoticeRepository = new ArrivalNoticeRepository(uow);
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
        public void GetArrivalNotice() {

            IEnumerable<ArrivalNotice> model = this._arrivalNoticeRepository.FindAll();
        }

        [TestMethod]
        public void GetArrivalNoticeDetail() {

            IEnumerable<ArrivalNoticeDetail> model = this._arrivalNoticeDetailRepository.FindAll();
        }

    }
}
