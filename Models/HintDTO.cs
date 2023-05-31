namespace ProfessorLayton.Models;

public class HintDTO
{
    public int Id{get;set;}
    public string Content{get;set;}=null!;
    public HintRange HintRange{get;set;}
}