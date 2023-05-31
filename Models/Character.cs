namespace ProfessorLayton.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Character
{
    public int Id{get;set;}
     [StringLength(30, MinimumLength = 3)]
    public string FirstName{get;set;}=null!;
     [StringLength(30)]
    public string? LastName{get;set;}
    public bool IsBadGuy{get;set;}

    public string? Description{get;set;}

    public string? UrlImage1{get;set;}
    public string? UrlImage2{get;set;}

    public string? UrlImage3{get;set;}

    [NotMapped]
    public IFormFile? ImageFile1{get;set;}
    [NotMapped]
    public IFormFile? ImageFile2{get;set;}
    [NotMapped]
    public IFormFile? ImageFile3{get;set;}
    public string getUrl(int i)
   {
    if(i==1)
      return UrlImage1;
    else if(i==2)
      return UrlImage2;
    else
      return UrlImage3;    
   }

    public List<Game> Games{get;set;}=new();
}