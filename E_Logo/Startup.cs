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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Microsoft.Net.Http.Headers;

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
                opt.UseLazyLoadingProxies();
                opt.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
                opt.UseMySql(Configuration.GetConnectionString("ELOGODB-mysql"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Policy1", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                    .WithMethods("POST", "GET", "PUT", "DELETE")
                    .WithHeaders(HeaderNames.ContentType);
                });
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
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            //------------------------------
            // configure jwt authentication
            //------------------------------
            // Notre cl?? secr??te pour les jetons sur le back-end
            var key = Encoding.ASCII.GetBytes("my-super-secret-key");
            // On pr??cise qu'on veut travaille avec JWT tant pour l'authentification 
            // que pour la v??rification de l'authentification
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    // On exige des requ??tes s??curis??es avec HTTPS
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    // On pr??cise comment un jeton re??u doit ??tre valid??
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        // On v??rifie qu'il a bien ??t?? sign?? avec la cl?? d??finie ci-dessous
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        // On ne v??rifie pas l'identit?? de l'??metteur du jeton
                        ValidateIssuer = false,
                        // On ne v??rifie pas non plus l'identit?? du destinataire du jeton
                        ValidateAudience = false,
                        // Par contre, on v??rifie la validit?? temporelle du jeton
                        ValidateLifetime = true,
                        // On pr??cise qu'on n'applique aucune tol??rance de validit?? temporelle
                        ClockSkew = TimeSpan.Zero  //the default for this setting is 5 minutes
                    };
                    // On peut d??finir des ??v??nements li??s ?? l'utilisation des jetons
                    x.Events = new JwtBearerEvents
                    {
                        // Si l'authentification du jeton est rejet??e ...
                        OnAuthenticationFailed = context =>
                                {
                                    // ... parce que le jeton est expir?? ...
                                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                    {
                                        // ... on ajoute un header ?? destination du front-end indiquant cette expiration
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
            app.UseCors("Policy1");
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseDeveloperExceptionPage();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
