using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.FI;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels.RS;

namespace WangYc.Services.ViewModels.PO {
    public class PurchaseOrderView {

        public string Id {
            get;
            set;
        }
        public IEnumerable<PurchaseOrderDetailView> Detail {
            get;
            set;
        }
        public PurchaseTypeView PurchaseType {
            get;
            set;
        }
        public PaymentTypeView PaymentType {
            get;
            set;
        }

        public SupplierView Supplier {
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
        public UsersView CreateUser {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createdate;
        public string CreateDate {
            get { return createdate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { createdate = Convert.ToDateTime(value); }
        }

    }
}
