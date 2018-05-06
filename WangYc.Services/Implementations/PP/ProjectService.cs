using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PP;
using WangYc.Models.Repository.PP;
using WangYc.Services.Messaging.PP;
using WangYc.Services.ViewModels.PP;
using WangYc.Services.Mapping.PP;
using WangYc.Services.Interfaces.PP;

namespace WangYc.Services.Implementations.PP {
    public class ProjectService : IProjectService {

        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _uow;
        public ProjectService(IProjectRepository ProjectRepository, IUnitOfWork uow) {

            this._projectRepository = ProjectRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetProject(Query request) {

            IEnumerable<Project> model = this._projectRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectView> GetProjectView(Query request) {

            IEnumerable<Project> model = _projectRepository.FindBy(request);
            return model.ConvertToProjectView();
        }
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectView> GetProjectViewByAll() {

            return this._projectRepository.FindAll().ConvertToProjectView();

        }

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectView> GetProjectViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<Project>(c => c.Id, id, CriteriaOperator.Equal));
            return this._projectRepository.FindBy(query).ConvertToProjectView();

        }
        #endregion

        #region 添加

        public void AddProject(AddProjectRequest request) {

            Project model = this._projectRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._projectRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateProject(AddProjectRequest request) {

            Project model = this._projectRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            this._projectRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveProject(int id) {

            Project model = this._projectRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._projectRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
