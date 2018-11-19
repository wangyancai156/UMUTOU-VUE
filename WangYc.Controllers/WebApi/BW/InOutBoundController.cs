using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using WangYc.Controllers.Account.WebApi;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Controllers.WebApi.BW {
    public class InOutBoundController : BaseApiController {

        private readonly IInOutBoundService _inOutBoundService;
        private readonly IPurchaseNoticeService _purchaseNoticeService;

        public InOutBoundController(IInOutBoundService inOutBoundService, IPurchaseNoticeService purchaseNoticeService) {
            this._inOutBoundService = inOutBoundService;
            this._purchaseNoticeService = purchaseNoticeService;

        }
        /// <summary>
        /// 入库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddInBound([FromUri] AddInBoundRequest request) {

            this._inOutBoundService.AddInBound(request);
            return ToJson("入库成功");

        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddOutBound([FromUri] AddOutBoundRequest request) {

            this._inOutBoundService.AddOutBound(request);
            return ToJson("出库成功");

        }
        /// <summary>
        ///  获取现货库存（分页方法）
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public HttpResponseMessage GetSpotInventoryPaged(int pageIndex, int pageSize, int? productid) {
            ListPaged<InBoundView> datalist = this._inOutBoundService.GetSpotInventoryPageList(pageIndex, pageSize, productid);
            return ToJson(datalist);
        }




    }
}
