using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Models.SD;
using WangYc.Services.Interfaces.SD;

namespace WangYc.Services.Implementations.BW {
    public class SpotInventoryService : ISpotInventoryService {

        private readonly ISpotInventoryRepository _spotInventoryRepository;
        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private readonly IUnitOfWork _uow;

       

        public SpotInventoryService(ISpotInventoryRepository spotInventoryRepository, IProductService productService, IWarehouseService warehouseService, IUnitOfWork uow) {

            this._spotInventoryRepository = spotInventoryRepository;
            this._productService = productService;
            this._warehouseService = warehouseService;
            this._uow = uow;
        }
         
        public ListPaged<SpotInventoryView> GetSpotInventory(GetSpotInventoryRequest request) {

            Query query = new Query();
            if (request.ProductId != null)
                query.Add(Criterion.Create<SpotInventory>(p => p.Product.Id, request.ProductId, CriteriaOperator.Equal));
            if (request.WarehouseId != null)
                query.Add(Criterion.Create<SpotInventory>(p => p.Warehouse.Id, request.WarehouseId, CriteriaOperator.Equal));

            query.Add(Criterion.Create<SpotInventory>(p => p.Qty, 1, CriteriaOperator.GreaterThanOrEqual));

            return this._spotInventoryRepository.PagedFindBy(query, request.PageIndex, request.PageSize).ConvertToSpotInventoryPagedView();
        }

        public SpotInventory GetSpotInventory(int productId, int warehouseId) {

            Query query = new Query();
            if (productId != 0)
                query.Add(Criterion.Create<SpotInventory>(p => p.Product.Id, productId, CriteriaOperator.Equal));
            if (warehouseId != 0)
                query.Add(Criterion.Create<SpotInventory>(p => p.Warehouse.Id, warehouseId, CriteriaOperator.Equal));
            IEnumerable<SpotInventory> demol = this._spotInventoryRepository.FindBy(query);
            if (demol.Count() ==0) {
                return null;
            } else {
                return this._spotInventoryRepository.FindBy(query).First();
            }
        }


        public void InSpotInventory(int productId, int warehouseId, int qty, float price, string currency) {
            
            SpotInventory model = this.GetSpotInventory(productId, warehouseId);
            if (model == null) {
               
                Product product = this._productService.GetProduct(productId);
                if (product == null) {
                    throw new EntityIsInvalidException<string>(productId.ToString());
                }
                Warehouse warehouse = this._warehouseService.GetWarehouse(warehouseId);
                if (warehouse == null) {
                    throw new EntityIsInvalidException<string>(warehouseId.ToString());
                }
                model = new SpotInventory(product, warehouse,qty,price, currency);
            } else {
               
                model.InBound(qty, price);
            }

            this._spotInventoryRepository.Save(model);
            this._uow.Commit();

        }

        public void OutSpotInventory(int productId, int warehouseId, int qty) {

            SpotInventory model = this.GetSpotInventory(productId, warehouseId);
            if (model != null) {

                model.OutBound(qty);
                this._uow.Commit();
            }
        }
    }
}