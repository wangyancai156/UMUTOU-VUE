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
        #region model

        public PurchaseOrder() { }


        public PurchaseOrder( PurchaseType purchaseType, PaymentType paymentType, Supplier supplier, string createUserId,string note ) {

            this.PurchaseType = purchaseType;
            this.PaymentType = paymentType;
            this.Supplier = supplier;
            this.Note = note;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
        }

     
        public virtual IList<PurchaseOrderDetail> Detail {
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

        #endregion


        #region 方法

        /// <summary>
        /// 添加采购明细
        /// </summary>
        /// <param name="detail"></param>
        public virtual void AddDetail(PurchaseOrderDetail detail) {

            if (this.Detail == null) {
                this.Detail = new List<PurchaseOrderDetail>(){ };
            }
            this.Detail.Add(detail);

        }
        #endregion


    }
}
