using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Mapping.BW {
   
        public static class InOutReasonMapper {
            public static InOutReasonView ConvertToInOutReasonView(this InOutReason model) {

                return Mapper.Map<InOutReason, InOutReasonView>(model);
            }

            public static IEnumerable<InOutReasonView> ConvertToInOutReasonView(this IEnumerable<InOutReason> model) {

                return Mapper.Map<IEnumerable<InOutReason>, IEnumerable<InOutReasonView>>(model);
            }
        }
    }
