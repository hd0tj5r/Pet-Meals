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
        using var context = AppDbContextFactory.Create();
        throw new NotImplementedException();
    }
}