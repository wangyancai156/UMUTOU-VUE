using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.BW;
using WangYc.Services.Implementations.BW;
using WangYc.Services.Implementations.Common;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Interfaces.Common;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Tests.BW {

    [TestClass]
    public class ArrivalReceiptTest {


        private readonly IArrivalReceiptRepository _arrivalReceiptRepository;
        private readonly IArrivalReceiptDetailRepository _arrivalReceiptDetailRepository;
        private readonly IArrivalReceiptService _arrivalReceiptService;

        private readonly IArrivalNoticeRepository _arrivalNoticeRepository;
        private readonly IArrivalNoticeDetailRepository _arrivalNoticeDetailRepository;
        private readonly IArrivalNoticeService _arrivalNoticeService;

        private readonly IWorkflowActivityService _workflowActivityService;
        public ArrivalReceiptTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._arrivalReceiptRepository = new ArrivalReceiptRepository(uow);
            this._arrivalReceiptDetailRepository = new ArrivalReceiptDetailRepository(uow);
            this._arrivalReceiptService = new ArrivalReceiptService(this._arrivalReceiptRepository, this._arrivalReceiptDetailRepository, uow);

            this._workflowActivityService = new WorkflowActivityService(null ,uow);

            this._arrivalNoticeRepository = new ArrivalNoticeRepository(uow);
            this._arrivalNoticeDetailRepository = new ArrivalNoticeDetailRepository(uow);
            this._arrivalNoticeService = new ArrivalNoticeService(this._arrivalNoticeRepository, this._arrivalNoticeDetailRepository, this._arrivalReceiptService, this._workflowActivityService, uow);

           
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }


        [TestMethod]
        public void GetArrivalNotice() {
 
            GeArrivalNoticeRequest request = new GeArrivalNoticeRequest();
            request.PageIndex = 1;
            request.PageSize = 10;
            request.Sate = 1;
            ListPaged<ArrivalNoticeView> model = this._arrivalNoticeService.GetArrivalNoticePageView(request);
           
        }

        [TestMethod]
        public void GetArrivalNoticeDetail() {
             
           IEnumerable< ArrivalNoticeDetailView>  a = this._arrivalNoticeService.GetArrivalNoticeDetailView(1);
        } 
    }
}
