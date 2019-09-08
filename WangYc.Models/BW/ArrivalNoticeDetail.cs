using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.BW;
using WangYc.Models.PO;
using WangYc.Models.SD;

namespace WangYc.Models.BW {
    public class ArrivalNoticeDetail : EntityBase<int>, IAggregateRoot {

        #region model 

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public ArrivalNoticeDetail() { }

        public ArrivalNoticeDetail(PurchaseOrderDetail purchaseOrder, Product product ,int qty, string createUserId) {

            this.PurchaseOrderDetail = purchaseOrder;
            this.Product = product;
            this.Qty = qty;
            this.CreateUserId = createUserId;
            this.State = 1;
            this.CreateDate = DateTime.Now;
        }

        public virtual ArrivalNotice ArrivalNotice {
            get;
            set;
        }
        public virtual PurchaseOrderDetail PurchaseOrderDetail {
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
    
        public virtual string Note {
            get;
            set;
        }
        public virtual int State {
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

        public virtual IList<ArrivalReceiptDetail> ReceiptDetail {
            get;
            set;
        }

        #endregion

        #region 方法

        public virtual void AddReceiptDetail( ArrivalReceipt purchaseReceipt, int qty, string note, string createUserId ) {

            if (this.ReceiptDetail == null) {
                this.ReceiptDetail = new List<ArrivalReceiptDetail>() { };
            }
            ArrivalReceiptDetail model = new ArrivalReceiptDetail(this, purchaseReceipt, qty, note, createUserId);
            this.ReceiptDetail.Add(model);

            //添加完到货后如果到货的数量和 采购的数量一致，则调整采购状态到完结
            this.ArrivalQty = this.ReceiptDetail.Sum(s => s.Qty);
            
            //如果到货单和通知单相同 则到货单的状态改为已完结
            if (this.Qty == ArrivalQty) {
                this.State = 2;
            }
        }
        #endregion
    }
}

