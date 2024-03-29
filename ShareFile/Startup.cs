using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShareFile.BL.Logic.Classes;
using ShareFile.BL.Logic.Interfaces;
using ShareFile.DAL;
using ShareFile.DAL.Repository.Classes;
using ShareFile.DAL.Repository.Interfaces;
using ShareFile.Helpers.Classes;
using ShareFile.Helpers.Interfaces;
using ShareFile.Middlewares;
using System.IO;


namespace ShareFile
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

            string connectionString = "Server=localhost;Database=ShareFileDb;Trusted_Connection=True;MultipleActiveResultSets=true";

            services.AddDbContext<ShareFileDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();

            services.AddTransient<IFileLogic, FileLogic>();
            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<ITokenLogic, TokenLogic>();


            services.AddTransient<IShareControllerHelper, ShareControllerHelper>();
            services.AddTransient<IAccountControllerHelper, AccountControllerHelper>();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            string path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
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

            app.UseAuthorization();
            app.UseMiddleware<TokenMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Share}/{action=Index}/{id?}");
            });
        }
    }
}
