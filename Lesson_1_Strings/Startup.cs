using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualLessons.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lesson_1_Strings
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Конвейер обработки зависимостей
        public void ConfigureServices(IServiceCollection services)
        {
            // Добавляем функционал Razor Pages и компиляцию кода представления в процессе выполнения
            services.AddRazorPages().AddRazorRuntimeCompilation();
            // Добавляем в конвейер обработку нашего репозитория
            // AddSingleton - При обращении к этому методу, создаётся экземпляр класса и отдаётся на протяжении всей сессии
            // <IStringRepository, MocStringRepository> Связываем интерфейс с классом реализации его
            services.AddSingleton<IStringRepository, MocStringRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
