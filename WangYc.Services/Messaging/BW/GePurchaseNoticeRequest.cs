using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.BW {
    public class GeArrivalNoticeRequest {
        
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int? ProductId { get; set; }
        public int? WarehouseId { get; set; }
        public int? Sate { get; set; }
        public int?  ArrivalNoticeTypeId { get; set; }

    }
}
