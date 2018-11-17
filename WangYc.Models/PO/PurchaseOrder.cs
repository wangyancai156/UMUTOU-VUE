using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.Common;
using WangYc.Models.FI;
using WangYc.Models.RS;

namespace WangYc.Models.PO {
    public class PurchaseOrder : EntityBase<string>, IAggregateRoot {

      
        #region model

        public PurchaseOrder() { }


        public PurchaseOrder(PurchaseType purchaseType, PaymentType paymentType, Supplier supplier, string createUserId, string note) {

            this.PurchaseType = purchaseType;
            this.PaymentType = paymentType;
            this.Supplier = supplier;
            this.Note = note;
            this.CreateUserId = createUserId;
            this.CreateDate = DateTime.Now;
            this.IsValid = true;
            this.StatuId = "PO-010";
         
        }


        public virtual IList<PurchaseOrderDetail> Detail {
            get;
            set;
        }
        public virtual PurchaseType PurchaseType {
            get;
            set;
        }
        public virtual PaymentType PaymentType {
            get;
            set;
        }

        public virtual Supplier Supplier {
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
        public virtual string CreateUserId {
            get;
            set;
        }

        public virtual DateTime CreateDate {
            get;
            set;
        }
  
        public virtual string StatuId {
            get;
            set;
        }
        public virtual IList<WorkflowActivity> WorkflowActivity {
            get;
            set;
        }



        #endregion

        #region 方法

        #region 采购明细
        /// <summary>
        /// 添加采购明细
        /// </summary>
        /// <param name="detail"></param>
        public virtual void AddDetail(PurchaseOrderDetail detail) {

            if (this.Detail == null) {
                this.Detail = new List<PurchaseOrderDetail>(){ };
            }
            this.Detail.Add(detail);

        }

        public virtual void RemoveDetail( int itemid) {

            if (this.Detail == null) {
                foreach (PurchaseOrderDetail one in this.Detail) {
                    if (one.Id == itemid) {
                        one.IsValid = false;
                    }
                }
            }
        }
        #endregion

        #region 流程
        

        public virtual void Initial(string operatorId) {

            if (this.WorkflowActivity == null) {
                this.WorkflowActivity = new List<WorkflowActivity>();
            }
            WorkflowActivity activity = new WorkflowActivity(this.Id, "PurchaseOrder", "PO-010", operatorId, null);
            this.WorkflowActivity.Add(activity);
        }

        public virtual void Apply(string operatorId) {

            this.StatuId = "PO-020";
            WorkflowActivity beforActivity = this.WorkflowActivity.Where(s => s.EndTime == null).Last();
            beforActivity.EndTime = DateTime.Now;

            WorkflowActivity activity = new WorkflowActivity(this.Id, "PurchaseOrder", "PO-020", operatorId, beforActivity);
            this.WorkflowActivity.Add(activity);
        }

        public virtual void Approval(string operatorId) {

            this.StatuId = "PO-030";
            WorkflowActivity beforActivity = new WorkflowActivity();
            IEnumerable<WorkflowActivity> list = this.WorkflowActivity.Where(s => s.EndTime == null);
            if (list.Count() > 0) {
                beforActivity = list.Last();
                beforActivity.EndTime = DateTime.Now;
            }

            WorkflowActivity activity = new WorkflowActivity(this.Id, "PurchaseOrder", "PO-030", operatorId, beforActivity);
            this.WorkflowActivity.Add(activity);
        }

        public virtual void Reject(string operatorId) {

            this.StatuId = "PO-021";
            WorkflowActivity beforActivity = new WorkflowActivity();
            IEnumerable<WorkflowActivity> list = this.WorkflowActivity.Where(s => s.EndTime == null);
            if (list.Count() > 0) {
                beforActivity = list.Last();
                beforActivity.EndTime = DateTime.Now;
            }

            WorkflowActivity activity = new WorkflowActivity(this.Id, "PurchaseOrder", "PO-021", operatorId, beforActivity);
            this.WorkflowActivity.Add(activity);
        }



        #endregion

        #endregion

        protected override void Validate() {
            throw new NotImplementedException();
        }

        public override string GenerateIdPrefix() {

            return GetChineseSpell("PO-" + GetDateString() + "-");
        }



    }
}
