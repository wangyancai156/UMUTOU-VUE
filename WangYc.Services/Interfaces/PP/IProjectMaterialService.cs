using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Interfaces.PP {
    public interface IProjectMaterialService {

        #region 查找

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectMaterialView> GetProjectMaterialView(Query request);
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectMaterialView> GetProjectMaterialViewByAll();

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectMaterialView> GetProjectMaterialViewById(int id);
        #endregion

        #region 添加

        void AddProjectMaterial(AddProjectMaterialRequest request);

        #endregion

        #region 修改

        void UpdateProjectMaterial(AddProjectMaterialRequest request);

        #endregion

        #region 删除
        void RemoveProjectMaterial(int id);

        #endregion
    }
}
