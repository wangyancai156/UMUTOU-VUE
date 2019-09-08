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
    public class ArrivalNoticeController : BaseApiController {

        private readonly IInOutBoundService _inOutBoundService;
        private readonly IArrivalNoticeService _purchaseNoticeService;
        private readonly IPurchaseReceiptService _purchaseReceiptService;

        public ArrivalNoticeController(
                IInOutBoundService inOutBoundService,
                IArrivalNoticeService purchaseNoticeService,
            IPurchaseReceiptService purchaseReceiptService
            ) {
            this._inOutBoundService = inOutBoundService;
            this._purchaseNoticeService = purchaseNoticeService;
            this._purchaseReceiptService = purchaseReceiptService;
        }
        /// <summary>
        /// 获取到货通知
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponseMessage GetPurchaseOrderViewByStatus([FromUri]  GeArrivalNoticeRequest request) {

            ListPaged<ArrivalNoticeView> list = this._purchaseNoticeService.GetPurchaseOrderViewByStatus(request);
            return ToJson(list);
        }


        /// <summary>
        /// 添加到货
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponseMessage AddPurchaseReceipt([FromUri]  AddPurchaseReceiptDetailRequest request) {

            return ToJson(this._purchaseNoticeService.AddPurchaseReceipt(request));
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
        public HttpResponseMessage GePurchaseReceiptDetailView(string purchaseId, int pageIndex, int pageSize, string sort) {

            ListPaged<PurchaseReceiptDetailView> model = this._purchaseReceiptService.GetPurchaseReceiptDetailView(purchaseId, pageIndex, pageSize, sort);
            return ToJson(model);
        }
        
    }
}