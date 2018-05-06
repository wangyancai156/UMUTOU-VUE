using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.PP {
   public class ProjectType : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual string Description { get; set; }
        public virtual string Note { get; set; }

        public virtual decimal LaborCost { get; set; }
        public virtual bool IsValid { get; set; }

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
