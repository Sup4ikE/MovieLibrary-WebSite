using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ONLSHOP_ASP.NET.Entities;

public class Movie
{
    public int Id { get; set; }
    
    [Required]
    public required string Name { get; set; }
    
    [Range(1, 100)]
    [Required]
    public int Price {get;set;}
    
    // Navigation 1:1
    [ValidateNever]
    public Genre? Genre {get;set;}
    
    // Foreign key
    public int GenreId {get;set;}
    
    public DateOnly ReleaseDate {get;set;}
}