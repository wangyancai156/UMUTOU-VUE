using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.HR;
using WangYc.Models.Repository.RS;
using WangYc.Models.Repository.SD;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.HR;
using WangYc.Repository.NHibernate.Repositories.RS;
using WangYc.Repository.NHibernate.Repositories.SD;
using WangYc.Services.Implementations.RS;
using WangYc.Services.Interfaces.RS;
using WangYc.Services.Mapping.RS;

namespace WangYc.Services.Tests.RS {

    [TestClass]
    public class SupplierTests {

        private readonly ISupplierService _supplierService;
        private readonly ISupplierRepository _supplierRepository;

        private readonly ISupplierProductService _supplierProductService;
        private readonly ISupplierProductRepository _supplierProductRepository;

        private readonly IUsersRepository _usersRepository;
        private readonly IProductRepository _productRepository;


        public SupplierTests() {

            IUnitOfWork uow = new NHUnitOfWork();

            this._supplierProductRepository = new SupplierProductRepository(uow);
            this._supplierProductService = new SupplierProductService(this._supplierProductRepository, uow);

            this._usersRepository = new UsersRepository(uow);
            this._productRepository = new ProductRepository(uow);

            this._supplierRepository = new SupplierRepository(uow);
            this._supplierService = new SupplierService(this._supplierRepository, this._usersRepository, this._productRepository, uow);
        }

        [TestMethod]
        public void GetSupplier() {

            this._supplierService.GetSupplierViewByAll();
        }

        [TestMethod]
        public void GetSupplierProduct() {

            this._supplierProductService.GetSupplierProductViewByAll();
        }

    }
}
