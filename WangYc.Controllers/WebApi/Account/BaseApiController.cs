using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace WangYc.Controllers.Account.WebApi
{
    public class BaseApiController : ApiController
    {

        public HttpResponseMessage ToJson(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                var serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            var result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

    }
}
