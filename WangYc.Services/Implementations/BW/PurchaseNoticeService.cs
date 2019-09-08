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
    public  class PurchaseNoticeService : IPurchaseNoticeService {

        private readonly IPurchaseNoticeDetailRepository _purchaseNoticeRepository;
        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
        private readonly IPurchaseReceiptRepository _purchaseReceiptRepository;
        private readonly PurchaseReceiptService _purchaseReceiptService;   
        private readonly IWorkflowActivityService _workflowActivityService;

        private readonly IUnitOfWork _uow;

        public PurchaseNoticeService(
            IPurchaseNoticeDetailRepository purchaseNoticeRepository,
            IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
            IPurchaseReceiptRepository purchaseReceiptRepository,
            PurchaseReceiptService purchaseReceiptService,
            IWorkflowActivityService workflowActivityService,
            IUnitOfWork uow
        ) {

            this._purchaseNoticeRepository = purchaseNoticeRepository;
            this._purchaseOrderDetailRepository = purchaseOrderDetailRepository;
            this._purchaseReceiptRepository = purchaseReceiptRepository;
            this._purchaseReceiptService = purchaseReceiptService;
            this._workflowActivityService = workflowActivityService;
            this._uow = uow;
        }


        #region 到货单

        #region 查找

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        public PurchaseNoticeDetail GetPurchaseNotice(int id) {

            return this._purchaseNoticeRepository.FindBy(id);
        }
 
        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseNoticeDetail> GetPurchaseNotice(Query request) {

            IEnumerable<PurchaseNoticeDetail> model = this._purchaseNoticeRepository.FindBy(request);
            return model;
        }



        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public PurchaseNoticeView GetPurchaseNoticeView(int id) {

            return GetPurchaseNotice(id).ConvertToPurchaseNoticeView();
        }
        
        /// <summary>
        /// 根据状态获取采购单视图
        /// </summary>
        /// <returns></returns>
        public ListPaged<PurchaseNoticeView> GetPurchaseOrderViewByStatus(GePurchaseNoticeRequest request) {

            Query query = new Query();
            query.Add(Criterion.Create<PurchaseNoticeDetail>(c => c.IsValid, true, CriteriaOperator.Equal));
            query.Add(Criterion.Create<PurchaseNoticeDetail>(c => c.PurchaseOrderDetail.PurchaseOrder.StatuId, "PO-030", CriteriaOperator.Equal));
            return this._purchaseNoticeRepository.PagedFindBy(query, request.PageIndex, request.PageSize).ConvertToPurchaseNoticeView();
        }




        #endregion

        #region 添加

        public bool AddPurchaseReceipt(AddPurchaseReceiptDetailRequest request) {

            PurchaseNoticeDetail model = this._purchaseNoticeRepository.FindBy(request.PurchaseNoticeId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseOrderDetailId.ToString());
            }

            PurchaseOrderDetail purchaseOrderDetail = this._purchaseOrderDetailRepository.FindBy(request.PurchaseOrderDetailId);
            if (purchaseOrderDetail == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseOrderDetailId.ToString());
            }
            AddPurchaseReceiptRequest addreceipt = new AddPurchaseReceiptRequest();
            addreceipt.CreateUserId = request.CreateUserId;
            addreceipt.Note = "";
            PurchaseReceipt receipt =this._purchaseReceiptService.AddPurchaseReceipt(addreceipt);
             
            model.AddReceiptDetail(purchaseOrderDetail, receipt, request.Qty, request.Note, request.CreateUserId);

            return true;
        }
        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdatePurchaseNotice(AddPurchaseNoticeRequest request) {

            PurchaseNoticeDetail model = this._purchaseNoticeRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._purchaseNoticeRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemovePurchaseNotice(int id) {

            PurchaseNoticeDetail model = this._purchaseNoticeRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._purchaseNoticeRepository.Save(model);
            this._uow.Commit();
        }
        #endregion
        #endregion

 
    }
}
