
using IdentityServer4IntegrationAspNetCoreWebAPI.Configurations;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer4IntegrationAspNetCoreWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddIdentityServer()
                .AddInMemoryClients(IdentityConfiguration.Clients)
                .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
                .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
                .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
                .AddTestUsers(IdentityConfiguration.TestUsers)
                .AddDeveloperSigningCredential();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options => {
                options.Authority = "https://localhost:44350/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
