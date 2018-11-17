using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PO {
    public class AddPurchaseOrderRequest {

        public string Id {
            get;
            set;
        }
        public int PurchaseTypeId {
            get;
            set;
        }
        public int SupplierId {
            get;
            set;
        }
        public int PaymentTypeId {
            get;
            set;
        }
        public string Note {
            get;
            set;
        }
        public string CreateUserId {
            get;
            set;
        }
 
    }
}
