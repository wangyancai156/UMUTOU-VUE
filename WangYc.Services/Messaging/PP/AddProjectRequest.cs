using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PP {
    public class AddProjectRequest {

        public int Id { get; set; }

        public int ProjectTypeId { get; set; }

        public string ChargeId { get; set; }

        public string ApproveId { get; set; }

        public string CreateUserId { get; set; }
        public string Note { get; set; }

    }
}
