namespace Interviewsystem.Application.Responses;
public class ObjetRetour       
{
    public bool Etat { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public object? Contenu { get; set; } = null;   
    public List<string> ValidationErrors { get; set; } = new(); 
}
