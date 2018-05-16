using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Infrastructure.Helpers {
    public static class IdIncrease {


        public static string StringIncrease(string stringId) {

            string result = stringId;
            if (result == "") {
                result = "A";
                return result;
            }

            result = result.ToUpper();
            bool overflow = false;
            ASCIIEncoding ae = new ASCIIEncoding();
            byte[] bytes = ae.GetBytes(result);
            for (int i = bytes.Length - 1; i >= 0; i--) {
                bytes[i]++;
                if (bytes[i] <= 90) {
                    overflow = false;
                    break;
                } else {
                    overflow = true;
                    bytes[i] = 65;
                }
            }
            result = ae.GetString(bytes);
            if (overflow) {
                result = "A" + result;
            }
            return result;
        }

        public static string IntIncrease(string stringId) {
            string result = stringId;
            int number = 1, lenth = 1;
            if (result != "" && result != null) {
                number = Convert.ToInt32(stringId) + 1;
                lenth = stringId.Length;
            }
            result = number.ToString().PadLeft(lenth, '0');
            return result;
        }
    }
}
