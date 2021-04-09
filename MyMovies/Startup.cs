using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMovies.Repositories;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MyMovies
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
            services.AddDbContext<MoviesDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MyDBConnection")));


            //var cookieExprrTime = Configuration.GetValue<int>("CookieExpirationPeriod");
            //var topRecipesCount = Configuration["SidebarConfig:TopRecipesCount"];

            // We are taking cookie experation value from appsettings.json
            var cookieExprTime = Configuration.GetValue<int>("CookieExpirationPeriod");

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=> {
                options.ExpireTimeSpan = TimeSpan.FromDays(cookieExprTime);
                options.LoginPath = "/Auth/SignIn"; 
                options.LogoutPath = "/Auth/SignOut";
                options.AccessDeniedPath= "/Auth/AccessDenied";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy =>
                {
                    policy.RequireClaim("IsAdmin", "True");
                });
            });

            services.AddControllersWithViews();

            // Register Services
            services.AddTransient<IMoviesService, MoviesService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUsersService, UserService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IRatingsService, RatingsService>();
            services.AddTransient<ILikesService, LikesService>();

            // Register Repositories
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IUsersRepository, UserRepository>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<IRatingsRepository, RatingsRepository>();
            services.AddTransient<ILikeRepository, LikesRepository>();

            // Register the Interfaces for Services & Repository
            //services.AddTransient<IMoviesRepository, MoviesFileRepository>();
            //services.AddTransient<IMoviesRepository, MoviesSqlRepository>();

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
                app.UseExceptionHandler("/Info/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Add this, it is required.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
