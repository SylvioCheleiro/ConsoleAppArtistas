using SistemaArtista;
internal class Program
{
    private static GerenciadorArquivo manager;
    
    private static void Main(string[] args)
    {
       
        var stopKey = "0";
        var selectedMenu = "";
        manager = new GerenciadorArquivo(); 

        while (stopKey != selectedMenu)
        {
            Console.WriteLine("1 - Cadastrar Artista");

            Console.WriteLine("2 - Cadastrar Musica");

            Console.WriteLine("3 - Adcionar Artista em Musica");

            Console.WriteLine("4 - Exibir Musicas Criadas");

            Console.WriteLine("5 - Exibir Artistas e suas músicas");

            Console.WriteLine("6 - Editar artistas / Excluir musicas");

            Console.WriteLine("7 - Excluir Artistas");

            Console.WriteLine("0 - Sair");

             selectedMenu = Console.ReadLine();

            ExercutarOpcao(selectedMenu);
        }
       Console.Read();
    }
    private static void ExercutarOpcao(string? selectedMenu)
    {
        switch(selectedMenu)
        {
            case "1":
                Console.WriteLine("Cadastrando Artistas...");
                CadastrarArtista();
                Console.WriteLine("Artista Cadastrado com sucesso.");
                Console.WriteLine();
                break;

            case "2":
                Console.WriteLine("Cadastrando músicas...");
                CadastrarMusica();
                Console.WriteLine("Musicas cadastradas com sucesso.");
                Console.WriteLine();
                break;

            case "3": 
                Console.WriteLine("Adcinando artistas em músicas existentes...");
                EnturmarMusicaEmArtista();
                Console.WriteLine("Artista adcionado na música com sucesso.");
                Console.WriteLine();
                break;

            case "4":
                Console.WriteLine("Exibindo músicas...");
                ExibirMusicasCriadas();
                Console.WriteLine();
                break;

            case "5":
                Console.WriteLine("Exibindo artistas...");
                ExibirMusicasArtista();
                Console.WriteLine();
                break;

            case "6":
                Console.WriteLine("Editando artistas...");
                EditarArtistas();
                Console.WriteLine("Artista editado com sucesso.");
                Console.WriteLine();
                break;

            case "7":
                Console.WriteLine("Excluindo artistas...");
                ExcluirArtista();
                Console.WriteLine("Artista excluido com sucesso.");
                Console.WriteLine();
            break;

            case "0":
                manager.SalvarListas();
                Console.WriteLine("Saindo do programa...");
                Console.WriteLine();
                break;
                
            default:
                Console.WriteLine("Opção invalida");
                Console.WriteLine();
                break;
        }
    }
    private static void CadastrarArtista()
    {
        Artista artista = new Artista();

         Console.WriteLine("Digite o nome do Artista");
         artista.Nome = Console.ReadLine();
         
         Console.WriteLine("Digite o Pais de origem do Artista");
         artista.Pais = Console.ReadLine();

         Console.WriteLine("Digite o genero musical do Artista");
         artista.Genero = Console.ReadLine();


        manager.AdcionarArtista(artista);

    }

    private static void CadastrarMusica()
    {
        Musica musica = new Musica();

        Console.WriteLine("Digite o nome da musica:"); 
        musica.Nome = Console.ReadLine();

        Console.WriteLine("Digite o genero da musica:"); 
        musica.Genero = Console.ReadLine();

         Console.WriteLine("Digite a duração da musica:"); 
        musica.Duracao = TimeOnly.Parse(Console.ReadLine());

        manager.AdcionarMusica(musica);
    }

    private static void EnturmarMusicaEmArtista()
    {
          Console.WriteLine("Digite o nome do artista");
          string nomeArtista = Console.ReadLine();
          Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if(artista == null)
        {
             Console.WriteLine("Não encontrei o artista");
            return;
        }

        Console.WriteLine("Digite o nome da musica");
        string nomeMusica = Console.ReadLine();
        Musica musica = manager.Musicas.FirstOrDefault(x => x.Nome == nomeMusica);

        if(nomeMusica == null)
        {
             Console.WriteLine("Não encontrei a musica");
            return;
        }
        else 
        {
             artista.Enturmar(musica);
        }
           
    }

private static void ExibirMusicasCriadas()
{
        if (manager.Musicas.Count == 0)
    {
        Console.WriteLine("Nenhuma música foi criada ainda.");
        return;
    }
    Console.WriteLine("Lista de músicas criadas:");

    foreach (var musica in manager.Musicas)
    {
        Console.WriteLine($"Nome da música: {musica.Nome}");
        Console.WriteLine($"Duração da música: {musica.Duracao}");
        Console.WriteLine($"Gênero da música: {musica.Genero}");
        Console.WriteLine("");
    }

}


    private static void ExibirMusicasArtista()
    {
          Console.WriteLine("Digite o nome do artista");
          string nomeArtista = Console.ReadLine();
          Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

            if(artista == null)
            {
                Console.WriteLine("Não encontrei o artista");
                return;
            }

        Console.WriteLine($"Nome do Artista: {artista.Nome}");
        Console.WriteLine($"Pais do Artista: {artista.Pais}");
        Console.WriteLine($"Genero do artista: {artista.Genero}");
        Console.WriteLine($"================= Musicas do artista===================");
        
        if(artista.MusicasArtista == null)
        {
            Console.WriteLine($"O artista não possui musicas");  
            Console.WriteLine("");
        }
        
        else
        {
            try { //erro null exeption 
                foreach (var item in artista.MusicasArtista)
                {
                    Console.WriteLine($"Nome da musica: {item.Nome}");
                    Console.WriteLine($"Duração da musica: {item.Duracao}");
                    Console.WriteLine($"Genero da musica: {item.Genero}");
                    Console.WriteLine("");
                }

             }
            catch{return;}
            
        }
           
                    
      

    }

    private static void EditarArtistas() 
    {
    
        Console.WriteLine("Digite o nome do artista que deseja editar:");
        string nomeArtista = Console.ReadLine();
        Artista artistaAntigo = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);

        if(artistaAntigo == null)
        {
             Console.WriteLine("Não encontrei o artista");
             return;
        }

        Console.WriteLine("Digite os novos parâmetros do artista:");

        Console.Write("Novo nome: ");
        string novoNome = Console.ReadLine();
        
        Console.Write("Nova nacionalidade: ");
        string novaNacionalidade = Console.ReadLine();

        Console.Write("Novo genero musical: ");
        string novoGenero = Console.ReadLine();

        Artista artistaNovo = new Artista
    {
        Nome = novoNome,
        Pais = novaNacionalidade,
        Genero = novoGenero
    };
        manager.EditarArtistas(artistaAntigo, artistaNovo);

    }

    private static void ExcluirArtista()
    {
          Console.WriteLine("Digite o nome do artista");
          string nomeArtista = Console.ReadLine();
          Artista artista = manager.Artistas.FirstOrDefault(x => x.Nome == nomeArtista);


        if(artista == null)
        {
             Console.WriteLine("Não encontrei o artista");
            return;
        }
        manager.ExcluirArtista(artista);
    }






}