using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;

namespace WangYc.Models.BW {
    public class ArrivalNotice : EntityBase<int>, IAggregateRoot {
        protected override void Validate() {
            throw new NotImplementedException();
        }
        public virtual string ArrivalNoticeTypeId {
            get;
            set;
        }
        public virtual string ObjectId {
            get;
            set;
        }
        public virtual string WarehouseId {
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

        public virtual Users CreateUser {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }
 
    }
}
