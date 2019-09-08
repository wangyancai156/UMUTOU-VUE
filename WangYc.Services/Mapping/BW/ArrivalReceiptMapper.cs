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
    public static class ArrivalReceiptMapper {
        public static ArrivalReceiptView ConvertToArrivalReceiptView(this ArrivalReceipt model) {

            return Mapper.Map<ArrivalReceipt, ArrivalReceiptView>(model);
        }

        public static IEnumerable<ArrivalReceiptView> ConvertToArrivalReceiptView(this IEnumerable<ArrivalReceipt> model) {

            return Mapper.Map<IEnumerable<ArrivalReceipt>, IEnumerable<ArrivalReceiptView>>(model);
        }

        public static ListPaged<ArrivalReceiptView> ConvertToPagedView(this ListPaged<ArrivalReceipt> model) {

            ListPaged<ArrivalReceiptView> view = new ListPaged<ArrivalReceiptView>();
            view.EntityList = model.EntityList.ConvertToArrivalReceiptView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
