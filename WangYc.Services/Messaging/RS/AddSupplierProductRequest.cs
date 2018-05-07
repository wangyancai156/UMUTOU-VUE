using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.RS {
    public class AddSupplierProductRequest {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public string CreateUserId { get; set; }
        public decimal Price { get; set; }


    }
}
