using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.SD;
using WangYc.Services.Messaging.SD;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.Interfaces.SD {
    public interface IProductTypeService {



        #region 查找


        /// <summary>
        /// 获取产品类型
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductType> GetProductType(Query request);

        /// <summary>
        /// 获取产品类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductTypeView> GetProductTypeView(Query request);
        #endregion

        #region 添加

        void AddProductType(AddProductTypeRequest request);

        #endregion

        #region 修改

        void UpdateProductType(AddProductTypeRequest request);

        #endregion

        #region 删除
        void RemoveProductType(int id);

        #endregion
    }
}
