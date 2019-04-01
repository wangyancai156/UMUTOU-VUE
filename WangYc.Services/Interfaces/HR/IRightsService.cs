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
    public interface IRightsService {

        #region 查询

        #region 查询对象

        /// <summary>
        /// 根据ID获取功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Rights GetRights(int id);
        /// <summary>
        /// 根据ID数据获取功能列表
        /// </summary>
        /// <param name="rightsIdList"></param>
        /// <returns></returns>
         IEnumerable<Rights> GetRights(string[] rightsIdList);
        #endregion

        #region 查询视图

        RightsView GetRightsView(int id);

        IEnumerable<RightsView> GetRightsIsLeafView(int id);

        
        IEnumerable<RightsView> GetRightsViewByRole(int roleid);

        #endregion

        #region 查询树
        /// <summary>
        /// 获取功能树视图
        /// </summary>
        /// <returns></returns>
        IList<DataTree> GetRightsTreeView();

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        IList<Menu> GetMenuView(string userid);

        #endregion

        #endregion

        RightsView AddRights(AddRightsRequest request);
        RightsView UpdateRights(int id, string name,string url, string description, bool isshow);
        void DeleteRights(int id);

    }
}
