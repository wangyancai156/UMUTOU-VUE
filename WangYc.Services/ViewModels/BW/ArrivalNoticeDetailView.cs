using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.ViewModels.BW {
   public class ArrivalNoticeDetailView {

        public int Id { get; set; }

        public virtual ProductView Product {
            get;
            set;
        }

        public virtual int Qty {
            get;
            set;
        }
         
        public virtual int ArrivalQty {
            get;
            set;
        }

        public virtual string Note {
            get;
            set;
        }
        public virtual int State {
            get;
            set;
        }
    }
}
