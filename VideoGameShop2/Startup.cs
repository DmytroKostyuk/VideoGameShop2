using BLL.DTO;
using BLL.Interfaces.IEFServices;
using BLL.Services.EF_Services;
using BLL.Validators;
using DAL.DbContexts;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Interfaces.EFInterfaces.IEFRepositories;
using DAL.Repositories.EFRepositories;
using DAL.Seeding;
using DAL.UnitOfWork;
using DocumentFormat.OpenXml.EMMA;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace VideoGameShop2
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
            services.AddDbContext<MyDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("VideoGameShop2"));
            });

            services.Configure<RazorViewEngineOptions>(o =>
            {
                // {2} is area, {1} is controller,{0} is the action
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("UI/Pages/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddServerSideBlazor();
            services.AddControllersWithViews();

            services.AddIdentity<User, MyRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<MyDbContext>();

            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Developer, DeveloperDTO>();
                cfg.CreateMap<Game, GameDTO>();
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<Publisher, PublisherDTO>();
                cfg.CreateMap<UserBought, UserBoughtDTO>();

                cfg.CreateMap<DeveloperDTO, Developer>();
                cfg.CreateMap<GameDTO, Game>();
                cfg.CreateMap<GenreDTO, Genre>();
                cfg.CreateMap<PublisherDTO, Publisher>();
                cfg.CreateMap<UserBoughtDTO, UserBought>();
                cfg.CreateMap<RoleDTO, MyRole>()
                   .ReverseMap();
            }, typeof(Startup));

            services.AddTransient<IEFDeveloperRepository, EFDeveloperRepository>();
            services.AddTransient<IEFGameRepository, EFGameRepository>();
            services.AddTransient<IEFGenreRepository, EFGenreRepository>();
            services.AddTransient<IEFPublisherRepository, EFPublisherRepository>();
            services.AddTransient<IEFUserBoughtRepository, EFUserBoughtRepository>();

            services.AddTransient<IEFUnitOfWork, EFUnitOfWork>();

            services.AddTransient<IEFDeveloperService, EFDeveloperService>();
            services.AddTransient<IEFGameService, EFGameService>();
            services.AddTransient<IEFGenreService, EFGenreService>();
            services.AddTransient<IEFPublisherService, EFPublisherService>();
            services.AddTransient<IEFUserBoughtService, EFUserBoughtService>();
            services.AddTransient<IEFUserService, EFUserService>();
            services.AddTransient<IEFRoleService, EFRoleService>();

            services.AddTransient<RoleInitializer>();

            services.AddValidatorsFromAssemblyContaining<DeveloperValidator>();
            services.AddValidatorsFromAssemblyContaining<GameValidator>();
            services.AddValidatorsFromAssemblyContaining<GenreValidator>();
            services.AddValidatorsFromAssemblyContaining<PublisherValidator>();
            services.AddValidatorsFromAssemblyContaining<RoleValidator>();

            services.AddMvc(c =>
            {
                c.EnableEndpointRouting = false;
            }).AddFluentValidation();

            /*
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,

                        ValidIssuer = Configuration["JwtIssuer"],

                        ValidateAudience = true,

                        ValidAudience = Configuration["JwtAudience"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"])),

                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero
                    };
                }
                );*/

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Videogameshop",
                    Version = "v1"
                });
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();//

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });
        }
    }
}