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
        /// 获取功能列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRightsView(int id) {

            RightsView rights = this._rightsService.GetRightsView(id);
            return ToJson(rights);
        }


        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetMenuView(string userId) {

            IList<Menu> rights = this._rightsService.GetMenuView(userId);
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
        public HttpResponseMessage DeleteRights(string id) {
            string[] ids = id.Split('|');
            foreach (string i in ids) {

                if (i != "") {
                    this._rightsService.DeleteRights(Convert.ToInt32(i));
                }
            }
          
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
 
            RightsView rights = this._rightsService.UpdateRights( request);
            return ToJson(rights);
        }

        #endregion

    }
}
