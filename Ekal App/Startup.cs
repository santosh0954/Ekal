using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ekal_App.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.JSInterop;
using Blazored.Toast;

namespace Ekal_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            //services.AddSingleton<WeatherForecastService>();

            services.AddSingleton<BankService>();
            services.AddSingleton<CustomerService>();
            services.AddSingleton<DistrictService>();
            services.AddSingleton<EkaiService>();
            services.AddSingleton<EkaiTypeService>();
            services.AddSingleton<ItemProviderService>();
            services.AddSingleton<ItemsService>();
            services.AddSingleton<ItemStockService>();
            services.AddSingleton<ItemFormulaDetailsService>();
            services.AddSingleton<ItemFormulaService>();
            services.AddSingleton<RegionService>();
            services.AddSingleton<SectorService>();
            services.AddSingleton<StateService>();
            services.AddSingleton<TaskService>();
            services.AddSingleton<UnitService>();
            services.AddSingleton<VolunteerBankDetailsService>();
            services.AddSingleton<VolunteerService>();
            services.AddSingleton<VolunteerTypeService>();

            services.AddBlazoredToast();

            //services.AddSingleton<JSRuntime>();
                        
            services.AddBlazorise(option =>
            {
                option.ChangeTextOnKeyPress = true;
            }).AddBootstrapProviders().AddFontAwesomeIcons();

            services.AddServerSideBlazor().AddCircuitOptions(o =>
            {
                o.DetailedErrors = true;
            });


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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.ApplicationServices
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
