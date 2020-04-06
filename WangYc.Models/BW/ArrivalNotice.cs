using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;
using WangYc.Models.SD;

namespace WangYc.Models.BW {
    public class ArrivalNotice:EntityBase<int>, IAggregateRoot {

        #region 属性

        public ArrivalNotice() { }


        public ArrivalNotice( ArrivalNoticeType arrivalNoticeType,string objectId,int warehouseId,Users createUser ) {
            this.ArrivalNoticeType = arrivalNoticeType;
            this.ObjectId = objectId;
            this.WarehouseId = warehouseId;
            this.CreateUser = createUser;
            this.CreateDate = DateTime.Now;
            this.State = 1;
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }
        public virtual ArrivalNoticeType ArrivalNoticeType {
            get;
            set;
        }
        public virtual string ObjectId {
            get;
            set;
        }
        public virtual int WarehouseId {
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

        public virtual Users CreateUser {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }

        public virtual IList<ArrivalNoticeDetail> ArrivalNoticeDetail {
            get;
            set;
        }

        #endregion

        #region 方法 
        public virtual void AddArrivalNoticeDetail( string operatorId,int itemId,Product product,int qty ) {

            if(this.ArrivalNoticeDetail == null) {
                this.ArrivalNoticeDetail = new List<ArrivalNoticeDetail>();
            }
            ArrivalNoticeDetail one = new ArrivalNoticeDetail(this,itemId,product,qty,operatorId);
            this.ArrivalNoticeDetail.Add(one);
        }

        public virtual void RefreshState() {
            int counts = this.ArrivalNoticeDetail.Count(s => s.State == 1);
            if(counts ==0) {
                this.State = 2;
            }
        }

        #endregion

    }
}
