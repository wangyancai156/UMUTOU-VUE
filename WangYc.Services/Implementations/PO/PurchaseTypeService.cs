using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PO;
using WangYc.Models.Repository.PO;
using WangYc.Services.Interfaces.PO;
using WangYc.Services.ViewModels.PO;
using WangYc.Services.Messaging.PO;
using WangYc.Services.Mapping.PO;
using WangYc.Models.HR;
using WangYc.Models.Repository.HR;

namespace WangYc.Services.Implementations.PO {
    public class PurchaseTypeService : IPurchaseTypeService {

        private readonly IPurchaseTypeRepository _purchaseTypeRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _uow;
        public PurchaseTypeService(IPurchaseTypeRepository purchaseTypeRepository, IUsersRepository usersRepository, IUnitOfWork uow) {

            this._purchaseTypeRepository = purchaseTypeRepository;
            this._usersRepository = usersRepository;
            this._uow = uow;
        }

        #region 查找

        /// <summary>
        /// 获取采购单类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseType> GetPurchaseType(Query request) {

            IEnumerable<PurchaseType> model = this._purchaseTypeRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseTypeView> GetPurchaseTypeView(Query request) {

            IEnumerable<PurchaseType> model = _purchaseTypeRepository.FindBy(request);
            return model.ConvertToPurchaseTypeView();
        }
        /// <summary>
        /// 获取所有采购单类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseTypeView> GetPurchaseTypeViewByAll() {

            return this._purchaseTypeRepository.FindAll().ConvertToPurchaseTypeView();

        }

        /// <summary>
        /// 根据采购单类型号获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PurchaseTypeView> GetPurchaseTypeViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<PurchaseType>(c => c.Id, id, CriteriaOperator.Equal));
            return this._purchaseTypeRepository.FindBy(query).ConvertToPurchaseTypeView();

        }
        #endregion

        #region 添加

        public void AddPurchaseType(AddPurchaseTypeRequest request) {

            Users createUser = this._usersRepository.FindBy(request.CreateUserId);
            if (createUser == null) {
                throw new EntityIsInvalidException<string>(request.CreateUserId.ToString());
            }
            PurchaseType model = new PurchaseType(request.Description,request.Note, createUser);
            
            this._purchaseTypeRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdatePurchaseType(AddPurchaseTypeRequest request) {

            PurchaseType model = this._purchaseTypeRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            model.Description = request.Description;
            model.Note = request.Note;
            this._purchaseTypeRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemovePurchaseType(int id) {

            PurchaseType model = this._purchaseTypeRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._purchaseTypeRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion

    }
}
