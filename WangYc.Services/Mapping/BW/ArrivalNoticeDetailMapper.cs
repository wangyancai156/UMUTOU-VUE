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
        public static ArrivalNoticeDetailView ConvertToArrivalNoticeDetailView(this ArrivalNoticeDetail model) {

            return Mapper.Map<ArrivalNoticeDetail, ArrivalNoticeDetailView>(model);
        }

        public static IEnumerable<ArrivalNoticeDetailView> ConvertToArrivalNoticeDetailView(this IEnumerable<ArrivalNoticeDetail> model) {

            return Mapper.Map<IEnumerable<ArrivalNoticeDetail>, IEnumerable<ArrivalNoticeDetailView>>(model);
        }

        public static ListPaged<ArrivalNoticeDetailView> ConvertToArrivalNoticeDetailView(this ListPaged<ArrivalNoticeDetail> model) {
            ListPaged<ArrivalNoticeDetailView> view = new ListPaged<ArrivalNoticeDetailView>();
            view.EntityList = model.EntityList.ConvertToArrivalNoticeDetailView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
