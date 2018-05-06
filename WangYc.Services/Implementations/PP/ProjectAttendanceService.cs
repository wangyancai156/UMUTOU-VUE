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
using WangYc.Services.ViewModels.PP;
using WangYc.Services.Messaging.PP;
using WangYc.Services.Mapping.PP;
using WangYc.Services.Interfaces.PP;

namespace WangYc.Services.Implementations.PP {
    public class ProjectAttendanceService : IProjectAttendanceService {

        private readonly IProjectAttendanceRepository _projectAttendanceRepository;
        private readonly IUnitOfWork _uow;
        public ProjectAttendanceService(IProjectAttendanceRepository ProjectAttendanceRepository, IUnitOfWork uow) {

            this._projectAttendanceRepository = ProjectAttendanceRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectAttendance> GetProjectAttendance(Query request) {

            IEnumerable<ProjectAttendance> model = this._projectAttendanceRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectAttendanceView> GetProjectAttendanceView(Query request) {

            IEnumerable<ProjectAttendance> model = _projectAttendanceRepository.FindBy(request);
            return model.ConvertToProjectAttendanceView();
        }
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectAttendanceView> GetProjectAttendanceViewByAll() {

            return this._projectAttendanceRepository.FindAll().ConvertToProjectAttendanceView();

        }

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectAttendanceView> GetProjectAttendanceViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<ProjectAttendance>(c => c.Id, id, CriteriaOperator.Equal));
            return this._projectAttendanceRepository.FindBy(query).ConvertToProjectAttendanceView();

        }
        #endregion

        #region 添加

        public void AddProjectAttendance(AddProjectAttendanceRequest request) {

            ProjectAttendance model = this._projectAttendanceRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._projectAttendanceRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateProjectAttendance(AddProjectAttendanceRequest request) {

            ProjectAttendance model = this._projectAttendanceRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            this._projectAttendanceRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveProjectAttendance(int id) {

            ProjectAttendance model = this._projectAttendanceRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._projectAttendanceRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
