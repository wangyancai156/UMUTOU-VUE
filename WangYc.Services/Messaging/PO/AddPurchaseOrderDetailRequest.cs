using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PO {
    public class AddPurchaseOrderDetailRequest {
        public int Id {
            get;
            set;
        }
        public int PurchaseOrderId {
            get;
            set;
        }
        public int ProductId {
            get;
            set;
        }
        public int Qty {
            get;
            set;
        }
        public float UnitPrice {
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
