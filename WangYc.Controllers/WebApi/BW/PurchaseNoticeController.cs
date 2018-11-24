using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Messaging.BW;

namespace WangYc.Controllers.WebApi.BW {
    public class PurchaseNoticeController : BaseApiController {

        private readonly IInOutBoundService _inOutBoundService;
        private readonly IPurchaseNoticeService _purchaseNoticeService;

        public PurchaseNoticeController(
                IInOutBoundService inOutBoundService,
                IPurchaseNoticeService purchaseNoticeService
            ) {
            this._inOutBoundService = inOutBoundService;
            this._purchaseNoticeService = purchaseNoticeService;

        }

        /// <summary>
        /// 获取现有库存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponseMessage AddPurchaseReceipt([FromUri]  AddPurchaseReceiptDetailRequest request) {

            return ToJson(this._purchaseNoticeService.AddPurchaseReceipt(request));
        }
    }
}