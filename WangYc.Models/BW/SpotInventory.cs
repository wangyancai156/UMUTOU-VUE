using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.SD;

namespace WangYc.Models.BW {
    public class SpotInventory : EntityBase<int>, IAggregateRoot {

        protected override void Validate() {
            throw new NotImplementedException();
        }
        #region model

        public SpotInventory() { }
        public SpotInventory(Product product, Warehouse warehouse, int qty, float price, string currency) {

            this.Product = product;
            this.Warehouse = warehouse;
            this.Qty = qty;
            this.Price = price;
            this.Currency = currency;
          
        }

        public virtual Product Product {
            get;
            set;
        }
        public virtual Warehouse Warehouse {
            get;
            set;
        }
      
        public virtual int Qty {
            get;
            set;
        }
        public virtual float Price {
            get;
            set;
        }
        public virtual string Currency {
            get;
            set;
        }

        #endregion


        #region 方法

        public virtual void InBound(int qty, float price) {

            this.Qty = this.Qty + qty;
            this.Price = ((price * qty) + (this.Qty * this.Price)) / (this.Qty + qty);
        }
        public virtual void OutBound(int qty) {

            this.Qty = this.Qty - qty;
        }

        #endregion
    }
}
