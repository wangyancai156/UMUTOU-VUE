using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;
using WangYc.Models.SD;

namespace WangYc.Models.PP {
    public class ProjectMaterial : EntityBase<int>, IAggregateRoot {

        public ProjectMaterial() { }

        public ProjectMaterial(Project project, Product product, int qty, Users createUser) {

            this.Project = project;
            this.Product = product;
            this.Qty = qty;
            this.CreateUser = createUser;
            this.IsValid = true;
            this.CreateDate = DateTime.Now;
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual Project Project { get; set; }

        public virtual Product Product { get; set; }

        public virtual int Qty { get; set; }

        public virtual bool IsValid { get; set; }

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
