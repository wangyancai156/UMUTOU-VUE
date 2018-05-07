using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;

namespace WangYc.Models.PO {
    public class PurchaseType : EntityBase<int>, IAggregateRoot {

        public PurchaseType() { }

        public PurchaseType(string description, string note, Users createUser) {

            this.Description = description;
            this.Note = note;
            this.CreateDate = DateTime.Now;
            this.CreateUser = createUser;
        }

        #region model

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual string Description {
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
        #endregion
         

    }
}
