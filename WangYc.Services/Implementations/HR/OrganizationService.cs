using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;

using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
 
using WangYc.Services.Mapping.HR;
using WangYc.Services.Interfaces.HR;

using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels;
using WangYc.Core.Infrastructure.Domain;


namespace WangYc.Services.Implementations.HR {
    public class OrganizationService : IOrganizationService {

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUnitOfWork _uow;

        public OrganizationService(IOrganizationRepository organizationRepository, IUnitOfWork uow)
        {
            this._organizationRepository = organizationRepository;
            this._uow = uow;
           
        }

        #region 查询
        public IEnumerable<DataTree> GetOrganizationTreeView() {
            
            Query query = new Query();
            query.Add(Criterion.Create<Organization>(c => c.Id, 0, CriteriaOperator.Equal));
            return this._organizationRepository.FindBy(query).ConvertToDataTreeView();
        }

        public Organization GetOrganization(int id) {

            return this._organizationRepository.FindBy(id);
        }
        public IEnumerable<OrganizationView> GetOrganizationView(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<Organization>(c => c.Id, id, CriteriaOperator.Equal));
            return this._organizationRepository.FindBy(query).ConvertToOrganizationView();
        }

        public IList<int> GetOrganizationChildNode(int id) {

            IList<int> result = new List<int>();
            Query query = new Query();
            query.Add(Criterion.Create<Organization>(c => c.Id, id, CriteriaOperator.Equal));
            IEnumerable<Organization> org = this._organizationRepository.FindBy(query);
            return GetOrganizationNode(org);
        }
        private IList<int> GetOrganizationNode(IEnumerable<Organization> org) {

            IList<int> result = new List<int>();
            foreach (Organization item in org) {
                result.Add(item.Id);
                if (item.Child.Count > 0) {
                    IList<int> child = GetOrganizationNode(item.Child);
                    foreach (int childitem in child) {
                        result.Add(childitem);
                    }
                }
            }
            return result;
        }

        #endregion


        #region 添加

        public OrganizationView AddOrganizationChild(int id, string name, string description) {

            Organization organization = this._organizationRepository.FindBy(id);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }

            Organization result = organization.AddChild(name, description);
            this._uow.Commit();
            return result.ConvertToOrganizationView();
        }
        
        #endregion

        #region 修改

        public OrganizationView UpdateOrganization(int id, string name, string description) {

            Organization organization = this._organizationRepository.FindBy(id);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }

            organization.UpdateOrganization(name, description);
            this._uow.Commit();
            return organization.ConvertToOrganizationView();
        }

        #endregion

        #region 删除

        public void DeleteOrganization(int id) { 

            Organization organization = this._organizationRepository.FindBy(id);
            if (organization == null) {
                throw new EntityIsInvalidException<string>(organization.ToString());
            }
            this._organizationRepository.Remove(organization);
            this._uow.Commit();
        }
        #endregion
    }
}
