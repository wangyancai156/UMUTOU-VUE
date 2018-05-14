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

namespace WangYc.Services.Implementations.PO {
    public class PurchaseOrderService : IPurchaseOrderService {

        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IPurchaseTypeRepository _purchaseTypeRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IUnitOfWork _uow;

        public PurchaseOrderService(
            IPurchaseOrderRepository purchaseOrderRepository,
            IPurchaseTypeRepository purchaseTypeRepository,
            IPaymentTypeRepository paymentTypeRepository,
            ISupplierRepository supplierRepository,
            IProductRepository productRepository,
            IWorkflowActivityService workflowActivityService,
            IUnitOfWork uow
            ) {
            this._purchaseOrderRepository = purchaseOrderRepository;
            this._purchaseTypeRepository = purchaseTypeRepository;
            this._paymentTypeRepository = paymentTypeRepository;
            this._supplierRepository = supplierRepository;
            this._productRepository = productRepository;
            this._workflowActivityService = workflowActivityService;
            this._uow = uow;
        }

        #region 查找


        /// <summary>
        /// 获取采购单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseOrder> GetPurchaseOrder(Query request) {

            IEnumerable<PurchaseOrder> model = this._purchaseOrderRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取采购单视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseOrderView> GetPurchaseOrderView(Query request) {

            IEnumerable<PurchaseOrder> model = _purchaseOrderRepository.FindBy(request);
            return model.ConvertToPurchaseOrderView();
        }
        /// <summary>
        /// 获取所有采购单视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseOrderView> GetPurchaseOrderViewByAll() {

            return this._purchaseOrderRepository.FindAll().ConvertToPurchaseOrderView();

        }

        /// <summary>
        /// 根据采购单号获取采购单视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseOrderView> GetPurchaseOrderViewById(int id) {
             
            Query query = new Query();
            query.Add(Criterion.Create<PurchaseOrder>(c => c.Id, id, CriteriaOperator.Equal));
            return this._purchaseOrderRepository.FindBy(query).ConvertToPurchaseOrderView();

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
            PurchaseOrder model = new PurchaseOrder(purchaseType, paymentType, supplier,request.CreateUserId,request.Note);

            this._purchaseOrderRepository.Add(model);

            AddWorkflowActivityRequest request_ac = new AddWorkflowActivityRequest();
            request_ac.ObjectId = model.Id.ToString();
            request_ac.ObjectTypeId = "PurchaseOrder";
            request_ac.WorkflowNodeId = "PO-001";
            request_ac.Note = "添加采购单";
            request_ac.CreateUserId = request.CreateUserId;
            this._workflowActivityService.InsertNewActivity(request_ac);
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

            PurchaseOrderDetail detail = new PurchaseOrderDetail(model, product,request.Qty,request.UnitPrice,request.Note,request.CreateUserId);
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


        public void Apply(int id, string createUserId) {

            PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            AddWorkflowActivityRequest request_ac = new AddWorkflowActivityRequest();
            request_ac.ObjectId = model.Id.ToString();
            request_ac.ObjectTypeId = "PurchaseOrder";
            request_ac.WorkflowNodeId = "PO-002";
            request_ac.Note = "提交采购单";
            request_ac.CreateUserId = createUserId;
            this._workflowActivityService.InsertNewActivity(request_ac);
            this._uow.Commit();
        }
        #endregion

        #region 删除
        public void RemovePurchaseOrder(int id) {

            PurchaseOrder model = this._purchaseOrderRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._purchaseOrderRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion

    }
}
