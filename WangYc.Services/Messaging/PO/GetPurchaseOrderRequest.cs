using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PO {
    public class GetPurchaseOrderRequest {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string StatuId { get; set; }
    }
}
