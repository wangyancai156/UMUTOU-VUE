using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Interfaces.PP {
     public  interface IProjectProductService {

        #region 查找
 
        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectProductView> GetProjectProductView(Query request);
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectProductView> GetProjectProductViewByAll();

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectProductView> GetProjectProductViewById(int id);
        #endregion

        #region 添加

        void AddProjectProduct(AddProjectProductRequest request);
        #endregion

        #region 修改

        void UpdateProjectProduct(AddProjectProductRequest request);

        #endregion

        #region 删除
        void RemoveProjectProduct(int id);

        #endregion

    }
}
