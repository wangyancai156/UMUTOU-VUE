using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Mapping.PO {
    public static class PurchaseOrderMapper {

        public static PurchaseOrderView ConvertToPurchaseOrderView(this PurchaseOrder model) {

            return Mapper.Map<PurchaseOrder, PurchaseOrderView>(model);
        }

        public static IEnumerable<PurchaseOrderView> ConvertToPurchaseOrderView(this IEnumerable<PurchaseOrder> model) {

            return Mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderView>>(model);
        }
    }
}
