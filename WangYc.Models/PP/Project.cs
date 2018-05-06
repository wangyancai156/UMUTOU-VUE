using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.HR;

namespace WangYc.Models.PP {
    public class Project : EntityBase<int>, IAggregateRoot {

        public Project() { }

        public Project(ProjectType type, Users charge, Users approve,string note , Users createUser) {

            this.Type = type;
            this.Charge = charge;
            this.Approve = approve;
            this.Note = note;
            this.State = 1;
            this.CreateUser = createUser;
            this.CreateDate = DateTime.Now;
               
        }

        #region model
        protected override void Validate() {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 项目类型
        /// </summary>
        public virtual ProjectType Type {
            get;
            set;
        }
        /// <summary>
        /// 负责人
        /// </summary>
        public virtual Users Charge {
            get;
            set;
        }
        /// <summary>
        /// 审批人
        /// </summary>
        public virtual Users Approve {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual int State {
            get;
            set;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual Users CreateUser {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate {
            get;
            set;
        }

        public virtual IList<ProjectAttendance> Attendance {
            get;
            set;
        }

        public virtual IList<ProjectMaterial> Material {
            get;
            set;
        }

        public virtual IList<ProjectProduct> Product {
            get;
            set;
        }
        #endregion


        #region 方法

        #region 原料

        public virtual void AddMaterial(ProjectMaterial model) {

            if (this.Material == null) {
                this.Material = new List<ProjectMaterial>() { };
            }
            this.Material.Add(model);
        }

        #endregion

        #region 员工考勤

        public virtual void AddAttendance(ProjectAttendance model) {

            if (this.Attendance == null) {
                this.Attendance = new List<ProjectAttendance>() { };
            }
            this.Attendance.Add(model);
        }

        #endregion

        #region 产物

        public virtual void AddProduct(ProjectProduct model) {

            if (this.Product == null) {
                this.Product = new List<ProjectProduct>() { };
            }
            this.Product.Add(model);
        }

        #endregion

        #endregion

    }
}
