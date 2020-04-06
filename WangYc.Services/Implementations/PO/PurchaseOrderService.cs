using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PO;
using WangYc.Models.Repository.PO;
using WangYc.Services.ViewModels.PO;
using WangYc.Services.Mapping.PO;
using WangYc.Services.Messaging.PO;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.FI;
using WangYc.Models.Repository.FI;
using WangYc.Models.Repository.RS;
using WangYc.Models.RS;
using WangYc.Models.SD;
using WangYc.Models.Repository.SD;
using WangYc.Services.Interfaces.PO;
using WangYc.Services.Messaging.Common;
using WangYc.Services.Interfaces.Common;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;

namespace WangYc.Services.Implementations.PO {
    public class PurchaseOrderService : IPurchaseOrderService {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
        private readonly IPurchaseTypeRepository _purchaseTypeRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IArrivalNoticeRepository _arrivalNoticeRepository;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IUsersRepository _usersRepository;
        private readonly IIdGenerator<PurchaseOrder, string> _purchaseOrderIdGenerator;
        private readonly IUnitOfWork _uow;

        public PurchaseOrderService(
            IPurchaseOrderRepository purchaseOrderRepository,
            IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
            IPurchaseTypeRepository purchaseTypeRepository,
            IPaymentTypeRepository paymentTypeRepository,
            ISupplierRepository supplierRepository,
            IProductRepository productRepository,
            IArrivalNoticeRepository arrivalNoticeRepository,
            IWorkflowActivityService workflowActivityService,
            IUsersRepository usersRepository,
            IIdGenerator<PurchaseOrder, string> purchaseOrderIdGenerator,
            IUnitOfWork uow
            ) {
            this._purchaseOrderRepository = purchaseOrderRepository;
            this._purchaseOrderDetailRepository = purchaseOrderDetailRepository;
            this._purchaseTypeRepository = purchaseTypeRepository;
            this._paymentTypeRepository = paymentTypeRepository;
            this._supplierRepository = supplierRepository;
            this._productRepository = productRepository;
            this._arrivalNoticeRepository= arrivalNoticeRepository;
            this._workflowActivityService = workflowActivityService;
            this._usersRepository = usersRepository;
            this._purchaseOrderIdGenerator = purchaseOrderIdGenerator;
            this._uow = uow;
        }

        #region 查找

        /// <summary>
        /// 获取采购单
        /// </summary>
        /// <returns></returns>
        public PurchaseOrder GetPurchaseOrderById(string id) {

            PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
            return model;
        }


        /// <summary>
        /// 获取采购单列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseOrder> GetPurchaseOrderBy(Query request) {

            IEnumerable<PurchaseOrder> model = this._purchaseOrderRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取采购单视图
        /// </summary>
        /// <returns></returns>
        public PurchaseOrderView GetPurchaseOrderViewById(string id) {

            PurchaseOrder model = GetPurchaseOrderById(id);
            return model.ConvertToPurchaseOrderView();
        }
        /// <summary>
        /// 获取采购单视图列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseOrderView> GetPurchaseOrderView(Query request) {

            IEnumerable<PurchaseOrder> model = _purchaseOrderRepository.FindBy(request);
            return model.ConvertToPurchaseOrderView();
        }

        /// <summary>
        /// 根据状态获取采购单视图
        /// 用于获取当前状态的采购单，在自己范围所辖范围内的
        /// </summary>
        /// <returns></returns>
        public ListPaged<PurchaseOrderView> GetPurchaseOrderViewByStatus(GetPurchaseOrderRequest request) {

            Query query = new Query();
            query.Add(Criterion.Create<PurchaseOrder>(c => c.StatuId, request.StatuId, CriteriaOperator.Equal));
            query.Add(Criterion.Create<PurchaseOrder>(c => c.IsValid, true, CriteriaOperator.Equal));
            return this._purchaseOrderRepository.PagedFindBy(query, request.PageIndex, request.PageSize).ConvertToPurchaseOrderPagedView();
        }
        /// <summary>
        /// 获取已经处理过的采购单
        /// 用于获取之前被处理过的采购单
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        public ListPaged<PurchaseOrderView> GetPurchaseOrderViewHaveStatus(GetPurchaseOrderRequest request) {

            Query query = new Query();
            query.Add(new Criterion("WorkflowActivity.WorkflowNodeId", request.StatuId, CriteriaOperator.Equal));
            query.Add(new Criterion("WorkflowActivity.CreateUserId", request.OperatorId, CriteriaOperator.Equal));
            return this._purchaseOrderRepository.PagedFindBy(query, request.PageIndex, request.PageSize).ConvertToPurchaseOrderPagedView();
        }

        /// <summary>
        /// 获取采购明细视图
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        public IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailView(string purchaseOrderId) {

            PurchaseOrder model = this.GetPurchaseOrderById(purchaseOrderId);
            return model.Detail.ConvertToPurchaseOrderDetailView();
        }



        #endregion

        #region 添加

