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
    public static class PurchaseReceiptMapper {
        public static PurchaseReceiptView ConvertToPurchaseReceiptView(this PurchaseReceipt model) {

            return Mapper.Map<PurchaseReceipt, PurchaseReceiptView>(model);
        }

        public static IEnumerable<PurchaseReceiptView> ConvertToPurchaseReceiptView(this IEnumerable<PurchaseReceipt> model) {

            return Mapper.Map<IEnumerable<PurchaseReceipt>, IEnumerable<PurchaseReceiptView>>(model);
        }

        public static ListPaged<PurchaseReceiptView> ConvertToPagedView(this ListPaged<PurchaseReceipt> model) {

            ListPaged<PurchaseReceiptView> view = new ListPaged<PurchaseReceiptView>();
            view.EntityList = model.EntityList.ConvertToPurchaseReceiptView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
