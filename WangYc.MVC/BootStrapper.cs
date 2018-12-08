using StructureMap;
using StructureMap.Configuration.DSL;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Core.Infrastructure.Logging;
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
using WangYc.Models.Repository.Common;
using WangYc.Repository.NHibernate.Repositories.Common;
using WangYc.Services.Interfaces.Common;
using WangYc.Services.Implementations.Common;
using WangYc.Models.PO;
using WangYc.Services.Interfaces.Account;
using WangYc.Services.Implementations.Account;

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

                For<ISpotInventoryRepository>().Use<SpotInventoryRepository>();
                For<ISpotInventoryService>().Use<SpotInventoryService>();
                
                For<IInOutReasonRepository>().Use<InOutReasonRepository>();
                For<IInOutReasonService>().Use<InOutReasonService>(); 

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
                
                For<IPurchaseReceiptDetailRepository>().Use<PurchaseReceiptDetailRepository>(); 

                For<IPurchaseNoticeService>().Use<PurchaseNoticeService>();
                For<IPurchaseNoticeRepository>().Use<PurchaseNoticeRepository>();

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
                For<IIdGenerator<Users, string>>().Use<IdGenerator<Users>>();

                For<IUserDeviceService>().Use<UserDeviceService>();
                For<IUserDeviceRepository>().Use<UserDeviceRepository>();

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
                For<IIdGenerator<PurchaseOrder, string>>().Use<IdGenerator<PurchaseOrder>>();

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

                For<IProjectProductRepository>().Use<ProjectProductRepository>();
                For<IProjectProductService>().Use<ProjectProductService>();

                For<IProjectTypeRepository>().Use<ProjectTypeRepository>();
                For<IProjectTypeService>().Use<ProjectTypeService>();

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

                #region Common

                For<IWorkflowActivityRepository>().Use<WorkflowActivityRepository>();
                For<IWorkflowActivityService>().Use<WorkflowActivityService>();

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