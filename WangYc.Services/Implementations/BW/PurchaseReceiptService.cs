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

namespace WangYc.Services.Implementations.BW {
    public class PurchaseReceiptService : IPurchaseReceiptService {

        private readonly IPurchaseReceiptRepository _purchaseReceiptRepository;
        private readonly IPurchaseReceiptDetailRepository _purchaseReceiptDetailRepository;
        private readonly IUnitOfWork _uow;

        public PurchaseReceiptService(
            IPurchaseReceiptRepository purchaseReceiptRepository,
            IPurchaseReceiptDetailRepository purchaseReceiptDetailRepository,
            IUnitOfWork uow) {
            this._purchaseReceiptRepository = purchaseReceiptRepository;
            this._purchaseReceiptDetailRepository = purchaseReceiptDetailRepository;
            this._uow = uow;
        }


        #region 到货单

        #region 查找

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        public PurchaseReceipt GetPurchaseReceipt(int id) {

            return this._purchaseReceiptRepository.FindBy(id);
        }

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseReceipt> GetPurchaseReceipt(Query request) {

            IEnumerable<PurchaseReceipt> model = this._purchaseReceiptRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public PurchaseReceiptView GetPurchaseReceiptView(int id) {

            return GetPurchaseReceipt(id).ConvertToPurchaseReceiptView();
        }
        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseReceiptView> GetPurchaseReceiptView(Query request) {

            IEnumerable<PurchaseReceipt> model = this._purchaseReceiptRepository.FindBy(request);
            return model.ConvertToPurchaseReceiptView();
        }

        /// <summary>
        /// 获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public ListPaged<PurchaseReceiptView> GetPurchaseReceiptView( int pageIndex, int pageSize, string sort)
        {
            Query query = new Query();
            query.Add(Criterion.Create<PurchaseReceipt>(p => p.Id, 0, CriteriaOperator.GreaterThanOrEqual));

            return this._purchaseReceiptRepository.PagedFindBy(query, pageIndex, pageSize).ConvertToPagedView();
        }

     

        #endregion

        #region 添加

        /// <summary>
        ///添加库房
        /// </summary>
        /// <param name="request"></param>
        public void AddPurchaseReceipt(AddPurchaseReceiptRequest request) {

            PurchaseReceipt model = new PurchaseReceipt(request.Note,request.IsValid, request.CreateUserId);
            this._purchaseReceiptRepository.Add(model);
            this._uow.Commit();
        }

        public void AddPurchaseReceiptDetail(AddPurchaseReceiptDetailRequest request) {

            PurchaseReceipt model = this._purchaseReceiptRepository.FindBy(request.PurchaseReceiptId);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.PurchaseReceiptId.ToString());
            }
            PurchaseReceiptDetail detail = new PurchaseReceiptDetail(request.PurchaseOrderDetailId, request.PurchaseReceiptId, request.Qty, request.Note, request.IsValid, request.CreateUserId);
            model.AddDetail(detail);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdatePurchaseReceipt(AddPurchaseReceiptRequest request) {

            PurchaseReceipt model = this._purchaseReceiptRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            model.Note = request.Note;
            model.IsValid = request.IsValid;
            this._purchaseReceiptRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemovePurchaseReceipt(int id) {

            PurchaseReceipt model = this._purchaseReceiptRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._purchaseReceiptRepository.Save(model);
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
        public PurchaseReceiptDetail GetPurchaseReceiptDetailt(int id) {

            return this._purchaseReceiptDetailRepository.FindBy(id);
        }
        /// <summary>
        /// 获取到货单明细视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseReceiptDetailView> GetPurchaseReceiptDetailView(Query request) {

            IEnumerable<PurchaseReceiptDetail> model = this._purchaseReceiptDetailRepository.FindBy(request);
            return model.ConvertToPurchaseReceiptDetailView();
        }

        public ListPaged<PurchaseReceiptDetailView> GetPurchaseReceiptDetailView(int pageIndex, int pageSize, string sort) {

            Query query = new Query();
            query.Add(Criterion.Create<PurchaseReceiptDetail>(p => p.Id, 0, CriteriaOperator.GreaterThanOrEqual));

            return this._purchaseReceiptDetailRepository.PagedFindBy(query, pageIndex, pageSize).ConvertToPagedView();
        }
        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdatePurchaseDetailReceipt(AddPurchaseReceiptDetailRequest request) {

            PurchaseReceiptDetail model = this._purchaseReceiptDetailRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            model.Note = request.Note;
            model.IsValid = request.IsValid;
            this._purchaseReceiptDetailRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemovePurchaseReceiptDetail(int id) {

            PurchaseReceiptDetail model = this._purchaseReceiptDetailRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._purchaseReceiptDetailRepository.Save(model);
            this._uow.Commit();
        }
        #endregion

        #endregion

    }
}
