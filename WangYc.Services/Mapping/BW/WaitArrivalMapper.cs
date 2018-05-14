using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
        public static class WaitArrivalMapper {
            public static WaitArrivalView ConvertToWaitArrivalView(this WaitArrival model) {

                return Mapper.Map<WaitArrival, WaitArrivalView>(model);
            }

            public static IEnumerable<WaitArrivalView> ConvertToWaitArrivalView(this IEnumerable<WaitArrival> model) {

                return Mapper.Map<IEnumerable<WaitArrival>, IEnumerable<WaitArrivalView>>(model);
            }
        }
    }
