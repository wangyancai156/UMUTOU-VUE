using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.HR {
    public class RightsController : BaseApiController {

        private readonly IRightsService _rightsService;
        public RightsController(IRightsService rightsService) {

            this._rightsService = rightsService;
        }


        /// <summary>获取权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRightsView(int id ) {

            IEnumerable<RightsView> rights = this._rightsService.GetRightsView(id);
            return ToJson(rights);
        }
        [HttpGet]
        public HttpResponseMessage AddRights([FromUri] AddRightsRequest request) {

            RightsView rights = this._rightsService.AddRights(request);
            return ToJson(rights);
        }

        /// <summary>删除组织
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteRights(int id) {

            this._rightsService.DeleteRights(id);
            return ToJson("");
        }
        /// <summary>修改组织
        /// 修改组织
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage EditRights([FromUri] AddRightsRequest request) {
 
            RightsView rights = this._rightsService.UpdateRights(request.Id, request.Name, request.Url, request.Description, request.IsShow);
            return ToJson(rights);
        }



    }
}
