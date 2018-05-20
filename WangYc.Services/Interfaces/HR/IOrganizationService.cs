using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IOrganizationService {
        #region 查询
        IEnumerable<DataTreeView> GetOrganizationTreeView();
        Organization GetOrganization(int id);
        IEnumerable<OrganizationView> GetOrganizationView(int id);

        IList<int> GetOrganizationChildNode(int id);
   
        #endregion

        OrganizationView AddOrganizationChild(int id, string name, string description);

        OrganizationView UpdateOrganization(int id, string name, string description);

        void DeleteOrganization(int id);
    }
}
