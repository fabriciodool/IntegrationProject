using System.Security;
using System.Text;
using Doaqui.src.repositories;
using Doaqui.src.repositories.implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Doaqui.src.servicos.implementacoes;
using Doaqui.src.servicos;

namespace Doaqui
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
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // Contexto
            services.AddDbContext<src.data.DoaquiContexto>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Repositorios
            services.AddScoped<IUsuario, UsuarioRepositorio>();
            services.AddScoped<ISolicitacao, SolicitacaoRepositorio>();
            services.AddScoped<IDoacao, DoacaoRepositorio>();

            // Servicos
             services.AddScoped<IAutenticacao, AutenticacaoServicos>();

            // Controladores
            services.AddControllers();
            services.AddCors();

            // Autentificacao
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // Configure Swagger
            // TODO: Fix swagger add later on.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Doaqui", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, src.data.DoaquiContexto contexto)
        {
            // Development Environment
            if (env.IsDevelopment())
            {
                contexto.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doaqui v1");
                    //c.RoutePrefix = string.Empty;
                });
            }

            // Production Environment
            contexto.Database.EnsureCreated();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doaqui v1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
