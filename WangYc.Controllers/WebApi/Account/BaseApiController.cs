using System;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using WangYc.Controllers.WebApi.Account;

namespace WangYc.Controllers.Account.WebApi {
    //添加验证
    //[ApiAuthFilterOutside]
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
