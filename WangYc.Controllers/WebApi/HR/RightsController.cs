using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.HR {
    public class RightsController : BaseApiController {

        private readonly IRightsService _rightsService;
        public RightsController(IRightsService rightsService) {

            this._rightsService = rightsService;
        }

        #region 查询

        /// <summary>
        /// 获取组织树结构（没有叶子节点的）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRightsTreeNoLeafView() {

            IList<DataTree> organization = this._rightsService.GetRightsTreeNoLeafView();
            return ToJson(organization);

        }
  
        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRightsView(int id) {

            RightsView rights = this._rightsService.GetRightsView(id);
            return ToJson(rights);
        }

        /// <summary>
        /// 获取功能列表，只搜索子节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRightsIsLeafView(int id) {

            IEnumerable<RightsView> rights = this._rightsService.GetRightsIsLeafView(id);
            return ToJson(rights);
        }

        

        #endregion

        #region 编辑

        [HttpGet]
        public HttpResponseMessage AddRights([FromUri] AddRightsRequest request) {

            RightsView rights = this._rightsService.AddRights(request);
            return ToJson(rights);
        }

        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteRights(int id) {

            this._rightsService.DeleteRights(id);
            return ToJson("");
        }
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UpdateRights([FromUri] AddRightsRequest request) {
 
            RightsView rights = this._rightsService.UpdateRights(request.Id, request.Name, request.Url, request.Description, request.IsShow);
            return ToJson(rights);
        }

        #endregion

    }
}
