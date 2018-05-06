using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.PP {
    public class Project : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual int TypeId {
            get;
            set;
        }
        public virtual string ChargeId {
            get;
            set;
        }

        public virtual string ApproveId {
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
        
    }
}
