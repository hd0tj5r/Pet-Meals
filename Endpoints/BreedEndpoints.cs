using Microsoft.EntityFrameworkCore;
using PetmealSystem.Data;

namespace PetmealSystem.Endpoints;

public static class BreedEndpoints
{
    public static void MapBreedEndpoints(WebApplication app)
    {
        // 查全部品種
        app.MapGet("/api/breeds", async () =>
        {
            await using var db = AppDbContextFactory.Create();

            var breeds = await db.Breeds
                .OrderBy(b => b.Species)
                .ThenBy(b => b.NameZhTw)
                .ToListAsync();

            return Results.Ok(breeds);
        });

        // 模糊搜尋品種
        app.MapGet("/api/breeds/search", async (string keyword) =>
        {
            await using var db = AppDbContextFactory.Create();

            var breeds = await db.Breeds
                .Where(b => b.NameZhTw.Contains(keyword))
                .OrderBy(b => b.NameZhTw)
                .ToListAsync();

            return Results.Ok(breeds);
        });
    }
}