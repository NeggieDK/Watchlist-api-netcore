using LightInject;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WatchList_api.CQRS.ActiveWatchItems.Queries.GetAllActiveWatchItems;
using WatchList_api.CQRS.Interfaces;

namespace WatchList_api
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
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
              .AddCookie()
              .AddOpenIdConnect(options =>
              {
                  options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                  options.Authority = "http://localhost:8080/auth/realms/WatchList/";
                  options.RequireHttpsMetadata = false;
                  options.ClientId = "WatchList-api";
                  options.ClientSecret = "4d667d5a-4862-4124-b37b-f368b27137de";
                  options.ResponseType = OpenIdConnectResponseType.Code;
                  options.GetClaimsFromUserInfoEndpoint = true;
                  options.Scope.Add("openid");
                  options.Scope.Add("profile");
                  options.SaveTokens = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      NameClaimType = "name",
                      RoleClaimType = "groups",
                      ValidateIssuer = true
                  };
              });
            services.AddTransient<IQuery<GetAllActiveWatchItemsRequest, GetAllActiveWatchItemsResponse>, GetAllActiveWatchItemsQuery>();
        }

        public void ConfigureContainer(IServiceContainer container)
        {
            container.RegisterFrom<CompositionRoot>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}