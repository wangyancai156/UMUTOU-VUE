using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.PO;

namespace WangYc.Models.BW {
    public class PurchaseReceiptDetail : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public PurchaseReceiptDetail() { }


        public PurchaseReceiptDetail(PurchaseOrderDetail purchaseOrderDetail, PurchaseReceipt purchaseReceipt, int qty, string note,  bool isValid, string createUserId) {

            this.PurchaseOrderDetail = purchaseOrderDetail;
            this.PurchaseReceipt = purchaseReceipt;
            this.Qty = qty;
            this.Note = note;
            this.IsValid = isValid;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
        }

        public virtual PurchaseReceipt PurchaseReceipt {
            get;
            set;
        }
        public virtual PurchaseOrderDetail PurchaseOrderDetail {
            get;
            set;
        }
        public virtual int Qty {
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
