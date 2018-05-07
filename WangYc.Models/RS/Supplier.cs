using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;

namespace WangYc.Models.RS {
    public class Supplier : EntityBase<int>, IAggregateRoot {

        public Supplier(){}

        public Supplier( string name, string mobilePhone,string note, Users createUser) {

            this.Name = name;
            this.MobilePhone = mobilePhone;
            this.Note = note;
            this.CreateDate = DateTime.Now;
            this.CreateUser = createUser;
            this.IsValid = true;
        }
        
        #region model

        protected override void Validate() {
            throw new NotImplementedException();
        }
    
        public virtual string Name {
            get;
            set;
        }
        public virtual string MobilePhone {
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

        public virtual IList<SupplierProduct> Product {
            get;
            set;
        }

        #endregion

        #region 方法

        public virtual void AddProduct(SupplierProduct model ) {

            if (this.Product == null) {
                this.Product = new List<SupplierProduct>() { };
            }
            this.Product.Add(model);
        }

        #endregion
    }
}
