using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.Common;
using WangYc.Services.Messaging.Common;
using WangYc.Services.ViewModels.Common;

namespace WangYc.Services.Interfaces.Common {
    public interface IWorkflowActivityService {

        void InsertNewActivity(AddWorkflowActivityRequest request);

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <param name="linkObjectId"></param>
        /// <returns></returns>
        WorkflowActivity GetCurrentActivity(string objectId);

        /// <summary>
        /// 获取所有历史状态
        /// </summary>
        /// <param name="linkObjectId"></param>
        /// <returns></returns>
        IEnumerable<WorkflowActivityView> GetCurrentActivityHistory(string objectId);
    }
}
