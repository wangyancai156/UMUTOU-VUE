using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PO {
   public class AddPurchaseTypeRequest {

        public int Id {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public string Note {
            get;
            set;
        }
    }
}
