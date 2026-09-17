using Microsoft.EntityFrameworkCore;
using PetmealSystem.Data;
using PetmealSystem.Dtos;
using PetmealSystem.Services;
using PetmealSystem.Endpoints;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
PetEndpoints.MapPetEndpoints(app);//pet api
BreedEndpoints.MapBreedEndpoints(app);//breed api
app.Run();