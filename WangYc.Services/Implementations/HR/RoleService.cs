using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Mapping.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.ViewModels;

namespace WangYc.Services.Implementations.HR {
    public class RoleService : IRoleService {

        private readonly IRoleRepository _roleRepository;
        private readonly IRightsService _rightsService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _uow;

        public RoleService(IRoleRepository roleRepository, IRightsService rightsService, IOrganizationRepository organizationRepository, IUnitOfWork uow) {

            this._roleRepository = roleRepository;
            this._rightsService = rightsService;
            this._organizationRepository = organizationRepository;
            this._uow = uow;
        }

        #region 查询

        /// <summary>
        /// 根据ID获取岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRole(int id) {

            return this._roleRepository.FindBy(id); ;
        }
        /// <summary>
        /// 根据ID数组获取岗位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Role> GetRole(string[] id) {

            int[] ids = Array.ConvertAll<string, int>(id, s => int.Parse(s));

            Query query = new Query();
            if (ids.Length > 0)
                query.Add(Criterion.Create<Role>(p => p.Id, ids, CriteriaOperator.InOfInt32));

            IEnumerable<Role> model = _roleRepository.FindBy(query);
            return model;
        }

        /// <summary>
        /// 获取所有的权限视图
        /// </summary>
        /// <returns></returns>
        public RoleView GetRoleView(int roleId) {

            Role role = this._roleRepository.FindBy(roleId);
            return role.ConvertToRoleView();
        }
    
        /// <summary>
        /// 获取所有的权限视图
        /// </summary>
        /// <returns></returns>
        public IList<DataTree> GetRoleTreeView(int roleId) {
            
            Query query = new Query();
            query.Add(Criterion.Create<Role>(c => c.Id, roleId, CriteriaOperator.Equal));
            IEnumerable<Role> role = _roleRepository.FindBy(query);
            return role.ConvertToDataTreeView();
        }

        #endregion

        #region 添加

        public RoleView AddRole(AddRoleRequest request) {

            Role model = this._roleRepository.FindBy(request.ParentId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.ParentId.ToString());
            }
            model.AddChild(request.Name, request.Description);
            this._uow.Commit();
            return model.ConvertToRoleView();
        }


        #endregion

        #region 修改

        /// <summary>
        /// 修改岗位
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleView UpdateRole(EditRoleRequest request) {

            Role model = this._roleRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(model.ToString());
            }

            model.UpdateRole(request.Name, request.Description);
            this._uow.Commit();
            return model.ConvertToRoleView();
        }

        /// <summary>
        /// 为岗位添加功能
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="rightid"></param>
        public void RelationRigths(int roleid, string[] rightid) {

            Role model = this.GetRole(roleid);
            if (model == null) {
                throw new EntityIsInvalidException<string>(roleid.ToString());
            }
            model.Rights.Clear();
            IEnumerable<Rights> list = this._rightsService.GetRights(rightid);
            model.AddRights(list);
            this._uow.Commit();
        }
 

        #endregion

        #region 删除

        public void DeleteRole(string[] id) {

            List<Role> model = this.GetRole(id).ToList();
            if (model == null) {
                throw new EntityIsInvalidException<string>(model.ToString());
            }
            foreach (Role item in model) {
                item.IsValid = false;
                this._roleRepository.Save(item);
            }
            this._uow.Commit();
        }
        #endregion


    }
}