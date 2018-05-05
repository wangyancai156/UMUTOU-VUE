using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.FI;
using WangYc.Services.ViewModels.FI;

namespace WangYc.Services.Mapping.FI {
    public static class PaymentMapper {
     public static PaymentView ConvertToPaymentView(this Payment model) {

            return Mapper.Map<Payment, PaymentView>(model);
        }

        public static IEnumerable<PaymentView> ConvertToPaymentView(this IEnumerable<Payment> model) {

            return Mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentView>>(model);
        }
    }
}
