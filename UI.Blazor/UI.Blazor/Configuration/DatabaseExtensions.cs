using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UI.Blazor.Configuration;

public static class DatabaseExtensions
{
    public static async Task ApplyMigrationAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await using var context = scope.ServiceProvider.GetRequiredService<QotdContext>();

        try
        {
            //await context.Database.EnsureDeletedAsync();
            //await context.Database.EnsureCreatedAsync();

            await context.Database.MigrateAsync();

            app.Logger.LogInformation("Migration ausgeführt");
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "Ein Fehler ist aufgetreten");
            throw;
        }
    }
}