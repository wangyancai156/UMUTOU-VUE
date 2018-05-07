using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PP {
    public class AddProjectProductRequest {
        public int Id { get; set; }
        
        public int ProjectId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public string CreateUserId { get; set; }

        
    }
}
