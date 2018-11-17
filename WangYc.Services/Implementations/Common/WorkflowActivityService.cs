using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Common;
using WangYc.Models.Repository.Common;
using WangYc.Services.Messaging.Common;
using WangYc.Services.ViewModels.Common;
using WangYc.Services.Mapping.Common;
using WangYc.Services.Interfaces.Common;

namespace WangYc.Services.Implementations.Common {
    public class WorkflowActivityService : IWorkflowActivityService {

        private readonly IWorkflowActivityRepository _workflowActivityRepository;
        private readonly IUnitOfWork _uow;
        public WorkflowActivityService(IWorkflowActivityRepository workflowActivityRepository, IUnitOfWork uow) {

            this._workflowActivityRepository = workflowActivityRepository;
            this._uow = uow;
        }

        public void InsertNewActivity(AddWorkflowActivityRequest request) {

            //插入新活动前，先保存当前所处活动
            WorkflowActivity activityBeforUpdate = GetCurrentActivity(request.ObjectId);
            
            WorkflowActivity activity = new WorkflowActivity(request.ObjectId, request.ObjectTypeId,request.WorkflowNodeId,request.CreateUserId, activityBeforUpdate);

            this._workflowActivityRepository.Save(activity);

            if (activityBeforUpdate != null) {
                activityBeforUpdate.EndTime = DateTime.Now;
                this._workflowActivityRepository.Save(activityBeforUpdate);
            }
            this._uow.Commit();
        }

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <param name="linkObjectId"></param>
        /// <returns></returns>
        public WorkflowActivity GetCurrentActivity(string objectId) {

            WorkflowActivity activity = null;
            Query query = new Query();
            query.Add(Criterion.Create<WorkflowActivity>(a => a.Id, objectId, CriteriaOperator.Equal));
            query.Add(Criterion.Create<WorkflowActivity>(a => a.EndTime, null, CriteriaOperator.IsNull));

            activity = this._workflowActivityRepository.FindBy(query).FirstOrDefault();
            return activity;
        }
        /// <summary>
        /// 获取所有历史状态
        /// </summary>
        /// <param name="linkObjectId"></param>
        /// <returns></returns>
        public IEnumerable<WorkflowActivityView> GetCurrentActivityHistory(string objectId) {
            Query query = new Query();
            query.Add(Criterion.Create<WorkflowActivity>(a => a.Id, objectId, CriteriaOperator.Equal));
            return this._workflowActivityRepository.FindBy(query).ConvertToWorkflowActivityView();
        }
    }
}