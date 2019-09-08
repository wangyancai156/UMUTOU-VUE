using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.BW {
    public class ArrivalReceiptDetailView {


        public int ArrivalReceiptId {
            get;
            set;
        }
        public int PurchaseOrderDetailId {
            get;
            set;
        }
        public int Qty {
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
