using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;
using WangYc.Models.SD;

namespace WangYc.Models.RS {
    public class SupplierProduct : EntityBase<int>, IAggregateRoot {

        public SupplierProduct() { }

        public SupplierProduct(Supplier supplier, Product product, decimal price, Users createUser) {

            this.Supplier = supplier;
            this.Product = product;
            this.Price = price;
            this.CreateUser = createUser;
            this.CreateDate = DateTime.Now;
            this.IsValid = true;
        }

        #region model

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual Supplier Supplier {
            get;
            set;
        }
        public virtual Product Product {
            get;
            set;
        }
        public virtual decimal Price {
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

        #endregion

    }
}
