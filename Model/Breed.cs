
using System.ComponentModel.DataAnnotations;
// =========================
// 品種資料
// =========================
namespace PetmealSystem.Models;
public class Breed
{
    public int Id { get; set; }

    [Required(ErrorMessage = "請填入品種名稱")]
    [StringLength(50,ErrorMessage = "品種名稱長度不可超過50個字元")]
    public string Name { get; set; } ="";

    public SpeciesType Species { get; set; }
}