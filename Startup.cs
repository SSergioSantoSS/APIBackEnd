using ApiTarefa.Models;
using ApiTarefa.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace ApiTarefa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.Configure<TarefaDataSettings>(Configuration.GetSection(nameof(TarefaDataSettings)));

            services.AddSingleton<ITarefaDataSettings>(sp => sp.GetRequiredService<IOptions<TarefaDataSettings>>().Value);

            services.AddSingleton<IUsuarioDataSettings>(sp => sp.GetRequiredService<IOptions<UsuarioDataSettings>>().Value);

            services.Configure<UsuarioDataSettings>(Configuration.GetSection(nameof(UsuarioDataSettings)));

            services.AddSingleton<TarefaService>();
            services.AddSingleton<UsuarioService>();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Lista de Tarefas",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core 3.1 para lista de tarefas",
                        Contact = new OpenApiContact
                        {
                            Name = "Sérgio Santos",
                            Url = new Uri("https://github.com/SSergioSantoSS")
                        }
                    });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarefas Api V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
