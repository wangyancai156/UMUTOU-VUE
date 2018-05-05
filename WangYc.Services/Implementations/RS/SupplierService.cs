using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.RS;
using WangYc.Models.RS;
using WangYc.Services.ViewModels.RS;
using WangYc.Services.Mapping.RS;
using WangYc.Services.Messaging.RS;
using WangYc.Services.Interfaces.RS;

namespace WangYc.Services.Implementations.RS {
    public class SupplierService  : ISupplierService {

        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _uow;
        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork uow) {

            this._supplierRepository = supplierRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取采购单类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Supplier> GetSupplier(Query request) {

            IEnumerable<Supplier> model = this._supplierRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupplierView> GetSupplierView(Query request) {

            IEnumerable<Supplier> model = _supplierRepository.FindBy(request);
            return model.ConvertToSupplierView();
        }
        /// <summary>
        /// 获取所有采购单类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupplierView> GetSupplierViewByAll() {

            return this._supplierRepository.FindAll().ConvertToSupplierView();

        }

        /// <summary>
        /// 根据采购单类型号获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupplierView> GetSupplierViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<Supplier>(c => c.Id, id, CriteriaOperator.Equal));
            return this._supplierRepository.FindBy(query).ConvertToSupplierView();

        }
        #endregion

        #region 添加

        public void AddSupplier(AddSupplierRequest request) {

            Supplier model = this._supplierRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._supplierRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateSupplier(AddSupplierRequest request) {

            Supplier model = this._supplierRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
           
            this._supplierRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveSupplier(int id) {

            Supplier model = this._supplierRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._supplierRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
