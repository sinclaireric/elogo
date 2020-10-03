using System;
using System.Threading.Tasks;
using E_LOGO.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace E_LOGO
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
            //services.AddDbContext<E_LOGOContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ELOGODB-mssql")));
            services.AddDbContext<E_LOGOContext>(opt =>
            {
                //opt.UseLazyLoadingProxies();
                opt.UseMySql(Configuration.GetConnectionString("ELOGODB-mysql"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.AddControllers();
            services.AddMvc()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            //------------------------------
            // configure jwt authentication
            //------------------------------
            // Notre clé secrète pour les jetons sur le back-end
            var key = Encoding.ASCII.GetBytes("my-super-secret-key");
            // On précise qu'on veut travaille avec JWT tant pour l'authentification 
            // que pour la vérification de l'authentification
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    // On exige des requêtes sécurisées avec HTTPS
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    // On précise comment un jeton reçu doit être validé
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        // On vérifie qu'il a bien été signé avec la clé définie ci-dessous
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        // On ne vérifie pas l'identité de l'émetteur du jeton
                        ValidateIssuer = false,
                        // On ne vérifie pas non plus l'identité du destinataire du jeton
                        ValidateAudience = false,
                        // Par contre, on vérifie la validité temporelle du jeton
                        ValidateLifetime = true,
                        // On précise qu'on n'applique aucune tolérance de validité temporelle
                        ClockSkew = TimeSpan.Zero  //the default for this setting is 5 minutes
                    };
                    // On peut définir des événements liés à l'utilisation des jetons
                    x.Events = new JwtBearerEvents
                    {
                        // Si l'authentification du jeton est rejetée ...
                        OnAuthenticationFailed = context =>
                                {
                                    // ... parce que le jeton est expiré ...
                                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                    {
                                        // ... on ajoute un header à destination du front-end indiquant cette expiration
                                        context.Response.Headers.Add("Token-Expired", "true");
                                    }
                                    return System.Threading.Tasks.Task.CompletedTask;
                                }
                    };
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
