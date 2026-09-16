// 建立一個新的資料庫連線操作物件
using Microsoft.EntityFrameworkCore;
namespace PetmealSystem.Data;
public static class AppDbContextFactory
{
    public static AppDbContext Create()
    {
        var options= new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlite("Data Source=petmeal.db")
        .Options;

        return new AppDbContext(options);
    }       
}