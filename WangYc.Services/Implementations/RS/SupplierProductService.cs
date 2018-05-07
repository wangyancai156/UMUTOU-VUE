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
using WangYc.Services.Messaging.RS;
using WangYc.Services.ViewModels.RS;
using WangYc.Services.Mapping.RS;
using WangYc.Services.Interfaces.RS;

namespace WangYc.Services.Implementations.RS {
   
        public class SupplierProductService : ISupplierProductService {

            private readonly ISupplierProductRepository _supplierProductRepository;
            private readonly IUnitOfWork _uow;
            public SupplierProductService(ISupplierProductRepository supplierProductRepository, IUnitOfWork uow) {

                this._supplierProductRepository = supplierProductRepository;
                this._uow = uow;
            }


            #region 查找

            /// <summary>
            /// 获取采购单类型
            /// </summary>
            /// <returns></returns>
            public IEnumerable<SupplierProduct> GetSupplierProduct(Query request) {

                IEnumerable<SupplierProduct> model = this._supplierProductRepository.FindBy(request);
                return model;
            }

            /// <summary>
            /// 获取采购单类型视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<SupplierProductView> GetSupplierProductView(Query request) {

                IEnumerable<SupplierProduct> model = _supplierProductRepository.FindBy(request);
                return model.ConvertToSupplierProductView();
            }
            /// <summary>
            /// 获取所有采购单类型视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<SupplierProductView> GetSupplierProductViewByAll() {

                return this._supplierProductRepository.FindAll().ConvertToSupplierProductView();

            }

            /// <summary>
            /// 根据采购单类型号获取采购单类型视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<SupplierProductView> GetSupplierProductViewById(int id) {

                Query query = new Query();
                query.Add(Criterion.Create<SupplierProduct>(c => c.Id, id, CriteriaOperator.Equal));
                return this._supplierProductRepository.FindBy(query).ConvertToSupplierProductView();

            }
            #endregion

            #region 添加

            public void AddSupplierProduct(AddSupplierProductRequest request) {

                SupplierProduct model = this._supplierProductRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }
                this._supplierProductRepository.Add(model);
                this._uow.Commit();
            }

            #endregion

            #region 修改

            public void UpdateSupplierProduct(AddSupplierProductRequest request) {

                SupplierProduct model = this._supplierProductRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }

                this._supplierProductRepository.Save(model);
                this._uow.Commit();
            }

            #endregion

            #region 删除
            public void RemoveSupplierProduct(int id) {

                SupplierProduct model = this._supplierProductRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                this._supplierProductRepository.Remove(model);
                this._uow.Commit();
            }

            #endregion
        }
    }
