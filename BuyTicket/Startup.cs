using BuyTicket.Data;
using BuyTicket.Data.Repositories;
using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket
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
            services.AddDbContext<BiletDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultSqlConnection")));

            services.AddScoped<IOyuncuRepository, OyuncuRepository>();
            services.AddScoped<ISinemaRepository, SinemaRepository>();
            services.AddScoped<IYonetmenRepository, YonetmenRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<ISiparisRepository, SiparisRepository>();

            //Alýþveriþ sepeti için konfigürasonlar 
            //singleton servisler sadece ilk requestte oluþturulurlar.
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();   
            services.AddScoped(sr => SepetRepository.AlisVerisSepetiniGetir(sr));



            services.AddIdentity<Kullanici, IdentityRole>(
                o => {

                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 3;
                }
                ).AddEntityFrameworkStores<BiletDbContext>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication();

            //Coklu dil destegi icin
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources";});
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(
                opt =>
                {
                    var cultures = new List<CultureInfo>
                    {
                        new CultureInfo("tr"),
                        new CultureInfo("en")
                    };
                    opt.DefaultRequestCulture = new RequestCulture("tr");
                    opt.SupportedCultures = cultures;
                    opt.SupportedUICultures = cultures;
                });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();

            app.UseAuthorization();

            //coklu dil destegi icin
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

           BiletDbInitializer.EklenecekVeriler(app);
           BiletDbInitializer.KullaniciVeRolEkle(app).Wait();
        }
    }
}
