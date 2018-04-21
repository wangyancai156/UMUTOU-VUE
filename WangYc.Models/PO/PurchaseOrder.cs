using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.FI;
using WangYc.Models.RS;

namespace WangYc.Models.PO {
    public class PurchaseOrder : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<PurchaseOrderDetail> Detail {
            get;
            set;
        }
        public virtual PurchaseType PurchaseType {
            get;
            set;
        }
        public virtual PaymentType PaymentType {
            get;
            set;
        }

        public virtual Supplier Supplier {
            get;
            set;
        }
        public virtual string Note {
            get;
            set;
        }
        public virtual bool IsValid {
            get;
            set;
        }
        public virtual string CreateUserId {
            get;
            set;
        }
        
        public virtual DateTime CreateDate {
            get;
            set;
        }

      
    }
}
