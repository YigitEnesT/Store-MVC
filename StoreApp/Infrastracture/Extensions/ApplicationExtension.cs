using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastracture.Extentions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }
        public static void ConfigureRouting(this IServiceCollection services )
        {
            services.AddRouting(options => 
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
        }
    }
}