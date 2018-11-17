using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Mapping.PO {
    public static class PurchaseOrderMapper {

        public static PurchaseOrderView ConvertToPurchaseOrderView(this PurchaseOrder model) {

            return Mapper.Map<PurchaseOrder, PurchaseOrderView>(model);
        }

        public static IEnumerable<PurchaseOrderView> ConvertToPurchaseOrderView(this IEnumerable<PurchaseOrder> model) {

            return Mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderView>>(model);
        }

        public static ListPaged<PurchaseOrderView> ConvertToPurchaseOrderPagedView(this ListPaged<PurchaseOrder> model) {
            ListPaged<PurchaseOrderView> view = new ListPaged<PurchaseOrderView>();
            view.EntityList = model.EntityList.ConvertToPurchaseOrderView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
