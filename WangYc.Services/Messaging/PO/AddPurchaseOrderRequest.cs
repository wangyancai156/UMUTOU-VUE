using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PO {
    public class AddPurchaseOrderRequest {

        public int Id {
            get;
            set;
        }
        public int PurchaseOrderDetailId {
            get;
            set;
        }
        public int PurchaseTypeId {
            get;
            set;
        }
        public int PaymentTypeId {
            get;
            set;
        }

        public int  SupplierId {
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

        public DateTime CreateDate {
            get;
            set;
        }

    }
}
