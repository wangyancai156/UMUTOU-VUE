using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.SD;
using WangYc.Models.SD;
using WangYc.Services.Interfaces.SD;
using WangYc.Services.Mapping.SD;
using WangYc.Services.Messaging.SD;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.Implementations.SD {
    public class ProductTypeService : IProductTypeService {
      
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IUnitOfWork _uow;

        public ProductTypeService(
            IProductTypeRepository productTypeRepository,
            IUnitOfWork uow
        ) {

            this._productTypeRepository = productTypeRepository;
            this._uow = uow;
        }

        #region 查找


        /// <summary>
        /// 获取产品类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductType> GetProductType(Query request) {

            IEnumerable<ProductType> model = _productTypeRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取产品类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductTypeView> GetProductTypeView(Query request) {

            IEnumerable<ProductType> model = _productTypeRepository.FindBy(request);
            return model.ConvertToProductTypeView();
        }
        #endregion

        #region 添加

        public void AddProductType(AddProductTypeRequest request) {
            
            ProductType model = new ProductType(request.Name);
            this._productTypeRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdateProductType(AddProductTypeRequest request) {

            ProductType model = this._productTypeRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            
            model.Name = request.Name;
            this._productTypeRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemoveProductType(int id) {

            ProductType model = this._productTypeRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._productTypeRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion




    }
}
