namespace SimpleEmailApp.Models
{
    public class EmailDTO
    {
        public List<string> Para { get; set; } 
        public string Asunto { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;

    }
}
