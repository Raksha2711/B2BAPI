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
using Data.Db;
using B2b.BusinessService;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;

namespace B2b.Admin
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
            services.AddControllersWithViews();
            services.AddInfrastructure(Configuration);
            services.ConfigureBusinessService();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/account/google-login"; // Must be lowercase
                })
            .AddGoogle(options =>
             {
                 var GoogleKeys = Configuration.GetSection("Google");

                 options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                 options.ClientId = GoogleKeys["ClientId"];
                 options.ClientSecret = GoogleKeys["ClientSecret"];
                 options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                 options.ClaimActions.Clear();
                 options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                 options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                 options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                 options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                 options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                 options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                 options.ClaimActions.MapJsonKey(ClaimTypes.MobilePhone, "mobile");
                 options.CallbackPath = new PathString("/signin-google/");
                 options.Events.OnRemoteFailure = ctx =>
                 {
                     ctx.Response.Redirect("login/externallogincallback/?remoteError=" + UrlEncoder.Default.Encode(ctx.Failure.Message));
                     ctx.HandleResponse();
                     return Task.FromResult(0);
                 };
             });
            //services.AddTransient<IBrandService, BrandService>();
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
            app.UseAuthentication();
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
