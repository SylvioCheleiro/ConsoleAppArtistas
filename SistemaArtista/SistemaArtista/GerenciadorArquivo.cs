using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemaArtista;

public class GerenciadorArquivo 
{

    public List<Artista> Artistas = new List<Artista>();
    public List<Musica> Musicas = new List<Musica>();

    public GerenciadorArquivo()
        {
            this.IniciarListas();
        }

    public void IniciarListas()
    {
        if (File.Exists("artistas.json") == false)
            File.Create("artistas.json").Close();

        if (File.Exists("musicas.json") == false)
            File.Create("musicas.json").Close();

        using (StreamReader reader = new StreamReader(File.OpenRead("artistas.json")))
        {
            try
            {
                string content = reader.ReadToEnd();
                this.Artistas = JsonSerializer.Deserialize<List<Artista>>(content);
                reader.Close();
            }
            catch { }
        }

        using (StreamReader reader = new StreamReader(File.OpenRead("musicas.json")))
        {
            try
            {
                string content = reader.ReadToEnd();
                this.Musicas = JsonSerializer.Deserialize<List<Musica>>(content);
                reader.Close();
            }
            catch { }
        }
    }

    public void SalvarListas()
    {
        if (File.Exists("artistas.json"))
            File.Delete("artistas.json");

        using (StreamWriter writer = new StreamWriter(File.Open("artistas.json", FileMode.OpenOrCreate)))
        {
            string json = JsonSerializer.Serialize<List<Artista>>(Artistas);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }

        if (File.Exists("musicas.json"))
            File.Delete("musicas.json");

        using (StreamWriter writer = new StreamWriter(File.Open("musicas.json", FileMode.OpenOrCreate)))
        {
            string json = JsonSerializer.Serialize<List<Musica>>(Musicas);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }
    }
   
    public void AdcionarArtista(Artista artista)
    {
        this.Artistas.Add(artista);
    }
    
    public void ExcluirArtista(Artista artista)
    {
        this.Artistas.Remove(artista);
    }

    public void EditarArtistas(Artista artistaAntigo, Artista artistaNovo)
    {
          this.Artistas.Remove(artistaAntigo);
          this.Artistas.Add(artistaNovo);
          
          Console.WriteLine("Artista editado com sucesso.");
    }



    public void AdcionarMusica(Musica musica)
    {
        this.Musicas.Add(musica);
    }
    public void ExcluirMusica(Musica musica)
    {
        this.Musicas.Remove(musica);
    }






}