using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistema_venta_erp.Consultas;
using sistema_venta_erp.Contexto;
using sistema_venta_erp.Modulos;
using sistema_venta_erp.Repositorio;
using sistema_venta_erp.Utilidades;

namespace sistema_venta_erp
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var getStringConnectionMysql = configRoot.GetSection("connectionMysql").Get<StringConnection>();
            var mysqlConnect = $"Server={getStringConnectionMysql.IpServer};Port={getStringConnectionMysql.Port};Database={getStringConnectionMysql.Database};User={getStringConnectionMysql.User};Password={getStringConnectionMysql.Password};";

            services.AddDbContext<DBContext>(options =>
            {
                options.UseMySql(mysqlConnect, ServerVersion.AutoDetect(mysqlConnect));
            });

            this.ServicesTransitorioModulos(services);
            this.ServicesTransitorioRepositorio(services);
            this.ServicesTransitorioConsulta(services);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else //use en produccion - ambiente de desarrollo
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.UseCors(
                options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }
            );
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        /*Modulos*/
        private void ServicesTransitorioModulos(IServiceCollection services)
        {
            services.AddTransient<ProveedoresModulo>();
            services.AddTransient<PlanCuentaModulo>();
            services.AddTransient<AlmacenModulo>();
        }
        private void ServicesTransitorioRepositorio(IServiceCollection services)
        {
            services.AddTransient<ProveedoresRepositorio>();
            services.AddTransient<VPlanCuentasRepositorios>();
            services.AddTransient<VAlmacenRepositorio>();
        }
        private void ServicesTransitorioConsulta(IServiceCollection services)
        {
            services.AddTransient<ProveedoresConsulta>();
            services.AddTransient<VPlanCuentaConsulta>();
            services.AddTransient<VAlmacenConsulta>();
        }
    }
}