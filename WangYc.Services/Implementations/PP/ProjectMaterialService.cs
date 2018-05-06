using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PP;
using WangYc.Models.Repository.PP;
using WangYc.Services.ViewModels.PP;
using WangYc.Services.Mapping.PP;
using WangYc.Services.Messaging.PP;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.PP;

namespace WangYc.Services.Implementations.PP {
    public class ProjectMaterialService : IProjectMaterialService {

        private readonly IProjectMaterialRepository _projectMaterialRepository;
        private readonly IUnitOfWork _uow;
        public ProjectMaterialService(IProjectMaterialRepository ProjectMaterialRepository, IUnitOfWork uow) {

            this._projectMaterialRepository = ProjectMaterialRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectMaterial> GetProjectMaterial(Query request) {

            IEnumerable<ProjectMaterial> model = this._projectMaterialRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectMaterialView> GetProjectMaterialView(Query request) {

            IEnumerable<ProjectMaterial> model = _projectMaterialRepository.FindBy(request);
            return model.ConvertToProjectMaterialView();
        }
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectMaterialView> GetProjectMaterialViewByAll() {

            return this._projectMaterialRepository.FindAll().ConvertToProjectMaterialView();

        }

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectMaterialView> GetProjectMaterialViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<ProjectMaterial>(c => c.Id, id, CriteriaOperator.Equal));
            return this._projectMaterialRepository.FindBy(query).ConvertToProjectMaterialView();

        }
        #endregion

        #region 添加

        public void AddProjectMaterial(AddProjectMaterialRequest request) {

            ProjectMaterial model = this._projectMaterialRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._projectMaterialRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateProjectMaterial(AddProjectMaterialRequest request) {

            ProjectMaterial model = this._projectMaterialRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            this._projectMaterialRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveProjectMaterial(int id) {

            ProjectMaterial model = this._projectMaterialRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._projectMaterialRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
