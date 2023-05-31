namespace ProfessorLayton.Models;
using System.ComponentModel.DataAnnotations;
public class Solution
{
    public int Id{get;set;}
    [Display(Name ="Contenu")]
    [StringLength(5000, MinimumLength = 20)]
    public string Content{get;set;}=null!;
    [StringLength(200, MinimumLength = 3)]
    public string? urlImg{get;set;}
    public int EnigmaId{get;set;}
    public Enigma Enigma{get;set;}=null!;
    //Default constructor
    public Solution(){}

    //Copy constructor 
    public Solution(SolutionDTO dto)
    {
        Id=dto.Id;
        Content=dto.Content;
        urlImg=dto.urlImg;
    }
}