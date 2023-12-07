namespace SistemaArtista;

public class Musica
{
    public String Nome { get; set; }
    public String Genero { get; set; }
    public TimeOnly Duracao {get;set;}      
    public List<Musica> MusicasGeral {get; set;}
    
    


}//fim class