        public void AddPurchaseOrder(AddPurchaseOrderRequest request) {

            PurchaseType purchaseType = this._purchaseTypeRepository.FindBy(request.PurchaseTypeId);
            if (purchaseType == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseTypeId.ToString());
            }
            PaymentType paymentType = this._paymentTypeRepository.FindBy(request.PaymentTypeId);
            if (purchaseType == null) {
                throw new EntityIsInvalidException<string>(request.PaymentTypeId.ToString());
            }
            Supplier supplier = this._supplierRepository.FindBy(request.SupplierId);
            if (supplier == null) {
                throw new EntityIsInvalidException<string>(request.SupplierId.ToString());
            }
            Users users = this._usersRepository.FindBy(request.CreateUserId);
            if (supplier == null) {
                throw new EntityIsInvalidException<string>(request.CreateUserId.ToString());
            }
            PurchaseOrder model = new PurchaseOrder(purchaseType, paymentType, supplier, users, request.Note);
            model.Id = this._purchaseOrderIdGenerator.NewIntId(model, 3);
            model.Initial(model.CreateUser.Id);
            this._purchaseOrderRepository.Add(model);
            this._uow.Commit();
        }

        public void AddPurchaseOrderDetail(AddPurchaseOrderDetailRequest request) {

            PurchaseOrder model = this._purchaseOrderRepository.FindBy(request.PurchaseOrderId);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseOrderId.ToString());
            }
            Product product = this._productRepository.FindBy(request.ProductId);
            if (product == null) {
                throw new EntityIsInvalidException<string>(request.ProductId.ToString());
            }

            PurchaseOrderDetail detail = new PurchaseOrderDetail(model, product, request.Qty, request.UnitPrice, request.Note, request.CreateUserId);
            model.AddDetail(detail);

            this._purchaseOrderRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdatePurchaseOrder(AddPurchaseOrderRequest request) {

            PurchaseOrder model = this._purchaseOrderRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            PurchaseType purchaseType = this._purchaseTypeRepository.FindBy(request.PurchaseTypeId);
            if (purchaseType == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseTypeId.ToString());
            }
            PaymentType paymentType = this._paymentTypeRepository.FindBy(request.PaymentTypeId);
            if (purchaseType == null) {
                throw new EntityIsInvalidException<string>(request.PaymentTypeId.ToString());
            }
            Supplier supplier = this._supplierRepository.FindBy(request.SupplierId);
            if (supplier == null) {
                throw new EntityIsInvalidException<string>(request.SupplierId.ToString());
            }
            model.PurchaseType = purchaseType;

            this._purchaseOrderRepository.Save(model);
            this._uow.Commit();
        }

        public bool PurchaseApply(string id, string operatorId) {
            try {
                PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                model.Apply(operatorId);
                this._purchaseOrderRepository.Save(model);
                this._uow.Commit();
            } catch {
                return false;
            }
            return true;
        }

        public bool PurchaseApproval(string id, string operatorId) {
            try {
                PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                Users operators = this._usersRepository.FindBy(operatorId);
                if(operatorId == null) {
                    throw new EntityIsInvalidException<string>(operatorId);
                }

                model.Approval(operatorId);
                this.AddArrivalNoticeForPurchase(model.Id,operators,model.Detail);
                this._purchaseOrderRepository.Add(model);
                this._uow.Commit();
            } catch ( Exception ex) {
                string ss = ex.ToString();
                return false;
            }
            return true;
        }

        //添加到货通知单
        public bool AddArrivalNoticeForPurchase( string purchaseId,Users operators,IList<PurchaseOrderDetail> items ) {
             
            ArrivalNotice notice = new ArrivalNotice(1,purchaseId,1,operators);
            foreach(PurchaseOrderDetail one in items) {
                notice.AddArrivalNoticeDetail(operators.Id,one.Id,one.Product,one.Qty);
            }
            this._arrivalNoticeRepository.Save(notice);
            this._uow.Commit();
            return true;
        }

        public bool PurchaseReject(string id, string operatorId) {
            try {
                PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                model.Reject(operatorId);
                this._purchaseOrderRepository.Save(model);
                this._uow.Commit();
            } catch (Exception ex) {
                string ss = ex.ToString();
                return false;
            }
            return true;
        }
 
        #endregion

        #region 删除
        public void RemovePurchaseOrder(string[] ids) {

            Query query = new Query();
            query.Add(Criterion.Create<PurchaseOrder>(c => c.Id, ids, CriteriaOperator.InOfString));
            IEnumerable<PurchaseOrder> model = this.GetPurchaseOrderBy(query);

            string result = "删除成功";
            try {
                foreach (PurchaseOrder one in model) {
                    one.IsValid = false;
                    this._purchaseOrderRepository.Save(one);
                }
            } catch (Exception ex) {
                result = "修改失败：" + ex.Message;
            }
            this._uow.Commit();

        }

        public void RemovePurchaseOrderDetail(string id, int itemid) {

            PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.RemoveDetail(itemid);
            this._purchaseOrderRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

    }
}
