using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
    public static class ArrivalNoticeDetailMapper {
        public static ArrivalNoticeView ConvertToArrivalNoticeView(this ArrivalNoticeDetail model) {

            return Mapper.Map<ArrivalNoticeDetail, ArrivalNoticeView>(model);
        }

        public static IEnumerable<ArrivalNoticeView> ConvertToArrivalNoticeView(this IEnumerable<ArrivalNoticeDetail> model) {

            return Mapper.Map<IEnumerable<ArrivalNoticeDetail>, IEnumerable<ArrivalNoticeView>>(model);
        }

        public static ListPaged<ArrivalNoticeView> ConvertToArrivalNoticeView(this ListPaged<ArrivalNoticeDetail> model) {
            ListPaged<ArrivalNoticeView> view = new ListPaged<ArrivalNoticeView>();
            view.EntityList = model.EntityList.ConvertToArrivalNoticeView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
