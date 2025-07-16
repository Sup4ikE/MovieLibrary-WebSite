using System.ComponentModel.DataAnnotations;

namespace ONLSHOP_ASP.NET.Entities;

public class Genre
{
    public int Id {get;set;}
    public required string Name {get;set;}
}