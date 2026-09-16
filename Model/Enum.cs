// =========================
// 集中管理系統裡固定的選項
// =========================
namespace PetmealSystem.Models;
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