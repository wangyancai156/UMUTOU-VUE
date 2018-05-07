using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.RS;
using WangYc.Services.Messaging.RS;
using WangYc.Services.ViewModels.RS;

namespace WangYc.Services.Interfaces.RS {
     public interface ISupplierProductService {
        #region 查找

        /// <summary>
        /// 获取采购单类型
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierProduct> GetSupplierProduct(Query request);

        /// <summary>
        /// 获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierProductView> GetSupplierProductView(Query request);
        /// <summary>
        /// 获取所有采购单类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierProductView> GetSupplierProductViewByAll();

        /// <summary>
        /// 根据采购单类型号获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierProductView> GetSupplierProductViewById(int id);
        #endregion

        #region 添加

        void AddSupplierProduct(AddSupplierProductRequest request);

        #endregion

        #region 修改

        void UpdateSupplierProduct(AddSupplierProductRequest request);

        #endregion

        #region 删除
        void RemoveSupplierProduct(int id);

        #endregion

    }
}
