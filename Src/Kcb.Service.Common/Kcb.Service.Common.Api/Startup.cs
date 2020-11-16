using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kcb.Service.Common.RepositoryPersistence.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Kcb.Service.Common.RepositoryPersistence.Infrastructure;
using Kcb.Service.Common.RepositoryPersistence.Repositories;
using Kcb.Service.Common.RepositoryServiceMapper.Helper;
using Kcb.Service.Common.RepositoryService.Infrastructure;
using Kcb.Service.Common.RepositoryService.Repositories;
using Kcb.Service.Common.RepositoryServiceMapper.Infrastructure;
using Kcb.Service.Common.RepositoryServiceMapper.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

namespace Kcb.Service.Common.Api
{
    /// <summary>
    /// Init Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Instance Startup constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets Configuration 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices method
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            //Register mapped repositories
            services.AddTransient<IMappedUserRepository, MappedUserRepository>();

            //Register repositories
            services.AddTransient<IUserRepository, UserRepository>();

            //Register generic repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IAuthenticateRepository<>), typeof(AuthenticateRepository<>));

            var mappingConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddEntityFrameworkSqlServer();

            services.AddDbContext<KcbApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllParametersInCamelCase();

                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Kcb.Service.Common.Api API v1.0", Version = "v1" });

                swagger.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Kcb.Service.Common.Api.xml"));

                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

        }

        /// <summary>
        /// Configure method
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kcb.Service.Common.Api v1.0");

                c.DocumentTitle = "Kcb.Service.Common.Api v1.0";

                c.DocExpansion(DocExpansion.None);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x.WithOrigins(Configuration["Client:Url"])
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed((host) => true));

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
