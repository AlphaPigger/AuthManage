using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application;
using AuthManage.Application.AppServices;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.IRepositories;
using AuthManage.Infrastructure;
using AuthManage.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthManage.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //初始化映射关系（Entity和Dto之间的映射关系）
            AuthManageMapper.Initialize();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //连接Mysql数据库
            var mysqlConnectString = Configuration.GetConnectionString("MysqlConnectString");
            services.AddDbContextPool<DataContext>(options=>options.UseMySql(mysqlConnectString,b=>b.MigrationsAssembly("AuthManage.MVC")));
            //依赖注入
            services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            services.AddScoped<IRoleAppService,RoleAppService>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IRoleUserAppService, RoleUserAppService>();
            services.AddScoped<IRoleUserRepository, RoleUserRepository>();
            services.AddScoped<IRoleMenuAppService, RoleMenuAppService>();
            services.AddScoped<IRoleMenuRepository, RoleMenuRepository>();
            services.AddScoped<IProjectAppService,ProjectAppService>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IHardwareAppService,HardwareAppService>();
            services.AddScoped<IHardwareRepository,HardwareRepository>();
            services.AddScoped<IItemBaseOnHardwareAppService,ItemBaseOnHardwareAppService>();
            services.AddScoped<IItemBaseOnHardwareRepository,ItemBaseOnHardwareRepository>();
            services.AddScoped<IItemAppService,ItemAppService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IRecordAppService,RecordAppService > ();
            services.AddScoped<IRecordRepository, RecordRepository>();
            //Session服务
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //开发环境异常处理
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //生成环境异常处理
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //使用Session
            app.UseSession();
            //使用MVC，设置默认路由为系统登录
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
