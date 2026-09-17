using Microsoft.EntityFrameworkCore;
using PetmealSystem.Data;
using PetmealSystem.Dtos;
using PetmealSystem.Services;

namespace PetmealSystem.Endpoints;

public static class PetEndpoints
{
    public static void MapPetEndpoints(WebApplication app)
    {
        // 新增毛孩
        app.MapPost("/api/pets", async (CreatePetDto dto) =>
        {
            try
            {
                var petService = new PetService();

                var pet = await petService.CreatePetAsync(dto);

                return Results.Ok(pet);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new
                {
                    message = ex.Message
                });
            }
        });

        // 查全部毛孩
        app.MapGet("/api/pets", async () =>
        {
            await using var context = AppDbContextFactory.Create();

            var pets = await context.Pets
                .Include(p => p.Breed)
                .OrderBy(p => p.Id)
                .ToListAsync();

            return Results.Ok(pets);
        });

        // 查單一毛孩
        app.MapGet("/api/pets/{id:int}", async (int id) =>
        {
            await using var context = AppDbContextFactory.Create();

            var pet = await context.Pets
                .Include(p => p.Breed)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pet == null)
            {
                return Results.NotFound(new
                {
                    message = "找不到此毛孩"
                });
            }

            return Results.Ok(pet);
        });

        // 修改毛孩
        app.MapPatch("/api/pets/{id:int}", async (
            int id,
            UpdatePetDto dto) =>
        {
            try
            {
                var petService = new PetService();

                var pet = await petService.UpdatePetAsync(id, dto);

                if (pet == null)
                {
                    return Results.NotFound(new
                    {
                        message = "找不到此毛孩"
                    });
                }

                return Results.Ok(pet);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new
                {
                    message = ex.Message
                });
            }
        });

        // 刪除毛孩
        app.MapDelete("/api/pets/{id:int}", async (int id) =>
        {
            var petService = new PetService();

            var deleted = await petService.DeletePetAsync(id);

            if (!deleted)
            {
                return Results.NotFound(new
                {
                    message = "找不到此毛孩"
                });
            }

            return Results.Ok(new
            {
                message = "毛孩資料已刪除"
            });
        });
    }
}