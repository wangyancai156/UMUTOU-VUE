using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.RS {
    public class AddSupplierRequest {
        
        public int Id { get; set; }
        public string Name { get; set; }

       
        public string MobilePhone {
            get;
            set;
        }
        public string Note {
            get;
            set;
        }

        public bool IsValid {
            get;
            set;
        }
        public string CreateUserId {
            get;
            set;
        }
    }
}
