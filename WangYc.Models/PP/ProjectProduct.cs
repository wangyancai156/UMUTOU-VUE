using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;
using WangYc.Models.SD;

namespace WangYc.Models.PP {
    public class ProjectProduct : EntityBase<int>, IAggregateRoot {

        public ProjectProduct(){}

        public ProjectProduct(Project project , Product product, int qty, Users createUser) {

            this.Project = project;
            this.Product = product;
            this.Qty = qty;
            this.CreateUser = createUser;
            this.CreateDate = DateTime.Now;
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual Project Project { get; set; }
        public virtual Product Product { get; set; }

        public virtual int Qty { get; set; }
 
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
