namespace SistemaArtista;

public class Artista
{
public string Nome {get; set;}
public string Pais {get; set;}
public string Genero{get; set;}
public List<Musica> MusicasArtista {get; set;}

    public void Enturmar(Musica musica) 
    {
        if (this.MusicasArtista == null) {
            this.MusicasArtista = new List<Musica>(); 
        }
        
        this.MusicasArtista.Add(musica);
    }













}//fim class