using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.HR {
    public class OrganizationController : BaseApiController {

        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService) {

            this._organizationService = organizationService;
        }

        /// <summary>
        /// 获取组织树结构
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetOrganizationTree() {

            IEnumerable<DataTree> organization = this._organizationService.GetOrganizationTreeView();
            return ToJson(organization);

        }
        
        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetOrganizationView(int id) {

            IEnumerable<OrganizationView> organization = this._organizationService.GetOrganizationView(id);
            return ToJson(organization);

        }

        /// <summary>
        /// 添加组织子节点
        /// </summary>
        /// <param name="id">f父节点Id</param>
        /// <param name="name">节点名称</param>
        /// <param name="description">节点说明</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddOrganization(int ParentId, string Name, string Description) {

            OrganizationView organization = this._organizationService.AddOrganizationChild(ParentId, Name, Description);
            return ToJson(organization);
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteOrganization(string id) {

            string[] ids = id.Split('|');
            foreach (string i in ids ) {

                if (i != "") {
                    this._organizationService.DeleteOrganization( Convert.ToInt32(i));
                }
            }
           
            return ToJson("");
        }

        /// <summary>
        /// 修改组织
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UpdateOrganization(int id, string name, string description) {

            OrganizationView organization = this._organizationService.UpdateOrganization(id, name, description);
            return ToJson(organization);
        }

    }
}
