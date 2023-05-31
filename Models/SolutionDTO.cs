namespace ProfessorLayton.Models;

// Data Transfer Object class, used to bypass navigation properties validation during API calls

public class SolutionDTO
{
    public int Id{get;set;}
    public string Content{get;set;}=null!;
    public string urlImg{get;set;}=null!;

    
}