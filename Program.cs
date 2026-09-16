using Microsoft.EntityFrameworkCore;
using PetmealSystem.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
// 建立一個網址路徑為 /api/breeds 的 GET 請求 API
app.MapGet("/api/breeds",async (AppDbContext db) => 
{
    return await db.Breeds
        .OrderBy(b => b.Species)
        .ThenBy(b => b.NameZhTw)
        .ToListAsync();
        // SELECT * 
        // FROM Breeds 
        // ORDER BY Species, NameZhTw;

});
//關鍵字搜尋 API，網址路徑為 /api/breeds/search?keyword=xxx
app.MapGet("/api/breeds/search", async (
    string keyword,AppDbContext db) =>
{
    return await db.Breeds
        .Where(b => b.NameZhTw.Contains(keyword))
        .OrderBy(b => b.NameZhTw)
        .ToListAsync();
        // SELECT * 
        // FROM Breeds 
        // WHERE NameZhTw LIKE '%keyword%' 
        // ORDER BY NameZhTw;
});
app.Run();