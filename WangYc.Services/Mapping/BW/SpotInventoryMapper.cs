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
    public static class SpotInventoryMapper {
        public static SpotInventoryView ConvertToSpotInventoryView(this SpotInventory model) {

            return Mapper.Map<SpotInventory, SpotInventoryView>(model);
        }

        public static IEnumerable<SpotInventoryView> ConvertToSpotInventoryView(this IEnumerable<SpotInventory> model) {

            return Mapper.Map<IEnumerable<SpotInventory>, IEnumerable<SpotInventoryView>>(model);
        }

        public static ListPaged<SpotInventoryView> ConvertToSpotInventoryPagedView(this ListPaged<SpotInventory> model) {
            ListPaged<SpotInventoryView> view = new ListPaged<SpotInventoryView>();
            view.EntityList = model.EntityList.ConvertToSpotInventoryView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}