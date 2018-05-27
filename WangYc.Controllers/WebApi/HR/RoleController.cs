﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.HR {
    public class RoleController : BaseApiController {

        private readonly IRoleService _roleService;
        private readonly IRightsService _rightsService;
        public RoleController(IRoleService roleService, IRightsService rightsService) {

            this._roleService = roleService;
            this._rightsService = rightsService;
        }

        #region 角色管理
        [HttpGet]
        public HttpResponseMessage GetRoleView(int organizationId) {

            IEnumerable<RoleView> model = this._roleService.GetRoleView(organizationId);
            return ToJson(model);
        }
        [HttpGet]
        public HttpResponseMessage AddRole([FromUri] AddRoleRequest request) {

            int organization = Convert.ToInt32(request.Organizationid);
            RoleView model = this._roleService.AddRole(organization, request.Name, request.Description, request.Name);
            return ToJson(model);
        }
        [HttpGet]
        public HttpResponseMessage DeleteRole(string id) {
            string result = "";
            string[] ids = id.Split('|');
            try {
                this._roleService.DeleteRole(ids);
                result = "删除成功";
            } catch (Exception ex) {
                result = "删除失败：" + ex.Message;
            }
            return ToJson(result);
        }
        [HttpGet]
        public HttpResponseMessage UpdateRole([FromUri] AddRoleRequest request) {
            string result = "";
            try {
                this._roleService.UpdateRole(request);
                result = "删除成功";
            } catch (Exception ex) {
                result = "删除失败：" + ex.Message;
            }
            return ToJson(result);
        }
        #endregion


        #region 权限功能
       
      
        [HttpGet]
        public HttpResponseMessage GetRoleRightsNotIn(int roleid, int rightid) {
            
            IEnumerable<RightsView> model = this._roleService.GetRoleRightsNotIn(roleid, rightid); 
            return ToJson(model);
        }
        
        [HttpGet]
        public HttpResponseMessage GetRoleRights(int id) {

            IEnumerable<RightsView> model = this._roleService.GetRoleRights(id);
            return ToJson(model);
        }
        [HttpGet]
        public HttpResponseMessage RelationRigths(int roleId, string rightid) {
            string[] ids = rightid.Split('|');
           
            this._roleService.RelationRigths(roleId, ids);
            return ToJson("");
        }
        [HttpGet]
        public HttpResponseMessage CancelRelationRigths(int roleId, string rightid) {

            string[] ids = rightid.Split('|');
            this._roleService.CancelRelationRigths(roleId, ids);
            return ToJson("");
        }
        [HttpGet]
        public HttpResponseMessage GetRightsTreeView() {

            IList<DataTree> model = this._rightsService.GetRightsTreeView();
            return ToJson(model);
        }

        #endregion

    }
}
