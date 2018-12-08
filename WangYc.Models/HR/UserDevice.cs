using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    public class UserDevice : EntityBase<int>, IAggregateRoot {
        public UserDevice() { }
        protected override void Validate() {
            throw new NotImplementedException();
        }

        public virtual string UserId { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime ActiveTime { get; set; }

        public virtual DateTime ExpiredTime { get; set; }

        public virtual string DeviceType { get; set; }

        public virtual string SessionKey { get; set; }

    }
}