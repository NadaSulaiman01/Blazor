using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GameStore.Frontend.Converters;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required(ErrorMessage ="The Genre field is required.")]
    [JsonConverter(typeof(Converters.StringConverter))]
    public string? GenreId { get; set; }
    [Required]
    [Range(0,200)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }

}
