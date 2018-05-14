using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.Common {
    public  class AddWorkflowActivityRequest {

        public string ObjectId { get; set; }
        public string ObjectTypeId { get; set; }
        public string WorkflowNodeId { get; set; }
        public string Note { get; set; }
        public string CreateUserId { get; set; }
       
    }
}
