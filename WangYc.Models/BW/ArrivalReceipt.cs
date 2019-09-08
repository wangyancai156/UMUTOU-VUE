using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.BW {
    public class ArrivalReceipt : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {//  ArrivalReceipt 
            throw new NotImplementedException();
        }
        #region model

        public ArrivalReceipt() { }
        public ArrivalReceipt(string note, bool isValid, string createUserId) {

            this.Note = note;
            this.IsValid = isValid;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
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
        public virtual IList<ArrivalReceiptDetail> Detail {
            get;
            set;
        }
        #endregion

        #region 事件

        public virtual void AddDetail(ArrivalReceiptDetail detail) {

            if (this.Detail == null) {
                this.Detail = new List<ArrivalReceiptDetail> { };
            }
            this.Detail.Add(detail);
        }

        #endregion

    }
}
