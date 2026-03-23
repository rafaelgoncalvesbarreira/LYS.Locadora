using System.ComponentModel.DataAnnotations;

namespace LYS.Locadora.Application.Model;

public class Movie
{
    public int Id { get; set; }
    
    [MaxLength(256)]
    public string Title { get; set; } = "";
    
    public DateOnly ReleaseDate { get; set; }
    
    [MaxLength(64)]
    public string Genre { get; set; } = "";
    public float Rating { get; set; }
    
    [MaxLength(512)]
    public string ImageUrl { get; set; } = ""; 
}