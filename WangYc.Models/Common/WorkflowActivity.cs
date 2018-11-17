using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.Common {
    public class WorkflowActivity : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }
        public WorkflowActivity() { }

        public WorkflowActivity(string objectId, string objectTypeId, string workflowNodeId, string createUserId, WorkflowActivity parent) {

            this.ObjectId = objectId;
            this.ObjectTypeId = objectTypeId;
            this.WorkflowNodeId = workflowNodeId;
            this.StartTime = DateTime.Now;
            this.CreateUserId = createUserId;
            this.StartTime = DateTime.Now;
            this.EndTime = (DateTime?)null;
            this.Parent = parent;
        }

        public virtual string ObjectId { get; set; }
        public virtual string ObjectTypeId { get; set; }
        public virtual string WorkflowNodeId { get; set; }
        public virtual string Note { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime? EndTime { get; set; }
        public virtual string CreateUserId { get; set; }
        public virtual WorkflowActivity Parent { get; set; }



    }
}