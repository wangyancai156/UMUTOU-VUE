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
using WangYc.Models.Repository.HR;
using WangYc.Models.HR;
using WangYc.Models.SD;
using WangYc.Models.Repository.SD;

namespace WangYc.Services.Implementations.PP {
    public class ProjectService : IProjectService {

        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTypeRepository _projectTypeRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;
        public ProjectService(IProjectRepository ProjectRepository, IProjectTypeRepository projectTypeRepository, IUsersRepository usersRepository, IProductRepository productRepository, IUnitOfWork uow) {

            this._projectRepository = ProjectRepository;
            this._projectTypeRepository = projectTypeRepository;
            this._usersRepository = usersRepository;
            this._productRepository = productRepository;
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

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="request"></param>
        public void AddProject(AddProjectRequest request) {

            ProjectType type = this._projectTypeRepository.FindBy(request.ProjectTypeId);
            if (type == null) {
                throw new EntityIsInvalidException<string>(request.ProjectTypeId.ToString());
            }
            Users charge = this._usersRepository.FindBy(request.ChargeId);
            if (charge == null) {
                throw new EntityIsInvalidException<string>(request.ChargeId.ToString());
            }
            Users approve = this._usersRepository.FindBy(request.ApproveId);
            if (approve == null) {
                throw new EntityIsInvalidException<string>(request.ApproveId.ToString());
            }
            Users createUser = this._usersRepository.FindBy(request.CreateUserId);
            if (createUser == null) {
                throw new EntityIsInvalidException<string>(request.CreateUserId.ToString());
            }
            Project model = new Project(type, charge, approve, request.Note, createUser);
           
            this._projectRepository.Add(model);
            this._uow.Commit();
        }
        /// <summary>
        /// 添加项目原料
        /// </summary>
        /// <param name="request"></param>
        public void AddMaterial(AddProjectMaterialRequest request) {

            Project model = this._projectRepository.FindBy(request.ProjectId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.ProjectId.ToString());
            }
            Product product = this._productRepository.FindBy(request.ProductId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.ProductId.ToString());
            }
            Users createUser = this._usersRepository.FindBy(request.CreateUserId);
            if (createUser == null) {
                throw new EntityIsInvalidException<string>(request.CreateUserId.ToString());
            }

            ProjectMaterial material = new ProjectMaterial(model, product,request.Qty, createUser);
            model.AddMaterial(material);

            this._projectRepository.Add(model);
            this._uow.Commit();
        }

        /// <summary>
        /// 添加员工考核
        /// </summary>
        /// <param name="request"></param>
        public void AddAttendance(AddProjectAttendanceRequest request) {

            Project model = this._projectRepository.FindBy(request.ProjectId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.ProjectId.ToString());
            }
            Users user = this._usersRepository.FindBy(request.UsersId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.UsersId.ToString());
            }
            Users createUser = this._usersRepository.FindBy(request.CreateUserId);
            if (createUser == null) {
                throw new EntityIsInvalidException<string>(request.CreateUserId.ToString());
            }

            ProjectAttendance material = new ProjectAttendance(model, user, createUser);
            model.AddAttendance(material);

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
