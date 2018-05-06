using StructureMap;
using StructureMap.Configuration.DSL;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Core.Infrastructure.Logging;
using WangYc.Core.Infrastructure.Account;
using WangYc.Core.Infrastructure.Domain;

using WangYc.Models.HR;

using WangYc.Models.Repository.BW;
using WangYc.Models.Repository.FI;
using WangYc.Models.Repository.HR;
using WangYc.Models.Repository.PO;
using WangYc.Models.Repository.PP;
using WangYc.Models.Repository.RS;
using WangYc.Models.Repository.SD;

using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.BW;
using WangYc.Repository.NHibernate.Repositories.FI;
using WangYc.Repository.NHibernate.Repositories.HR;
using WangYc.Repository.NHibernate.Repositories.PO;
using WangYc.Repository.NHibernate.Repositories.PP;
using WangYc.Repository.NHibernate.Repositories.RS;
using WangYc.Repository.NHibernate.Repositories.SD;

using WangYc.Services.Interfaces.BW;
using WangYc.Services.Interfaces.FI;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Interfaces.PO;
using WangYc.Services.Interfaces.PP;
using WangYc.Services.Interfaces.RS;
using WangYc.Services.Interfaces.SD;

using WangYc.Services.Implementations.BW;
using WangYc.Services.Implementations.FI;
using WangYc.Services.Implementations.HR;
using WangYc.Services.Implementations.PO;
using WangYc.Services.Implementations.PP;
using WangYc.Services.Implementations.RS;
using WangYc.Services.Implementations.SD;

namespace WangYc.MVC
{
    public class BootStrapper {

        public static void ConfigureDependencies() {
            ObjectFactory.Initialize(x => {
                x.AddRegistry<ControllerRegistry>();
            });
        }

        public class ControllerRegistry : Registry {

            public ControllerRegistry() {

                #region BW


                For<IInOutBoundRepository>().Use<InOutBoundRepository>();
                For<IOutBoundRepository>().Use<OutBoundRepository>();
                For<IInBoundRepository>().Use<InBoundRepository>();
                For<IInOutBoundService>().Use<InOutBoundService>();

                For<IWarehouseRepository>().Use<WarehouseRepository>();
                For<IWarehouseService>().Use<WarehouseService>();

                For<IWarehouseShelfRepository>().Use<WarehouseShelfRepository>();
                For<IWarehouseShelfService>().Use<WarehouseShelfService>();

                For<IPurchaseReceiptService>().Use<PurchaseReceiptService>();
                For<IPurchaseReceiptRepository>().Use<PurchaseReceiptRepository>();



                #endregion

                #region FI

                For<IPaymentRepository>().Use<PaymentRepository>();
                For<IPaymentService>().Use<PaymentService>();

                For<IPaymentTypeRepository>().Use<PaymentTypeRepository>();
                For<IPaymentTypeService>().Use<PaymentTypeService>();


                #endregion

                #region HR

                For<IUsersRepository>().Use<WangYc.Repository.NHibernate.Repositories.HR.UsersRepository>();
                For<IUsersService>().Use<UsersService>();

                For<IOrganizationRepository>().Use<WangYc.Repository.NHibernate.Repositories.HR.OrganizationRepository>();
                For<IOrganizationService>().Use<OrganizationService>();

                For<IRightsRepository>().Use<RightsRepository>();
                For<IRightsService>().Use<RightsService>();

                For<IRoleRepository>().Use<RoleRepository>();
                For<IRoleService>().Use<RoleService>();

                #endregion

                #region PO

                For<IPurchaseOrderRepository>().Use<PurchaseOrderRepository>();
                For<IPurchaseOrderService>().Use<PurchaseOrderService>();

                For<IPurchaseTypeRepository>().Use<PurchaseTypeRepository>();
                For<IPurchaseTypeService>().Use<PurchaseTypeService>();

                For<IPurchaseOrderDetailRepository>().Use<PurchaseOrderDetailRepository>();
           

                #endregion

                #region PP

                For<IProjectRepository>().Use<ProjectRepository>();
                For<IProjectService>().Use<ProjectService>();

                For<IProjectAttendanceRepository>().Use<ProjectAttendanceRepository>();
                For<IProjectAttendanceService>().Use<ProjectAttendanceService>();
                
                For<IProjectMaterialRepository>().Use<ProjectMaterialRepository>();
                For<IProjectMaterialService>().Use<ProjectMaterialService>();

                #endregion

                #region RS

                For<ISupplierRepository>().Use<SupplierRepository>();
                For<ISupplierService>().Use<SupplierService>();


                #endregion

                #region SD

                For<IProductRepository>().Use<ProductRepository>();
                For<IProductService>().Use<ProductService>();
                For<IProductTypeRepository>().Use<ProductTypeRepository>();
                For<IProductTypeService>().Use<ProductTypeService>();

                #endregion

             

                // Application Settings
                For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                // NH工作单元
                For<IUnitOfWork>().Use<WangYc.Repository.NHibernate.NHUnitOfWork>();
                // Logger
                For<ILogger>().Use<WangYc.Core.Infrastructure.Logging.Log4NetAdapter>();
                // Cookie
                For<ICookieStorageService>().Use<CookieStorageService>();
                // 登录验证
                For<IAuthenticationService>().Use<AuthenticationService>();
   
            }
        }

    }
}