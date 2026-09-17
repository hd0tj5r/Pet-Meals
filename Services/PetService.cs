using Microsoft.EntityFrameworkCore;
using PetmealSystem.Data;
using PetmealSystem.Dtos;
using PetmealSystem.Models;

namespace PetmealSystem.Services;

public class PetService
{
    // 建立一個新的寵物資料
    // Task<Pet>執行完後，最後會回傳一隻建立好的「寵物（Pet）」資料
    public async Task<Pet> CreatePetAsync(CreatePetDto dto)
    {
        await using var context = AppDbContextFactory.Create();
        //先確認BreedId是否存在
        var breed = await context.Breeds.FirstOrDefaultAsync(b => b.Id == dto.BreedId);
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("毛孩名稱必填");
        }
        if (dto.Age==null)
        {
            throw new ArgumentException("年齡必填");
        }
        // 體重必填
        if (dto.WeightKg == null)
        {
            throw new ArgumentException("體重必填");
        }

        // 毛孩種類只能是 Dog 或 Cat
        if (dto.Species == SpeciesType.None)
        {
            throw new ArgumentException("請選擇毛孩種類");
        }

        // 性別必填
        if (dto.Sex == SexType.None)
        {
            throw new ArgumentException("請選擇性別");
        }

        // 活動量必填
        if (dto.ActivityLevel == ActivityLevelType.None)
        {
            throw new ArgumentException("請選擇活動量");
        }
        if (breed == null)
        {
            throw new ArgumentException("找不到此品種");
        }
        if(breed.Species != dto.Species)
        {
            throw new ArgumentException("品種與物種不符");
        }

        var pet = new Pet
        {
            Name = dto.Name.Trim(),
            Species = dto.Species,
            Sex=dto.Sex,

            //飼主輸入建立當下的年齡
            AgeAtRegistration=dto.Age.Value,
            AgeRecordedAt = DateTime.Today,
            BreedId = dto.BreedId,
            IsMixedBreed = dto.IsMixedBreed,//混種

            WeightKg = dto.WeightKg.Value,

            IsNeutered = dto.IsNeutered,//結紮
            BodyConditionScore = dto.BodyConditionScore,
            ActivityLevel = dto.ActivityLevel
        };

        context.Pets.Add(pet);//新增到Pet並寫入資料庫

        await context.SaveChangesAsync();

        return pet;
    }


    public async Task<Pet?> UpdatePetAsync(int id, UpdatePetDto dto)
    {
        await using var context = AppDbContextFactory.Create();

        var pet = await context.Pets
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pet == null)
        {
            return null;
        }

        if (dto.WeightKg.HasValue)
        {
            pet.WeightKg = dto.WeightKg.Value;
        }

        if (dto.BodyConditionScore.HasValue)
        {
            pet.BodyConditionScore = dto.BodyConditionScore.Value;
        }

        if (dto.ActivityLevel.HasValue)
        {
            if (dto.ActivityLevel.Value == ActivityLevelType.None)
            {
                throw new ArgumentException("請選擇有效的活動量");
            }

            pet.ActivityLevel = dto.ActivityLevel.Value;
        }

        await context.SaveChangesAsync();

        return pet;
    }

    public async Task<bool> DeletePetAsync(int id)
    {
        await using var context = AppDbContextFactory.Create();

        var pet = await context.Pets
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pet == null)
        {
            return false;
        }

        context.Pets.Remove(pet);

        await context.SaveChangesAsync();

        return true;
    }


    public async Task<List<Pet>> GetAllPetsAsync()
    {
        await using var context = AppDbContextFactory.Create();

        return await context.Pets
            .Include(p => p.Breed)
            .OrderBy(p => p.Id)
            .ToListAsync();
    }


    public async Task<Pet?> GetPetByIdAsync(int id)
    {
        await using var context = AppDbContextFactory.Create();

        return await context.Pets
            .Include(p => p.Breed)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}