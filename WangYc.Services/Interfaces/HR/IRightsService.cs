using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.HR;
using WangYc.Services.Messaging.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Interfaces.HR {
    public interface IRightsService {

        #region 查询
        IEnumerable<Rights> GetRights();
        Rights GetRightsById(int id);
        IEnumerable<Rights> GetRightsById(string[] rightsIdList);

        IList<DataTree> GetRightsTreeView();

        IEnumerable<RightsView> GetRightsView(int id);

        IEnumerable<RightsView> GetRightsViewByRole(int roleid);


        #endregion

        RightsView AddRights(AddRightsRequest request);
        RightsView UpdateRights(int id, string name,string url, string description, bool isshow);
        void DeleteRights(int id);

    }
}
