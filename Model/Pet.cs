using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// =========================
// 寵物基本資料
// =========================
namespace PetmealSystem.Models;
public class Pet
{
    public int Id { get; set; }


    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = "";

    public SpeciesType Species { get; set; }
    [Range(0, 40)]
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

    [Range(0.1, 150)]
    public decimal WeightKg { get; set; }


    public SexType Sex { get; set; }


    // 是否結紮
    public bool IsNeutered { get; set; }


    // 體態分數 1~9
    public int? BodyConditionScore { get; set; }


    public ActivityLevelType ActivityLevel { get; set; }

    [NotMapped]
    public int CurrentAge
    {
        get
        {
            // AgeRecordedAt 沒有被正確設定
            if (AgeRecordedAt == default)
            {
                return AgeAtRegistration;
            }

            var today = DateTime.Today;

            int yearsPassed = today.Year - AgeRecordedAt.Year;

            if (today < AgeRecordedAt.AddYears(yearsPassed))
            {
                yearsPassed--;
            }

            return AgeAtRegistration + yearsPassed;
        }
    }
}