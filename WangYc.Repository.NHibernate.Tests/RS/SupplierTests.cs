using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.RS;
using WangYc.Models.RS;
using WangYc.Repository.NHibernate.Repositories.RS;

namespace WangYc.Repository.NHibernate.Tests.RS {
    [TestClass]
    public class SupplierTests {

        private readonly ISupplierRepository _supplierRepository;

        public SupplierTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._supplierRepository = new SupplierRepository(uow);
           
        }

        [TestMethod]
        public void GetSupplier() {

            IEnumerable<Supplier> model = this._supplierRepository.FindAll();
        }
 

    }
}
