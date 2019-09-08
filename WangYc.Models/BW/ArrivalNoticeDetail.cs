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

        public ArrivalNoticeDetail(PurchaseOrderDetail purchaseOrder, int qty, string createUserId) {

            this.PurchaseOrderDetail = purchaseOrder;
            this.Qty = qty;
            this.CreateUserId = createUserId;
            this.IsValid = true;
            this.CreateDate = DateTime.Now;
        }

        public virtual PurchaseOrderDetail PurchaseOrderDetail {
            get;
            set;
        }
        
        public virtual int Qty {
            get;
            set;
        }

        int arrivalQty;
        public virtual int ArrivalQty {
            get {
                int var = this.ReceiptDetail.Sum(s => s.Qty);
                return var;
            }
            set {
                arrivalQty = value;
            }
        }

        public virtual int Product {
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

        public virtual IList<ArrivalReceiptDetail> ReceiptDetail {
            get;
            set;
        }

        #endregion

        #region 方法

        public virtual void AddReceiptDetail(PurchaseOrderDetail purchaseOrderDetail, ArrivalReceipt purchaseReceipt, int qty, string note, string createUserId ) {

            if (this.ReceiptDetail == null) {
                this.ReceiptDetail = new List<ArrivalReceiptDetail>() { };
            }
            ArrivalReceiptDetail model = new ArrivalReceiptDetail(this, purchaseReceipt, qty, note, createUserId);
            this.ReceiptDetail.Add(model);

            //添加完到货后如果到货的数量和 采购的数量一致，则调整采购状态到完结
            this.ArrivalQty = this.ReceiptDetail.Sum(s => s.Qty);
        }


        #endregion
    }
}

