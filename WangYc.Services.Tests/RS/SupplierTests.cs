using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.RS;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.RS;
using WangYc.Services.Implementations.RS;
using WangYc.Services.Interfaces.RS;
using WangYc.Services.Mapping.RS;

namespace WangYc.Services.Tests.RS {

    [TestClass]
    public class SupplierTests {
        private readonly ISupplierService _supplierService;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._supplierRepository = new SupplierRepository(uow);
            this._supplierService = new SupplierService(this._supplierRepository, uow);
        }

        [TestMethod]
        public void GetPurchaseOrder() {

            this._supplierService.GetSupplierViewByAll();
        }

    }
}
