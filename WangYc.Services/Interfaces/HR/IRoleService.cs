using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels;
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
        /// 获取所有的权限视图
        /// </summary>
        /// <returns></returns>
        RoleView GetRoleView(int roleId);

        /// <summary>
        /// 获取权限树视图
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IList<DataTree> GetRoleTreeView(int roleId);


        #endregion

        #region 添加

        RoleView AddRole(AddRoleRequest request );


        #endregion

        #region 修改

        RoleView UpdateRole(EditRoleRequest request);

        void RelationRigths(int roleid, string[] rightid);
 
        #endregion

        #region 删除

        void DeleteRole(string[] id);

        #endregion

    }
}
