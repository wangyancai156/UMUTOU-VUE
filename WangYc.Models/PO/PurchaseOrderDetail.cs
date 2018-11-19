using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.BW;
using WangYc.Models.Common;
using WangYc.Models.SD;

namespace WangYc.Models.PO {
    public class PurchaseOrderDetail : EntityBase<int>, IAggregateRoot {

        #region model

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public PurchaseOrderDetail() { }

        public PurchaseOrderDetail(PurchaseOrder purchaseOrder, Product product, int qty, float unitPrice, string note, string createUserId) {

            this.PurchaseOrder = purchaseOrder;
            this.Product = product;
            this.Qty = qty;
            this.UnitPrice = unitPrice;
            this.Note = note;
            this.CreateUserId = createUserId;
            this.IsValid = true;
            this.CreateDate = DateTime.Now;
        }

        public virtual PurchaseOrder PurchaseOrder {
            get;
            set;
        }
        public virtual Product Product {
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

        public virtual IList<PurchaseNotice> PurchaseNotice {
            get;
            set;
        }

        #endregion

        #region 方法

        public virtual void AddPurchaseNotice(string operatorId, int qty) {

            if (this.PurchaseNotice == null) {
                this.PurchaseNotice = new List<PurchaseNotice>();
            }
            PurchaseNotice one = new PurchaseNotice(this, qty, operatorId);
            this.PurchaseNotice.Add(one);
        }

        #endregion


    }
}
    
