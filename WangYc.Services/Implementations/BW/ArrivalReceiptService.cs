using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Services.Messaging.BW;
using WangYc.Services.Interfaces.BW;
using WangYc.Models.PO;
using WangYc.Models.Repository.PO;
using WangYc.Services.Interfaces.Common;
using WangYc.Services.Messaging.Common;

namespace WangYc.Services.Implementations.BW {
    public class ArrivalReceiptService : IArrivalReceiptService {

        private readonly IArrivalReceiptRepository _arrivalReceiptRepository;
        private readonly IArrivalReceiptDetailRepository _arrivalReceiptDetailRepository;
        //private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IUnitOfWork _uow;

        public ArrivalReceiptService(
            IArrivalReceiptRepository purchaseReceiptRepository,
            IArrivalReceiptDetailRepository purchaseReceiptDetailRepository,
            //IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
            //IWorkflowActivityService workflowActivityService,
            IUnitOfWork uow
        ) {

            this._arrivalReceiptRepository = purchaseReceiptRepository;
            this._arrivalReceiptDetailRepository = purchaseReceiptDetailRepository;
            //this._workflowActivityService = workflowActivityService;
            this._uow = uow;
        }


        #region 到货单

        #region 查找

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        public ArrivalReceipt GetArrivalReceipt(int id) {

            return this._arrivalReceiptRepository.FindBy(id);
        }

           /// <summary>
        /// 根据操作人获取今天的到货单
        /// </summary>
        /// <returns></returns>
        public ArrivalReceipt GetArrivalReceipt(string createUserId) {

            Query query = new Query();
            query.Add(Criterion.Create<ArrivalReceipt>(c => c.CreateUserId, createUserId, CriteriaOperator.Equal));
            query.Add(Criterion.Create<ArrivalReceipt>(c => c.CreateDate, DateTime.Now.ToShortDateString(), CriteriaOperator.GreaterThanOrEqual));
            return this._arrivalReceiptRepository.FindBy(query).First();
        }

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArrivalReceipt> GetArrivalReceipt(Query request) {

            IEnumerable<ArrivalReceipt> model = this._arrivalReceiptRepository.FindBy(request);
            return model;
        }

     

        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public ArrivalReceiptView GetArrivalReceiptView(int id) {

            return GetArrivalReceipt(id).ConvertToArrivalReceiptView();
        }
        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArrivalReceiptView> GetArrivalReceiptView(Query request) {

            IEnumerable<ArrivalReceipt> model = this._arrivalReceiptRepository.FindBy(request);
            return model.ConvertToArrivalReceiptView();
        }

        /// <summary>
        /// 获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public ListPaged<ArrivalReceiptView> GetArrivalReceiptView( int pageIndex, int pageSize, string sort)
        {
            Query query = new Query();
            query.Add(Criterion.Create<ArrivalReceipt>(p => p.Id, 0, CriteriaOperator.GreaterThanOrEqual));

            return this._arrivalReceiptRepository.PagedFindBy(query, pageIndex, pageSize).ConvertToPagedView();
        }



        #endregion

        #region 添加

        /// <summary>
        /// 添加接货单
        /// </summary>
        /// <param name="request"></param>
        public ArrivalReceipt AddArrivalReceipt(AddArrivalReceiptRequest request) {

            ArrivalReceipt model = new ArrivalReceipt(request.Note, request.IsValid, request.CreateUserId);
            this._arrivalReceiptRepository.Add(model);
            this._uow.Commit();

            return model;
        }

        /// <summary>
        /// 添加接货单
        /// </summary>
        /// <param name="request"></param>
        public ArrivalReceipt AddArrivalReceipt(string createUserId) {
            /*
            * step.1.创建接货单：单个员工一天只能创建一个接货单（目前默认是这样如果有需求则可以修改）
            *                    首先试着获取，如果没有获取则创建后再获取
            * step.2.获取采购明细
            */
            ArrivalReceipt receipt = this.GetArrivalReceipt(createUserId);
            if (receipt == null) {
                AddArrivalReceiptRequest a = new AddArrivalReceiptRequest();
                a.CreateUserId = createUserId;
                AddArrivalReceipt(a);
                receipt = this.GetArrivalReceipt(createUserId);
            }
            if (receipt == null) {
                throw new EntityIsInvalidException<string>("接货单没有创建成功，请重试！");
            }
            return receipt;

        }
        public void AddArrivalReceiptDetail(AddArrivalReceiptDetailRequest request) {

            /*
             * step.1.创建接货单：单个员工一天只能创建一个接货单（目前默认是这样如果有需求则可以修改）
             *                    首先试着获取，如果没有获取则创建后再获取
             * step.2.获取采购明细
             */
            ArrivalReceipt receipt = this.AddArrivalReceipt(request.CreateUserId);
 
             
            ////如果已经全部到齐结束采购单
            //if (model.PurchaseOrder.Detail.Where(s => s.Qty > s.ArrivalQty).Count() > 0) {
            //    AddWorkflowActivityRequest request_ac = new AddWorkflowActivityRequest();
            //    request_ac.ObjectId = model.PurchaseOrder.Id.ToString();
            //    request_ac.ObjectTypeId = "PurchaseOrder";
            //    request_ac.WorkflowNodeId = "PO-005";
            //    request_ac.Note = "货物到齐全自动完结";
            //    request_ac.CreateUserId = request.CreateUserId;
            //    this._workflowActivityService.InsertNewActivity(request_ac);
            //}
            this._uow.Commit();
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdateArrivalReceipt(AddArrivalReceiptRequest request) {

            ArrivalReceipt model = this._arrivalReceiptRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            model.Note = request.Note;
            model.IsValid = request.IsValid;
            this._arrivalReceiptRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemoveArrivalReceipt(int id) {

            ArrivalReceipt model = this._arrivalReceiptRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._arrivalReceiptRepository.Save(model);
            this._uow.Commit();
        }
        #endregion
        #endregion

        #region 到货单明细

        #region 查找
     
        /// <summary>
        /// 获取到到货单明细
        /// </summary>
        /// <returns></returns>
        public ArrivalReceiptDetail GetArrivalReceiptDetailt(int id) {

            return this._arrivalReceiptDetailRepository.FindBy(id);
        }
        /// <summary>
        /// 获取到货单明细视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArrivalReceiptDetailView> GetArrivalReceiptDetailView(Query request) {

            IEnumerable<ArrivalReceiptDetail> model = this._arrivalReceiptDetailRepository.FindBy(request);
            return model.ConvertToArrivalReceiptDetailView();
        }

        public ListPaged<ArrivalReceiptDetailView> GetArrivalReceiptDetailView(string purchaseId, int pageIndex, int pageSize, string sort) {

            Query query = new Query();
            query.Add(Criterion.Create<ArrivalReceiptDetail>(p => p.Id, purchaseId, CriteriaOperator.GreaterThanOrEqual));
            return this._arrivalReceiptDetailRepository.PagedFindBy(query, pageIndex, pageSize).ConvertToPagedView();
        }
        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdatePurchaseDetailReceipt(AddArrivalReceiptDetailRequest request) {

            ArrivalReceiptDetail model = this._arrivalReceiptDetailRepository.FindBy(request.ArrivalNoticeId);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.ArrivalNoticeId.ToString());
            }

            model.Note = request.Note;
            model.IsValid = request.IsValid;
            this._arrivalReceiptDetailRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemoveArrivalReceiptDetail(int id) {

            ArrivalReceiptDetail model = this._arrivalReceiptDetailRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._arrivalReceiptDetailRepository.Save(model);
            this._uow.Commit();
        }
        #endregion

        #endregion

    }
}
