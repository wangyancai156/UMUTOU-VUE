using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.SD;
using WangYc.Services.ViewModels.SD;

namespace WangYc.Services.Mapping.SD {
    public static class ProductTypeMapper {
        public static ProductTypeView ConvertToProductTypeView(this ProductType model) {

            return Mapper.Map<ProductType, ProductTypeView>(model);
        }

        public static IEnumerable<ProductTypeView> ConvertToProductTypeView(this IEnumerable<ProductType> model) {

            return Mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeView>>(model);
        }
    }
}
