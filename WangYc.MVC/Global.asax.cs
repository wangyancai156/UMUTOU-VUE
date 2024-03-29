﻿using Newtonsoft.Json;
using StructureMap;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.Logging;
using WangYc.Services;
using WangYc.Services.Interfaces.Account;

namespace WangYc.MVC {
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {

            //加载控制反转
            BootStrapper.ConfigureDependencies();
            //区域
            AreaRegistration.RegisterAllAreas();
            //配置调用WebApi借口
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //加载路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //加载JS/CSS文件
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //加载Mapper
            AutoMapperBootStrapper.ConfigureAutoMapper();
            //配置文件
            ApplicationSettingsFactory.InitializeApplicationSettingsFactory(ObjectFactory.GetInstance<IApplicationSettings>());
            //验证方法
            AuthenticationFactory.InitializeAuthenticationFactory(ObjectFactory.GetInstance<IAuthenticationService>());
            //
            ControllerBuilder.Current.SetControllerFactory(new WangYc.Controllers.IocControllerFactory());
            //日志
            LoggingFactory.InitializeLogFactory(ObjectFactory.GetInstance<ILogger>());
             
            LoggingFactory.GetLogger().Log("Application Started");
            //删除xml的解析 当返回值是string 时 直接返回string不是json对象
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

        }

    }
}