using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.PO;

namespace WangYc.Models.BW {
    public class ArrivalReceiptDetail : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public ArrivalReceiptDetail() { }


        public ArrivalReceiptDetail(ArrivalNoticeDetail purchaseNoticeDetail, ArrivalReceipt purchaseReceipt, int qty, string note, string createUserId) {

            this.ArrivalNoticeDetail = purchaseNoticeDetail;
            this.ArrivalReceipt = purchaseReceipt;
            this.Qty = qty;
            this.Note = note;
            this.IsValid = true;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
        }

        public virtual ArrivalReceipt ArrivalReceipt {
            get;
            set;
        }
        public virtual ArrivalNoticeDetail ArrivalNoticeDetail {
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
