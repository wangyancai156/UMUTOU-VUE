using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.RS;
using WangYc.Services.ViewModels.RS;

namespace WangYc.Services.Interfaces.RS {
    public interface ISupplierService {

        #region 查找

        /// <summary>
        /// 获取供应商视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierView> GetSupplierView(Query request);
        /// <summary>
        /// 获取所有供应商视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierView> GetSupplierViewByAll();

        /// <summary>
        /// 根据供应商号获取供应商视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<SupplierView> GetSupplierViewById(int id);
        #endregion

        #region 添加

        void AddSupplier(AddSupplierRequest request);

        #endregion

        #region 修改

        void UpdateSupplier(AddSupplierRequest request);

        #endregion

        #region 删除
        void RemoveSupplier(int id);

        #endregion
    }
}