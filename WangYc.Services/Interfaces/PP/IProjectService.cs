using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Interfaces.PP {
     public interface IProjectService {


        #region 查找
 
        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectView> GetProjectView(Query request);


        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectView> GetProjectViewByAll();


        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectView> GetProjectViewById(int id);
        #endregion

        #region 添加

        void AddProject(AddProjectRequest request);

        #endregion

        #region 修改

        void UpdateProject(AddProjectRequest request);

        #endregion

        #region 删除
        void RemoveProject(int id);

        #endregion
    }
}
