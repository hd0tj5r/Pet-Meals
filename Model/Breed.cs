using System.ComponentModel.DataAnnotations;

namespace PetmealSystem.Models;

public class Breed
{
    public int Id { get; set; }

    // 台灣繁體中文正式名稱
    [Required(ErrorMessage = "請填入品種名稱")]
    [StringLength(100, ErrorMessage = "品種名稱不可超過100個字元")]
    public string NameZhTw { get; set; } = "";

    // 英文名稱，供國際資料與 AI 搜尋使用
    [StringLength(100)]
    public string? NameEn { get; set; }

    // 狗 / 貓
    public SpeciesType Species { get; set; }



}