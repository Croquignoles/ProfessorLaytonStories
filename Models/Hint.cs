namespace ProfessorLayton.Models;
using System.ComponentModel.DataAnnotations;
public enum HintRange: int{
    [Display(Name ="Premier pas")]
    firstStep=0,
     [Display(Name ="Indice avancé")]
    advancedHint=1,
     [Display(Name ="Anti énigme")]
    obviousSolution=2
}
public class Hint
{
    public int Id{get;set;}
    [Display(Name ="Contenu")]
    public string Content{get;set;}=null!;
    public HintRange HintRange{get;set;}
    public int EnigmaId{get;set;}
    public Enigma Enigma{get;set;}=null!;

    public Hint(){}

    public Hint(HintDTO hintDTO)
    {
        Id=hintDTO.Id;
        Content=hintDTO.Content;
        HintRange=hintDTO.HintRange;
    }

    
}
