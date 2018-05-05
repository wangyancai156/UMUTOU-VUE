using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Mapping.PO {
    public static class PurchaseOrderDetailMapper {
        public static PurchaseOrderDetailView ConvertToPurchaseOrderDetailView(this PurchaseOrderDetail model) {

            return Mapper.Map<PurchaseOrderDetail, PurchaseOrderDetailView>(model);
        }

        public static IEnumerable<PurchaseOrderDetailView> ConvertToPurchaseOrderDetailView(this IEnumerable<PurchaseOrderDetail> model) {

            return Mapper.Map<IEnumerable<PurchaseOrderDetail>, IEnumerable<PurchaseOrderDetailView>>(model);
        }
    }
}
