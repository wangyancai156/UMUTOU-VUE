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
   public  class UsersController : BaseApiController {

        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) {
            this._usersService = usersService;
        }

        [HttpGet]
        public HttpResponseMessage GetUsers([FromUri] SearchUsersRequest request) {

            IEnumerable<UsersView> usersView = _usersService.GetUsersView(request);
            return ToJson(usersView);
        }

        [HttpGet]
        public HttpResponseMessage AddUsers([FromUri] AddUsersRequest request) {
            string result = "";
            try {
                _usersService.InsertUsers(request);
                 result = "添加成功！";
            } catch (Exception ex) {
                result = ex.Message;
            }
            return ToJson(result);

        }

        [HttpGet]
        public HttpResponseMessage DeleteUsers(string id) {

            string result = "";
            string[] ids = id.Split('|');
            this._usersService.DeleteUsers(ids);
            return ToJson(result);
        }

        [HttpGet]
        public HttpResponseMessage UpdateUsers([FromUri] AddUsersRequest request) {

            string result = "";
            try {

                _usersService.UpdateUsers(request);
                result = "修改成功！";
            } catch (Exception ex) {
                result = "修改失败：" + ex.Message;
            }
            return ToJson(result);
        }

        
        [HttpGet]
        public HttpResponseMessage RelationRole(string userId, string roleId) {

            string[] ids = roleId.Split('|');
            this._usersService.RelationRole(userId, ids);
            return ToJson("");
        }
    }
}
