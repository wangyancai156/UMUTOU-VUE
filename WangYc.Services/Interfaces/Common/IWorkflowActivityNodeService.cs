using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.Common;

namespace WangYc.Services.Interfaces.Common {
    public interface IWorkflowActivityNodeService {

        PurchaseWorkflowActivityNode GetPurchaseWorkflowActivityNode(string id);
    }
}
