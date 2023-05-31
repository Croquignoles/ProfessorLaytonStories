namespace ProfessorLayton.Models;
using System.ComponentModel.DataAnnotations;
public class Music
{
    public int Id{get;set;}

    [StringLength(100, MinimumLength = 3)]
    public string Name {get;set;}=null!;
    public string URL {get;set;}=null!;
    public List<Game> Games{get;set;}=new();

    public string getVideoId()
    {
        string vId="";
        int index=URL.IndexOf("=");
        vId=URL.Substring(index+1);
        return vId;
    }

    //Empty constructor 
    public Music(){}
    //Copy constructor
    public Music(Music dto){
        Id=dto.Id;
        Name=dto.Name;
        URL=dto.URL; 
    }    
}