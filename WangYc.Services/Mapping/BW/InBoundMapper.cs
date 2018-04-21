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
    public static class InBoundMapper {

        public static InBoundView ConvertToInBoundView(this InOutBound model) {

            return Mapper.Map<InOutBound, InBoundView>(model);
        }

        public static IEnumerable<InBoundView> ConvertToInBoundView(this IEnumerable<InBound> model) {

            return Mapper.Map<IEnumerable<InOutBound>, IEnumerable<InBoundView>>(model);
        }

        public static ListPaged<InBoundView> ConvertToInBoundPagedView(this ListPaged<InBound> model)
        {
            ListPaged<InBoundView> view = new ListPaged<InBoundView>();
            view.EntityList = model.EntityList.ConvertToInBoundView().ToList();
            view.TotalCount = model.TotalCount;
            view.PageCount = model.PageCount;
            view.PageIndex = model.PageIndex;
            view.PageSize = model.PageSize;
            return view;
        }
    }
}
