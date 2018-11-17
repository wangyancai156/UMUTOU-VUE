using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.ViewModels.PO {
    public class PurchaseOrderDetailView {
        public int Id { get; set; }
        public ProductView Product { get; set; }

        public int Qty { get; set; }

        public float UnitPrice { get; set; }

        public string Note { get; set; }

        public string CreateUserId { get; set; }

        private DateTime createdate;
        public string CreateDate {
            get { return createdate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { createdate = Convert.ToDateTime(value); }
        }

    }
}
