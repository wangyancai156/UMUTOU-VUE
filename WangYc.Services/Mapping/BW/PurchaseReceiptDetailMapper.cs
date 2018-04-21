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
    public static class PurchaseReceiptDetailMapper {

        public static PurchaseReceiptDetailView ConvertToPurchaseReceiptDetailView(this PurchaseReceiptDetail model) {

            return Mapper.Map<PurchaseReceiptDetail, PurchaseReceiptDetailView>(model);
        }

        public static IEnumerable<PurchaseReceiptDetailView> ConvertToPurchaseReceiptDetailView(this IEnumerable<PurchaseReceiptDetail> model) {

            return Mapper.Map<IEnumerable<PurchaseReceiptDetail>, IEnumerable<PurchaseReceiptDetailView>>(model);
        }

        public static ListPaged<PurchaseReceiptDetailView> ConvertToPagedView(this ListPaged<PurchaseReceiptDetail> model) {

            ListPaged<PurchaseReceiptDetailView> view = new ListPaged<PurchaseReceiptDetailView>();
            view.EntityList = model.EntityList.ConvertToPurchaseReceiptDetailView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}