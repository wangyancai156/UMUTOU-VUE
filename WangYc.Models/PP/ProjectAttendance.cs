using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;

namespace WangYc.Models.PP {
    public class ProjectAttendance : EntityBase<int>, IAggregateRoot {
        
        protected override void Validate() {
            throw new NotImplementedException();
        }

        public ProjectAttendance (){}
        public ProjectAttendance(Project project, Users user, Users createUser) {

            this.Project = project;
            this.User = user;
            this.CreateUser = createUser;
            this.IsValid = true;
            this.CreateDate = DateTime.Now;  
        }

        public virtual Project Project { get; set; }
        public virtual Users User { get; set; }
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
