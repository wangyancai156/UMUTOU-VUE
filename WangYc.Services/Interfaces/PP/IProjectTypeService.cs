using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.PP;
using WangYc.Services.Messaging.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Interfaces.PP {
     public interface IProjectTypeService {

        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectType> GetProjectType(Query request);
        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectTypeView> GetProjectTypeView(Query request);
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectTypeView> GetProjectTypeViewByAll();

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectTypeView> GetProjectTypeViewById(int id);
        #endregion

        #region 添加

        void AddProjectType(AddProjectTypeRequest request);

        #endregion

        #region 修改

        void UpdateProjectType(AddProjectTypeRequest request);

        #endregion

        #region 删除
        void RemoveProjectType(int id);

        #endregion
    }
}
