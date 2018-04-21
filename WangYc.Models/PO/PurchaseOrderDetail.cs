using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.PO {
    public class PurchaseOrderDetail : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual PurchaseOrder PurchaseOrder {
            get;
            set;
        }
        public virtual int Product {
            get;
            set;
        }
        public virtual int Qty {
            get;
            set;
        }
        public virtual float UnitPrice {
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
    
