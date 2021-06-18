using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classified.Common.AppSettings;
using Classified.Domain.Entities;
using Classified.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;

namespace Classified
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
            services.AddOptions();
            services.Configure<AppSettings>(Configuration);
            services.AddDbContext<ClassifiedDbContect>();
            services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<ClassifiedDbContect>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters 
                {
                    ValidateAudience=false,
                    ValidateIssuer=false,
                    ValidateIssuerSigningKey=true,
                    ValidateLifetime=true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes( Configuration["JWT:SigningKey"]))
                };
            });
            services.AddAuthorization( policy => {
                policy.AddPolicy("IsAdmin", policyBuilder =>
                {
                    policyBuilder.RequireClaim("Role", "Admin");
                });
            });



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Classified", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Classified v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
