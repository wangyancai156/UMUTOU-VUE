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
using WangYc.Services.Interfaces.PO;

namespace WangYc.Services.Implementations.PO {
        public class PurchaseOrderDetailService : IPurchaseOrderDetailService {

            private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
            private readonly IUnitOfWork _uow;
            public PurchaseOrderDetailService(IPurchaseOrderDetailRepository PurchaseOrderDetailRepository, IUnitOfWork uow) {

                this._purchaseOrderDetailRepository = PurchaseOrderDetailRepository;
                this._uow = uow;
            }


            #region 查找

            /// <summary>
            /// 获取项目
            /// </summary>
            /// <returns></returns>
            public IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetail(Query request) {

                IEnumerable<PurchaseOrderDetail> model = this._purchaseOrderDetailRepository.FindBy(request);
                return model;
            }

            /// <summary>
            /// 获取项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailView(Query request) {

                IEnumerable<PurchaseOrderDetail> model = _purchaseOrderDetailRepository.FindBy(request);
                return model.ConvertToPurchaseOrderDetailView();
            }
            /// <summary>
            /// 获取所有项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailViewByAll() {

                return this._purchaseOrderDetailRepository.FindAll().ConvertToPurchaseOrderDetailView();

            }

            /// <summary>
            /// 根据项目号获取项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailViewById(int id) {

                Query query = new Query();
                query.Add(Criterion.Create<PurchaseOrderDetail>(c => c.Id, id, CriteriaOperator.Equal));
                return this._purchaseOrderDetailRepository.FindBy(query).ConvertToPurchaseOrderDetailView();

            }
            #endregion

            #region 添加

            public void AddPurchaseOrderDetail(AddPurchaseOrderDetailRequest request) {

                PurchaseOrderDetail model = this._purchaseOrderDetailRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }
                this._purchaseOrderDetailRepository.Add(model);
                this._uow.Commit();
            }

        public void AddReceiptDetail() {

        }

            #endregion

        #region 修改

        public void UpdatePurchaseOrderDetail(AddPurchaseOrderDetailRequest request) {

                PurchaseOrderDetail model = this._purchaseOrderDetailRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }

                this._purchaseOrderDetailRepository.Save(model);
                this._uow.Commit();
            }

            #endregion

            #region 删除
            public void RemovePurchaseOrderDetail(int id) {

                PurchaseOrderDetail model = this._purchaseOrderDetailRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                this._purchaseOrderDetailRepository.Remove(model);
                this._uow.Commit();
            }

            #endregion
        }
    }
