namespace ProfessorLayton.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Enigma 
{
    public int Id{get;set;}
    [StringLength(50, MinimumLength = 3)]
    public string Name{get;set;}=null!;
    [Display(Name="Contenu")]
    [StringLength(5000)]
    public string Content{get;set;}=null!;
    public string? UrlImage{get;set;}
    [NotMapped]
    public IFormFile? ImageFile{get;set;}
    public int GameId{get;set;}
    public Game Game{get;set;}=null!;
    public Music? Music{get;set;}
    public Solution? Solution{get;set;}
    public List<Hint> Hints{get;set;}=new();

    //Default constructor
    public Enigma(){}

    //Copy constructor 
    public Enigma(EnigmaDTO dto)
    {
        Id=dto.Id;
        Name=dto.Name;
        Content=dto.Content;
        UrlImage=dto.UrlImage;
        GameId=dto.GameId;
        ImageFile=dto.ImageFile;
    }


}