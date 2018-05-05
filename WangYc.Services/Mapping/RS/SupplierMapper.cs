using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.RS;
using WangYc.Services.ViewModels.RS;

namespace WangYc.Services.Mapping.RS {
    public static class SupplierMapper {
        public static SupplierView ConvertToSupplierView(this Supplier model) {

            return Mapper.Map<Supplier, SupplierView>(model);
        }

        public static IEnumerable<SupplierView> ConvertToSupplierView(this IEnumerable<Supplier> model) {

            return Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierView>>(model);
        }
    }
}
