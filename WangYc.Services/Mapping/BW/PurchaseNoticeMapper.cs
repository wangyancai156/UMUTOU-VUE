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
    public static class PurchaseNoticeMapper {
        public static PurchaseNoticeView ConvertToPurchaseNoticeView(this PurchaseNotice model) {

            return Mapper.Map<PurchaseNotice, PurchaseNoticeView>(model);
        }

        public static IEnumerable<PurchaseNoticeView> ConvertToPurchaseNoticeView(this IEnumerable<PurchaseNotice> model) {

            return Mapper.Map<IEnumerable<PurchaseNotice>, IEnumerable<PurchaseNoticeView>>(model);
        }

        public static ListPaged<PurchaseNoticeView> ConvertToPurchaseNoticeView(this ListPaged<PurchaseNotice> model) {
            ListPaged<PurchaseNoticeView> view = new ListPaged<PurchaseNoticeView>();
            view.EntityList = model.EntityList.ConvertToPurchaseNoticeView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
