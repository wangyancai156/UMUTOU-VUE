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

        public virtual string ObjectId { get; set; }
        public virtual int ObjectTypeId { get; set; }
        public virtual int WorkflowNodeId { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string CreateUserId { get; set; }
        public virtual int ParentId { get; set; }



    }
}