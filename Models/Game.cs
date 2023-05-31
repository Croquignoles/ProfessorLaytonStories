namespace ProfessorLayton.Models;
using System.ComponentModel.DataAnnotations;
public class Game 
{
    public int Id{get;set;}
    [Display(Name ="Titre")]
    public string Title{get;set;}=null!;
    [Display(Name ="Date de sortie")]
    public DateTime ReleaseDate{get;set;}

    public string? Description{get;set;}
    public string? UrlImage1{get;set;}
    public string? UrlImage2{get;set;}

    public string? UrlImage3{get;set;}

    public string getUrl(int i)
   {
    if(i==1)
      return UrlImage1;
    else if(i==2)
      return UrlImage2;
    else
      return UrlImage3;    
   }

    public List<Character> Characters{get;set;}=new();
    public List<Enigma> Enigmas{get;set;}=new();
    public List<Music> Musics{get;set;}=new();


}