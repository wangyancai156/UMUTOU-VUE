using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.Common {
   public class WorkflowActivityNode : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual string StatusId { get; set; }
        public virtual string StatusName { get; set; }
        public virtual string StatusNote { get; set; }
        public virtual string WorkFlowType { get; set; }
       
    }
}