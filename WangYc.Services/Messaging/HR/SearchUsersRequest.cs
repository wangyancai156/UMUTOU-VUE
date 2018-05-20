using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.HR {
    public class SearchUsersRequest {

        public int OrganizationId { get; set; }
        public string Name { get; set; }

    }
}
