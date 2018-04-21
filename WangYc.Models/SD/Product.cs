using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.SD {
    public class Product : EntityBase<int>, IAggregateRoot {

        public Product() { }

        public Product(string chineseName, string englishName, float price
                , string currency, string note, ProductType type
        ) {

            this.ChineseName = chineseName;
            this.EnglishName = englishName;
            this.Price = price;
            this.Currency = currency;
            this.Type = type;
            this.Note = note;
            this.CreateDate = DateTime.Now;

        }

        public virtual string ChineseName {
            get;
            set;
        }
        public virtual string EnglishName {
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
        public virtual ProductType Type {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }

        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}
