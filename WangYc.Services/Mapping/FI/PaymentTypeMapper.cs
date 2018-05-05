using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.FI;
using WangYc.Services.ViewModels.FI;

namespace WangYc.Services.Mapping.FI {
   public static class PaymentTypeMapper {
        public static PaymentTypeView ConvertToPaymentTypeView(this PaymentType model) {

            return Mapper.Map<PaymentType, PaymentTypeView>(model);
        }

        public static IEnumerable<PaymentTypeView> ConvertToPaymentTypeView(this IEnumerable<PaymentType> model) {

            return Mapper.Map<IEnumerable<PaymentType>, IEnumerable<PaymentTypeView>>(model);
        }
    }
}
