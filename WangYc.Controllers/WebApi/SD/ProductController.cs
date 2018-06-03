using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WangYc.Controllers.Account.WebApi;
using WangYc.Services.Interfaces.SD;

namespace WangYc.Controllers.WebApi.SD {
    public class ProductController : BaseApiController {

        private IProductService _productService;

        public ProductController(IProductService productService) {

            this._productService = productService;
        }

        public HttpResponseMessage GetProductView() {

            return ToJson(this._productService.GetProductView());
        }
    }
}
