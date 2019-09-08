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
    public static class ArrivalReceiptDetailMapper {

        public static ArrivalReceiptDetailView ConvertToArrivalReceiptDetailView(this ArrivalReceiptDetail model) {

            return Mapper.Map<ArrivalReceiptDetail, ArrivalReceiptDetailView>(model);
        }

        public static IEnumerable<ArrivalReceiptDetailView> ConvertToArrivalReceiptDetailView(this IEnumerable<ArrivalReceiptDetail> model) {

            return Mapper.Map<IEnumerable<ArrivalReceiptDetail>, IEnumerable<ArrivalReceiptDetailView>>(model);
        }

        public static ListPaged<ArrivalReceiptDetailView> ConvertToPagedView(this ListPaged<ArrivalReceiptDetail> model) {

            ListPaged<ArrivalReceiptDetailView> view = new ListPaged<ArrivalReceiptDetailView>();
            view.EntityList = model.EntityList.ConvertToArrivalReceiptDetailView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}