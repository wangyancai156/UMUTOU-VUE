using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PP;
using WangYc.Models.Repository.PP;
using WangYc.Services.Interfaces.PP;
using WangYc.Services.ViewModels.PP;
using WangYc.Services.Mapping.PP;
using WangYc.Services.Messaging.PP;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Services.Implementations.PP {
    public class ProjectTypeService : IProjectTypeService {

        private readonly IProjectTypeRepository _projectTypeRepository;
        private readonly IUnitOfWork _uow;
        public ProjectTypeService(IProjectTypeRepository ProjectTypeRepository, IUnitOfWork uow) {

            this._projectTypeRepository = ProjectTypeRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectType> GetProjectType(Query request) {

            IEnumerable<ProjectType> model = this._projectTypeRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectTypeView> GetProjectTypeView(Query request) {

            IEnumerable<ProjectType> model = _projectTypeRepository.FindBy(request);
            return model.ConvertToProjectTypeView();
        }
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectTypeView> GetProjectTypeViewByAll() {

            return this._projectTypeRepository.FindAll().ConvertToProjectTypeView();

        }

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectTypeView> GetProjectTypeViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<ProjectType>(c => c.Id, id, CriteriaOperator.Equal));
            return this._projectTypeRepository.FindBy(query).ConvertToProjectTypeView();

        }
        #endregion

        #region 添加

        public void AddProjectType(AddProjectTypeRequest request) {

            ProjectType model = this._projectTypeRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._projectTypeRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateProjectType(AddProjectTypeRequest request) {

            ProjectType model = this._projectTypeRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            this._projectTypeRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveProjectType(int id) {

            ProjectType model = this._projectTypeRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._projectTypeRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
