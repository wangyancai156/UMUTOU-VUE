using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.SD {
    public class ProductType : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }
        public ProductType() { }


        public ProductType(string name) {

            this.Name = name;
            this.CreateDate = DateTime.Now;
        }

        public virtual string Name {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }
    }
}
