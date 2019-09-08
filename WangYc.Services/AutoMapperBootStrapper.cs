using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels;
using WangYc.Models.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Models.SD;
using WangYc.Services.ViewModels.SD;
using WangYc.Models.PO;
using WangYc.Services.ViewModels.PO;
using WangYc.Models.FI;
using WangYc.Services.ViewModels.FI;
using WangYc.Models.PP;
using WangYc.Services.ViewModels.PP;
using WangYc.Models.Common;
using WangYc.Services.ViewModels.Common;
using WangYc.Services.ViewModels.RS;
using WangYc.Models.RS;

namespace WangYc.Services
{
    public static class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper() {

            #region BW

            Mapper.CreateMap<SpotInventory, SpotInventoryView>();

            Mapper.CreateMap<InOutReason, InOutReasonView>(); 
             
            Mapper.CreateMap<Warehouse, WarehouseView>();
            Mapper.CreateMap<WarehouseShelf, WarehouseShelfView>();
            
            Mapper.CreateMap<InOutBound, InOutBoundView>();
            Mapper.CreateMap<OutBound, OutBoundView>();
            Mapper.CreateMap<InBound, InBoundView>();

            Mapper.CreateMap<InOutBoundOfShelf, InOutBoundOfShelfView>();
            Mapper.CreateMap<InBoundOfShelf, InBoundOfShelfView>();
            Mapper.CreateMap<OutBoundOfShelf, OutBoundOfShelfView>();

            Mapper.CreateMap<ArrivalNoticeDetail, ArrivalNoticeDetailView>();
            Mapper.CreateMap<ArrivalNotice, ArrivalNoticeView>();
            Mapper.CreateMap<ArrivalReceiptDetail, ArrivalReceiptDetailView>();
            Mapper.CreateMap<ArrivalReceipt, ArrivalReceiptView>();

            #endregion

            #region HR

            Mapper.CreateMap<Organization, OrganizationView>();
            Mapper.CreateMap<Organization, DataTreeView>()
                .ForMember(d => d.value, t => t.MapFrom(s => s.Id))
                .ForMember(d => d.label, t => t.MapFrom(s => s.Name))
                .ForMember(d => d.children, t => t.MapFrom(s => s.Child));
            Mapper.CreateMap<Organization, DataTree>()
               .ForMember(d => d.value, t => t.MapFrom(s => s.Id))
               .ForMember(d => d.label, t => t.MapFrom(s => s.Name));

            Mapper.CreateMap<Rights, RightsView>();
            Mapper.CreateMap<Rights, DataTreeView>()
                .ForMember(d => d.value, t => t.MapFrom(s => s.Id))
                .ForMember(d => d.label, t => t.MapFrom(s => s.Name))
                .ForMember(d => d.children, t => t.MapFrom(s => s.Child));
            Mapper.CreateMap<Rights, DataTree>()
              .ForMember(d => d.value, t => t.MapFrom(s => s.Id))
              .ForMember(d => d.label, t => t.MapFrom(s => s.Name));

            Mapper.CreateMap<Role, RoleView>();
            Mapper.CreateMap<Role, DataTreeView>()
               .ForMember(d => d.value, t => t.MapFrom(s => s.Id))
               .ForMember(d => d.label, t => t.MapFrom(s => s.Name))
               .ForMember(d => d.children, t => t.MapFrom(s => s.Child));
            Mapper.CreateMap<Role, DataTree>()
              .ForMember(d => d.value, t => t.MapFrom(s => s.Id))
              .ForMember(d => d.label, t => t.MapFrom(s => s.Name));

            Mapper.CreateMap<Users, UsersView>();
            Mapper.CreateMap<UserDevice, UserDeviceView>();
            #endregion 

            #region PO

            Mapper.CreateMap<PurchaseOrder, PurchaseOrderView>();
            Mapper.CreateMap<PurchaseOrderDetail, PurchaseOrderDetailView>();
            Mapper.CreateMap<PurchaseType, PurchaseTypeView>();

            #endregion

            #region RS

            Mapper.CreateMap<Supplier, SupplierView>();
            Mapper.CreateMap<SupplierProduct, SupplierProductView>();
            

            #endregion

            #region SD

            Mapper.CreateMap<Product, ProductView>();
            Mapper.CreateMap<ProductType, ProductTypeView>();

            #endregion

            #region FI

            Mapper.CreateMap<Payment, PaymentView>();
            Mapper.CreateMap<PaymentType, PaymentTypeView>();

            #endregion

            #region PP

            Mapper.CreateMap<Project, ProjectView>();
            Mapper.CreateMap<ProjectAttendance, ProjectAttendanceView>();
            Mapper.CreateMap<ProjectMaterial, ProjectMaterialView>();
            Mapper.CreateMap<ProjectProduct, ProjectProductView>();
            Mapper.CreateMap<ProjectType, ProjectTypeView>();
 
            #endregion


            #region Common

            Mapper.CreateMap<WorkflowActivity, WorkflowActivityView>();
            
            #endregion
        }

    }
}
