using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Controllers.WebApi.BW {
    public class ArrivalNoticeController:BaseApiController {

        private readonly IInOutBoundService _inOutBoundService;
        private readonly IArrivalNoticeService _arrivalNoticeService;
        private readonly IArrivalReceiptService _arrivalReceiptService;

        public ArrivalNoticeController(
                IInOutBoundService inOutBoundService,
                IArrivalNoticeService arrivalNoticeService,
            IArrivalReceiptService arrivalReceiptService
            ) {
            this._inOutBoundService = inOutBoundService;
            this._arrivalNoticeService = arrivalNoticeService;
            this._arrivalReceiptService = arrivalReceiptService;
        }
        /// <summary>
        /// 获取到货通知
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponseMessage GetArrivalNoticePage( [FromUri]  GeArrivalNoticeRequest request ) {

            ListPaged<ArrivalNoticeView> list = this._arrivalNoticeService.GetArrivalNoticePageView(request);
            return ToJson(list);
        }

        /// <summary>
        /// 获取到货通知明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetArrivalNoticeDetail( [FromUri] int id ) {
            IEnumerable<ArrivalNoticeDetailView> model = this._arrivalNoticeService.GetArrivalNoticeDetailView(id);
            return ToJson(model);
        }

        /// <summary>
        /// 添加到货
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponseMessage AddArrivalReceipt( [FromUri]  AddArrivalReceiptDetailRequest request ) {

            return ToJson(this._arrivalNoticeService.AddArrivalReceiptDetail(request));
        }

        /// <summary>
        /// 获取已到货列表
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GeArrivalReceiptDetailView( string purchaseId,int pageIndex,int pageSize,string sort ) {

            ListPaged<ArrivalReceiptDetailView> model = this._arrivalReceiptService.GetArrivalReceiptDetailView(purchaseId,pageIndex,pageSize,sort);
            return ToJson(model);
        }

    }
}