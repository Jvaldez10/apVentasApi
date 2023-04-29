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
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);

            this.ServicesTransitorioModulos(services);
            this.ServicesTransitorioRepositorio(services);
            this.ServicesTransitorioConsulta(services);
            this.ServicesUtils(services);

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
            //app.UseAuthorization();
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
            services.AddTransient<PlanClienteModulo>();
            services.AddTransient<PlanProductoModulo>();
            services.AddTransient<PlanProveedoresModulo>();
            services.AddTransient<MonedaModule>();
            services.AddTransient<NivelModule>();
            services.AddTransient<ClienteModule>();
            services.AddTransient<ClasificacionModule>();
            services.AddTransient<ProductoModule>();
            services.AddTransient<AsientoModule>();
            services.AddTransient<TipoAsientoModule>();
            services.AddTransient<AsientoPlanCuentaModule>();
        }
        private void ServicesTransitorioRepositorio(IServiceCollection services)
        {
            services.AddTransient<ProveedoresRepositorio>();
            services.AddTransient<VPlanCuentasRepositorios>();
            services.AddTransient<VAlmacenRepositorio>();
            services.AddTransient<VPlanClienteRepositorio>();
            services.AddTransient<VPlanProductoRepositorio>();
            services.AddTransient<VPlanProveedoresRepositorio>();
            services.AddTransient<VMonedaRepositorio>();
            services.AddTransient<VNivelRepositorio>();
            services.AddTransient<VClienteRepositorio>();
            services.AddTransient<VClasificacionRepositorio>();
            services.AddTransient<VProductoRepositorio>();
            services.AddTransient<VProductoImagenesRepositorio>();
            services.AddTransient<TipoAsientoRespositorio>();
            services.AddTransient<AsientoRespositorio>();
            services.AddTransient<AsientoPlanCuentaRespositorio>();
            services.AddTransient<ConfiguracionPlanCuentaRepositorio>();
            services.AddTransient<TipoClasificacionRepositorio>();
            services.AddTransient<GeneralRepositorio>();
        }
        private void ServicesTransitorioConsulta(IServiceCollection services)
        {
            services.AddTransient<ProveedoresConsulta>();
            services.AddTransient<VPlanCuentaConsulta>();
            services.AddTransient<VAlmacenConsulta>();
            services.AddTransient<VPlanClientesConsulta>();
            services.AddTransient<VPlanProductosConsulta>();
            services.AddTransient<VPlanProveedoresConsulta>();
            services.AddTransient<VNivelConsulta>();
            services.AddTransient<VMonedaConsulta>();
            services.AddTransient<VentasConsulta>();
        }
        private void ServicesUtils(IServiceCollection services)
        {
            services.AddTransient<FilesConvert>();
            services.AddTransient<Letras>();
        }
    }
}