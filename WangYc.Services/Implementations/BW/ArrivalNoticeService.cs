using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Models.Repository.PO;
using WangYc.Services.Interfaces.Common;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.BW;
using WangYc.Models.PO;

namespace WangYc.Services.Implementations.BW {
    public  class ArrivalNoticeService : IArrivalNoticeService {

        private readonly IArrivalNoticeDetailRepository _arrivalNoticeRepository;
        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
        private readonly IArrivalReceiptRepository _arrivalReceiptRepository;
        private readonly ArrivalReceiptService _arrivalReceiptService;   
        private readonly IWorkflowActivityService _workflowActivityService;

        private readonly IUnitOfWork _uow;

        public ArrivalNoticeService(
            IArrivalNoticeDetailRepository purchaseNoticeRepository,
            IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
            IArrivalReceiptRepository purchaseReceiptRepository,
            ArrivalReceiptService purchaseReceiptService,
            IWorkflowActivityService workflowActivityService,
            IUnitOfWork uow
        ) {

            this._arrivalNoticeRepository = purchaseNoticeRepository;
            this._purchaseOrderDetailRepository = purchaseOrderDetailRepository;
            this._arrivalReceiptRepository = purchaseReceiptRepository;
            this._arrivalReceiptService = purchaseReceiptService;
            this._workflowActivityService = workflowActivityService;
            this._uow = uow;
        }


        #region 到货单

        #region 查找

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        public ArrivalNoticeDetail GetArrivalNotice(int id) {

            return this._arrivalNoticeRepository.FindBy(id);
        }
 
        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ArrivalNoticeDetail> GetArrivalNotice(Query request) {

            IEnumerable<ArrivalNoticeDetail> model = this._arrivalNoticeRepository.FindBy(request);
            return model;
        }



        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public ArrivalNoticeView GetArrivalNoticeView(int id) {

            return GetArrivalNotice(id).ConvertToArrivalNoticeView();
        }
        
        /// <summary>
        /// 根据状态获取采购单视图
        /// </summary>
        /// <returns></returns>
        public ListPaged<ArrivalNoticeView> GetPurchaseOrderViewByStatus(GeArrivalNoticeRequest request) {

            Query query = new Query();
            query.Add(Criterion.Create<ArrivalNoticeDetail>(c => c.IsValid, true, CriteriaOperator.Equal));
            query.Add(Criterion.Create<ArrivalNoticeDetail>(c => c.PurchaseOrderDetail.PurchaseOrder.StatuId, "PO-030", CriteriaOperator.Equal));
            return this._arrivalNoticeRepository.PagedFindBy(query, request.PageIndex, request.PageSize).ConvertToArrivalNoticeView();
        }




        #endregion

        #region 添加

        public bool AddArrivalReceipt(AddArrivalReceiptDetailRequest request) {

            ArrivalNoticeDetail model = this._arrivalNoticeRepository.FindBy(request.ArrivalNoticeId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseOrderDetailId.ToString());
            }

            PurchaseOrderDetail purchaseOrderDetail = this._purchaseOrderDetailRepository.FindBy(request.PurchaseOrderDetailId);
            if (purchaseOrderDetail == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseOrderDetailId.ToString());
            }
            AddArrivalReceiptRequest addreceipt = new AddArrivalReceiptRequest();
            addreceipt.CreateUserId = request.CreateUserId;
            addreceipt.Note = "";
            ArrivalReceipt receipt =this._arrivalReceiptService.AddArrivalReceipt(addreceipt);
             
            model.AddReceiptDetail(purchaseOrderDetail, receipt, request.Qty, request.Note, request.CreateUserId);

            return true;
        }
        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdateArrivalNoticeDetail(AddArrivalNoticeDetailRequest request) {

            ArrivalNoticeDetail model = this._arrivalNoticeRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._arrivalNoticeRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemoveArrivalNoticeDetail(int id) {

            ArrivalNoticeDetail model = this._arrivalNoticeRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._arrivalNoticeRepository.Save(model);
            this._uow.Commit();
        }
        #endregion
        #endregion

 
    }
}
