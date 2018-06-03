using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;
using WangYc.Models.SD;

namespace WangYc.Models.BW {
    public abstract class InOutBound : EntityBase<int>, IAggregateRoot {

        public InOutBound() { }

        public virtual Product Product {
            get;
            set;
        }
        public virtual Warehouse Warehouse {
            get;
            set;
        }
        public virtual InOutReason InOutReason {
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
        public virtual string Note {
            get;
            set;
        }
        public virtual int CurrentQty {
            get;
            set;
        }
        
        public virtual DateTime CreateDate {
            get;
            set;
        }
        public virtual Users User {
            get;
            set;
        }
 
        protected override void Validate() {
            throw new NotImplementedException();
        }
    }

    public class InBound : InOutBound {

        public InBound() { }
        public InBound(Product product, Warehouse warehouse, WarehouseShelf warehouseShelf, InOutReason inOutReason, int qty, float price, string currency
            , string note, Users user
        ) {

            this.Product = product;
            this.Warehouse = warehouse;
            this.InOutReason = inOutReason;
            this.Qty = qty;
            this.CurrentQty = qty;
            this.Price = price;
            this.Currency = currency;
            this.Note = note;
            this.User = user;
            this.CreateDate = DateTime.Now;
            InBoundOfShelf one = new InBoundOfShelf(this, warehouseShelf, qty, note, user.Id);
            this.AddInBoundOfShelf(one);

        }
         
        public virtual IList<OutBound> OutBounds {
            get;
            set;
        }

        public virtual IList<InBoundOfShelf> InBoundOfShelf {
            get;
            set;
        }
        //添加货架入库记录
        public virtual void AddInBoundOfShelf(InBoundOfShelf inBoundOfShelf) {

            if (InBoundOfShelf == null) {
                InBoundOfShelf = new List<InBoundOfShelf>();
            }

            InBoundOfShelf.Add(inBoundOfShelf);
        }
        //添加出库记录
        public virtual void AddOutBound(InOutReason inOutReason, int qty, string note, Users user) {

            if (this.OutBounds == null) {
                this.OutBounds = new List<OutBound>();
            }
            //新建入库记录
            OutBound one = new OutBound(this, inOutReason, qty, note, user);
            //新建货架号出库库记录
            InBoundOfShelf shelf = new InBoundOfShelf();
            if (this.InBoundOfShelf != null) {
                shelf = this.InBoundOfShelf.OrderBy(s=> s.CreateDate).First();
            }
            shelf.AddOutBoundOfShelf(one, qty, note, user.Id);
            //更新现货库存
            shelf.RefreshCurrentQty();
            this.OutBounds.Add(one);
            this.RefreshCurrentQty();
        }

        //刷新换货库存量
        public virtual void RefreshCurrentQty() {
            
            int outqtysum = 0;
            if (this.OutBounds != null) {
                outqtysum = this.OutBounds.Sum(e => e.Qty);
            }
            this.CurrentQty = this.Qty - outqtysum;
        }
    }

    public class OutBound : InOutBound {
        public OutBound() { }
        public OutBound(InBound inBound, InOutReason inOutReason, int qty, string note, Users user) {

            this.InBound = inBound;
            this.Product = inBound.Product;
            this.Warehouse = inBound.Warehouse;
            this.InOutReason = inOutReason;
            this.Qty = qty;
            this.Price = inBound.Price;
            this.Currency = inBound.Currency;
            this.Note = note;
            this.User = user;
            this.CreateDate = DateTime.Now;
  
        }

        public virtual InBound InBound {
            get;
            set;
        }
        public virtual IList<OutBoundOfShelf> OutBoundOfShelf {
            get;
            set;
        }
      

    }
}
