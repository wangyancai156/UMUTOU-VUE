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
using WangYc.Services.Messaging.Common;

namespace WangYc.Services.Implementations.BW {
    public  class ArrivalNoticeService : IArrivalNoticeService {

        private readonly IArrivalNoticeRepository _arrivalNoticeRepository;
        private readonly IArrivalNoticeDetailRepository _arrivalNoticeDetailRepository;
        private readonly IArrivalReceiptService _arrivalReceiptService;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IUnitOfWork _uow;

        public ArrivalNoticeService(
            IArrivalNoticeRepository arrivalNoticeRepository,
            IArrivalNoticeDetailRepository purchaseNoticeDetailRepository,
            IArrivalReceiptService arrivalReceiptService,
            IWorkflowActivityService workflowActivityService,
            IUnitOfWork uow
        ) {
            this._arrivalNoticeRepository = arrivalNoticeRepository;
            this._arrivalNoticeDetailRepository = purchaseNoticeDetailRepository;
            this._arrivalReceiptService = arrivalReceiptService;
            this._workflowActivityService = workflowActivityService;
            this._uow = uow;
        }


        #region 通知到货单

        #region 查找

        /// <summary>
        /// 根据状态获取采购单视图
        /// </summary>
        /// <returns></returns>
        public ListPaged<ArrivalNoticeView> GetArrivalNoticePageView(GeArrivalNoticeRequest request) {

            Query query = new Query();
            query.Add(Criterion.Create<ArrivalNotice>(c => c.State, 1, CriteriaOperator.Equal));
            return this._arrivalNoticeRepository.PagedFindBy(query, request.PageIndex, request.PageSize).ConvertToArrivalNoticeView();
        }


        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable< ArrivalNoticeDetailView> GetArrivalNoticeDetailView(int id) {
            Query query = new Query();
            query.Add(Criterion.Create<ArrivalNoticeDetail>(c => c.ArrivalNotice.Id,id,CriteriaOperator.Equal));
            return this._arrivalNoticeDetailRepository.FindBy(query).ConvertToArrivalNoticeDetailView();
        }

        #endregion

        #region 添加到货单

        /// <summary>
        /// 添加到货单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AddArrivalReceiptDetail( AddArrivalReceiptDetailRequest request ) {

            //获取通知到货明细
            ArrivalNoticeDetail model = this._arrivalNoticeDetailRepository.FindBy(request.ArrivalNoticeId);
            if(model == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseOrderDetailId.ToString());
            }

            //添加到货单 
            AddArrivalReceiptRequest addreceipt = new AddArrivalReceiptRequest();
            addreceipt.CreateUserId = request.CreateUserId;
            addreceipt.Note = "";
            ArrivalReceipt receipt = this._arrivalReceiptService.AddArrivalReceipt(addreceipt);
            //添加到货明细
            model.AddReceiptDetail(receipt,request.Qty,request.Note,request.CreateUserId);
            this._arrivalNoticeDetailRepository.Save(model);
            this._uow.Commit();

            //看看到货单的所有产品是否已经都到货了
            ArrivalNotice notice = this._arrivalNoticeRepository.FindBy(model.ArrivalNotice.Id);
            if(notice.State==1) {
                //刷新通知到货单状态
                notice.RefreshState();
                if(notice.State == 2) {
                    //调整采购单状态
                    AddWorkflowActivityRequest request_ac = new AddWorkflowActivityRequest();
                    request_ac.ObjectId = notice.ObjectId.ToString();
                    request_ac.ObjectTypeId = "PurchaseOrder";
                    request_ac.WorkflowNodeId = "PO-005";
                    request_ac.Note = "货物到齐全自动完结";
                    request_ac.CreateUserId = request.CreateUserId;
                    this._workflowActivityService.InsertNewActivity(request_ac);
                }
            }
            return true;
        }


        #endregion

        //添加到货通知单

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdateArrivalNoticeDetail(AddArrivalNoticeDetailRequest request) {

            ArrivalNoticeDetail model = this._arrivalNoticeDetailRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._arrivalNoticeDetailRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemoveArrivalNoticeDetail(int id) {

            ArrivalNoticeDetail model = this._arrivalNoticeDetailRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.State = 0;
            this._arrivalNoticeDetailRepository.Save(model);
            this._uow.Commit();
        }
        #endregion
        #endregion

 
    }
}
