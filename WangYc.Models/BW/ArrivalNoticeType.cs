using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.BW {
    public class ArrivalNoticeType:EntityBase<int>, IAggregateRoot {

        public ArrivalNoticeType() { }

        public ArrivalNoticeType(int id , string name ) {
            this.Id = id;
            this.Name = name;
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual string Name {
            get;
            set;
        }
    }
}
