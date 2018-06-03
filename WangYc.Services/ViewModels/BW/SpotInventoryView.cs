using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.BW {
     public class SpotInventoryView {

        public virtual int ProductId {
            get;
            set;
        }
        public virtual string ProductChineseName {
            get;
            set;
        }

        public virtual string WarehouseId {
            get;
            set;
        }

        public virtual string WarehouseName {
            get;
            set;
        }

        public virtual int Qty {
            get;
            set;
        }
        public virtual float Price {
            get;
            set;
        }
        public virtual string Currency {
            get;
            set;
        }

    }
}
