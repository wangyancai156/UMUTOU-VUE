using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.RS;
using WangYc.Services.ViewModels.RS;

namespace WangYc.Services.Mapping.RS {
        public static class SupplierProductMapper {
            public static SupplierProductView ConvertToSupplierProductView(this SupplierProduct model) {

                return Mapper.Map<SupplierProduct, SupplierProductView>(model);
            }

            public static IEnumerable<SupplierProductView> ConvertToSupplierProductView(this IEnumerable<SupplierProduct> model) {

                return Mapper.Map<IEnumerable<SupplierProduct>, IEnumerable<SupplierProductView>>(model);
            }
        }
    }
