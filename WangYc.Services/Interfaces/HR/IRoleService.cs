using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IRoleService {

        #region 查询

        /// <summary>
        /// 根据ID获取岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Role GetRole(int id);
        /// <summary>
        /// 根据ID数据获取岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Role> GetRole(string[] id);
        /// <summary>
        /// 根据权限ID获取权限的功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<RightsView> GetRoleRights(int id);
        /// <summary>
        /// 获取权限中没有的功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<RightsView> GetRoleRightsNotIn(int roleid, int rightid);
        /// <summary>
        /// 获取所有的权限视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleView> GetRoleView(int organizationId);
       

        #endregion

        #region 添加

        RoleView AddRole(int organizationid, string name, string description, string rightsIds);


        #endregion

        #region 修改

        RoleView UpdateRole(AddRoleRequest request);

        void RelationRigths(int roleid, string[] rightid);

        void CancelRelationRigths(int roleid, string[] rightid);

        #endregion

        #region 删除

        void DeleteRole(string[] id);

        #endregion

    }
}
