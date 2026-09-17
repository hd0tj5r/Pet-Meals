using System.ComponentModel.DataAnnotations;
using PetmealSystem.Models;

namespace PetmealSystem.Dtos;

public class UpdatePetDto
{
    [Range(0.1, 200, ErrorMessage = "體重必須介於0.1～200公斤")]
    public decimal? WeightKg { get; set; }

    [Range(1, 10, ErrorMessage = "體態分數必須介於1～10")]
    public int? BodyConditionScore { get; set; }

    public ActivityLevelType? ActivityLevel { get; set; }//Enum.cs
}