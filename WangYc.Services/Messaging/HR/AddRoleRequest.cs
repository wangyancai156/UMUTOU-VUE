using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.HR {
    public class AddRoleRequest {

        public int ParentId { get;set; }
  
        public string Name { get; set; }
         
        public string Description { get; set; }

    }
}
