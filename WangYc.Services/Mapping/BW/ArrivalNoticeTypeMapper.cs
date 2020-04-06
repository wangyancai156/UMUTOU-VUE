using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class ArrivalNoticeTypeMapper {

        public static ArrivalNoticeTypeView ConvertToArrivalNoticeTypeView( this ArrivalNoticeType model ) {

            return Mapper.Map<ArrivalNoticeType,ArrivalNoticeTypeView>(model);
        }

        public static IEnumerable<ArrivalNoticeTypeView> ConvertToArrivalNoticeTypeView( this IEnumerable<ArrivalNoticeType> model ) {

            return Mapper.Map<IEnumerable<ArrivalNoticeType>,IEnumerable<ArrivalNoticeTypeView>>(model);
        }
    }
}
