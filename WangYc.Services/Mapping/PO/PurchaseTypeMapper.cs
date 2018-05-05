using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Mapping.PO {
    public static class PurchaseTypeMapper {
        public static PurchaseTypeView ConvertToPurchaseTypeView(this PurchaseType model) {

            return Mapper.Map<PurchaseType, PurchaseTypeView>(model);
        }

        public static IEnumerable<PurchaseTypeView> ConvertToPurchaseTypeView(this IEnumerable<PurchaseType> model) {

            return Mapper.Map<IEnumerable<PurchaseType>, IEnumerable<PurchaseTypeView>>(model);
        }
    }
}
