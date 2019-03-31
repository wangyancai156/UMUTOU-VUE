using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR
{
    public interface IUsersService
    {
        IEnumerable<UsersView> GetUsersView(SearchUsersRequest request);

        UsersView FindUsersBy(string userid);
        /// <summary>
        ///  用户登录时查询
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        UsersView FindUsersBy(string username, string pass);

        Users GetUsers(string id);

        void DeleteUsers(string [] userid);

        void InsertUsers(AddUsersRequest user);

        void UpdateUsers(AddUsersRequest request);

        void RelationRole(string userId, string[] roleId);
        /// <summary>
        ///  更新最后登录时间
        /// </summary>
        /// <param name="userId">用户编号</param>
        void UpdateLastLoginTime(string userId);
    }
}
