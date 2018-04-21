using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WangYc.Controllers.Account.WebApi;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Controllers.WebApi.BW
{
    public  class InOutBoundController : BaseApiController
    {
        private IInOutBoundService _inOutBoundService;
      
        public InOutBoundController(IInOutBoundService inOutBoundService )
        {
            this._inOutBoundService = inOutBoundService;
            
        }
 

        /// <summary>
        ///  获取现货库存（分页方法）
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        public HttpResponseMessage GetSpotInventoryPaged(int pageIndex, int pageSize, int? productid)
        {
            ListPaged<InBoundView> datalist = this._inOutBoundService.GetSpotInventoryPageList(pageIndex, pageSize, productid);
            return ToJson(datalist);
        }
 

    }
}
