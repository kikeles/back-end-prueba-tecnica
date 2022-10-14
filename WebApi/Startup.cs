using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Utilidades;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //agregar el DbContext para la creación de la base de datos desde code-first
            services.AddDbContext<JugueteContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("ConexionDB"))
            );

            //inyectando el repositorio por cada solicitud
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //inyectar el almacenador de imagenes para el proyecto de manera local en la carpeta (Imagenes)
            services.AddScoped<IAlmacenadorImagenesLocal, AlmacenadorImagenesLocal>();

            //Habilitar los cors
            services.AddCors(cors =>
            {
                cors.AddPolicy("CualquierOrigen", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            //halitar los controladores
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //usar los cors
            app.UseCors("CualquierOrigen");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //apuntar a los controladores creados
                endpoints.MapControllers();
            });

            //Permitir ingresar a la carpeta Imagenes
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Imagenes")),
                RequestPath = "/Imagenes"
            });
        }
    }
}
