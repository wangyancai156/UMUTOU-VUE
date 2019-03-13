using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Controllers.WebApi.Account;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.Messaging.BW;

namespace WangYc.Controllers.WebApi.BW {
     
    public class SpotInventoryController : BaseApiController {

        private ISpotInventoryService _spotInventoryService;

        public SpotInventoryController(ISpotInventoryService spotInventoryService) {
            this._spotInventoryService = spotInventoryService;

        }

        /// <summary>
        /// 获取现有库存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpResponseMessage GetSpotInventory([FromUri]  GetSpotInventoryRequest request) {

          return ToJson( this._spotInventoryService.GetSpotInventory(request)); ;
        }
    }
}
