using System.ComponentModel.DataAnnotations;


// =========================
// Enum
// =========================

public enum SpeciesType // 毛孩種類
{
    None = 0,
    Dog = 1,
    Cat = 2
}

public enum SexType // 毛孩生理性別
{
    None = 0,
    Male = 1,
    Female = 2
}

public enum ActivityLevelType // 毛孩活動量
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3
}


// =========================
// 品種資料
// =========================

public class Breed
{
    public int Id { get; set; }

    [Required(ErrorMessage = "請填入品種名稱")]
    [StringLength(50,ErrorMessage = "品種名稱長度不可超過50個字元")]
    public string Name { get; set; } ="";

    public SpeciesType Species { get; set; }
}


// =========================
// 新增毛孩 API 收到的資料
// =========================

public class CreatePetDto
{
    [Required(ErrorMessage = "毛孩名稱必填")]
    [StringLength(50,ErrorMessage = "毛孩名稱不可超過50個字元")]
    public string Name { get; set; } ="";


    [Required(ErrorMessage = "毛孩種類必填")]
    public SpeciesType Species { get; set; }


    [Required(ErrorMessage = "性別必填")]
    public SexType Sex { get; set; }


    // nullable 是為了真正判斷「有沒有填」
    [Required(ErrorMessage = "年齡必填")]
    [Range(0,40,ErrorMessage = "年齡必須介於0～40歲")]
    public int? Age { get; set; }


    [Required(ErrorMessage = "品種必填")]
    [Range(1,int.MaxValue,ErrorMessage = "請選擇有效品種")]
    public int BreedId { get; set; }


    // 是否混種
    public bool IsMixedBreed { get; set; }


    [Required(ErrorMessage = "體重必填")]
    [Range(0.1,150,ErrorMessage = "體重必須介於0.1～150公斤")]
    public decimal? WeightKg { get; set; }//decimal精準計算


    // 是否已結紮
    public bool IsNeutered { get; set; }


    [Range(1,9,ErrorMessage = "體態分數必須介於1～9")]
    public int? BodyConditionScore { get; set; }


    public ActivityLevelType ActivityLevel { get; set; }
}


// =========================
// Pet Entity
// =========================

public class PetInit
{
    public int Id { get; set; }


    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = "";

    public SpeciesType Species { get; set; }

    // 建立毛孩資料時的年齡
    public int AgeAtRegistration { get; set; }

    // 這個年齡是哪一天登記的
    public DateTime AgeRecordedAt { get; set; }


    // Foreign Key
    public int BreedId { get; set; }


    // Navigation Property
    public Breed Breed { get; set; } = null!;


    // 是否混種
    public bool IsMixedBreed { get; set; }


    public decimal WeightKg { get; set; }


    public SexType Sex { get; set; }


    // 是否結紮
    public bool IsNeutered { get; set; }


    // 體態分數 1~9
    public int? BodyConditionScore { get; set; }


    public ActivityLevelType ActivityLevel { get; set; }
}