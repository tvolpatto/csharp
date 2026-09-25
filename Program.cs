// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso"};  

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

/*
    Displays the logo of the application in ASCII art format.
*/
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

/*
    Displays the main menu options to the user and handles their selection.
*/
void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda("");
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: CalcularMediaDaBanda();
            break;
        case 0: Console.WriteLine("Tchau tchau :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

/*
    Registers a new band by prompting the user for its name and adding it to the list of bands.
*/
void RegistrarBanda(string nomeDaBanda)
{   
    if( nomeDaBanda == null || nomeDaBanda == string.Empty)
    {
         ExibirTituloDaOpcao("Registro de bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        nomeDaBanda = Console.ReadLine()!;
    }
      
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

/*
    Displays all registered bands to the user.
*/
void MostrarBandasRegistradas()
{

    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
    
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
        //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    ExibirOpcoesDoMenu();
    
}
/*
    Displays a title for the current option, surrounded by asterisks for emphasis.
    string titulo: The title to display.
*/
void ExibirTituloDaOpcao(string titulo)
{
    Console.Clear();
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

/*
    Allows the user to rate a registered band by entering its name and a rating score.
*/
void AvaliarBanda()
{
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Digite a nota que deseja dar para a banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está registrada.");
        AutoRegistrarBanda(nomeDaBanda);
       
    }
    
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    ExibirOpcoesDoMenu();
    Thread.Sleep(2000);
    Console.Clear();
}

/*
    Calculates and displays the average rating for a specified band.
*/
void CalcularMediaDaBanda()
{
    ExibirTituloDaOpcao("Média da banda");
    Console.Write("Digite o nome da banda que deseja calcular a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        double media = notasDaBanda.Count > 0 ? notasDaBanda.Average() : 0;
        Console.WriteLine($"A média da banda {nomeDaBanda} é {media}");
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está registrada.");
        AutoRegistrarBanda(nomeDaBanda);
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    ExibirOpcoesDoMenu();
}
/*
    Prompts the user to automatically register a band if it is not already registered.
    string nomeDaBanda: The name of the band to potentially register.
*/
void AutoRegistrarBanda(string nomeDaBanda)
{
   Console.Write("Digite S para registrar a banda automaticamente ou qualquer outra tecla para não registrar: ");
   string confirmaRegistro = Console.ReadLine()!;
   if (confirmaRegistro.ToUpper() == "S")
   {
       RegistrarBanda(nomeDaBanda);
   }
   
}

ExibirOpcoesDoMenu();