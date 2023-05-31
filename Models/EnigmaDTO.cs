namespace ProfessorLayton.Models;

// Data Transfer Object class, used to bypass navigation properties validation during API calls

public class EnigmaDTO
{
    public int Id{get;set;}
    public string Name{get;set;}=null!;
    public string Content{get;set;}=null!;
    public string? UrlImage{get;set;}
    public int GameId{get;set;}
    public IFormFile? ImageFile{get;set;}
}