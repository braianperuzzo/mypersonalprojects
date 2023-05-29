using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class ExibirImagensAutomaticamente
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Você gostaria de ver algumas imagens que podem alegrar seu dia?");
            Console.WriteLine("Digite o número:\r\n 1 - para 'Sim'\r\n 2 - para 'Não'");
            string? sImagens = Console.ReadLine() ?? string.Empty;

            if (sImagens == "1")
            {
                await ExibirImagens();
            }
            else if (sImagens != "1" && sImagens != "2")
            {
                if (string.IsNullOrEmpty(sImagens)) // Se a entrada do usuário estiver vazia
                    Console.WriteLine("Opa! Acho que faltou algo. Por favor, digite uma opção :s"); // Exibe uma mensagem de aviso informando que algo está faltando
                else
                    Console.WriteLine("Opa! O número " + sImagens + " não é uma opção válida :s"); // Exibe uma mensagem de aviso informando que a opção não é válida

                continue;
            }
            else
            {
                ExitProgram();
                break;
            }
        }
    }

    static async Task ExibirImagens()
    {
        while (true)
        {
            Console.WriteLine("Quais tipos de Imagem você gostaria de ver?");
            Console.WriteLine("Digite o número:\r\n 1 - para 'Animais Fofos'\r\n 2 - para 'Paisagens'\r\n 3 - para 'Calmantes'\r\n 4 - para 'Variadas'\r\n 5 - para 'Céu Noturno'\r\n 6 - para 'Espaço e Estrelas'\r\n 7 - para 'Aleatórias'\r\n 8 - para 'Não quero mais ver imagens'");
            string sTiposImagens = Console.ReadLine() ?? string.Empty;

            using (HttpClient client = new HttpClient())
            {
                List<string> imageUrls = new List<string>();

                switch (sTiposImagens)
                {
                    case "1": // Animais Fofos
                        imageUrls = await GetRandomImages(client, "cute animals");
                        break;
                    case "2": // Paisagens
                        imageUrls = await GetRandomImages(client, "landscapes");
                        break;
                    case "3": // Calmantes
                        imageUrls = await GetRandomImages(client, "calming");
                        break;
                    case "4": // Variadas
                        imageUrls = await GetRandomImages(client, string.Empty);
                        break;
                    case "5": // Céu Noturno
                        imageUrls = await GetRandomImages(client, "night sky");
                        break;
                    case "6": // Espaço e Estrelas
                        imageUrls = await GetRandomImages(client, "space stars");
                        break;
                    case "7": // Aleatórias
                        imageUrls = await GetRandomImages(client, "random");
                        break;
                    case "8": // Não quero mais ver imagens
                        ExitProgram();
                        return;
                    default:
                        {
                            if (string.IsNullOrEmpty(sTiposImagens)) // Se a entrada do usuário estiver vazia
                                Console.WriteLine("Opa! Acho que faltou algo. Por favor, digite uma opção :s"); // Exibe uma mensagem de aviso informando que algo está faltando
                            else
                                Console.WriteLine("Opa! O número " + sTiposImagens + " não é uma opção válida :s"); // Exibe uma mensagem de aviso informando que a opção não é válida

                            continue;
                        }
                }

                DisplayImages(imageUrls);
            }

            while (true)
            {
                Console.WriteLine("Deseja ver mais imagens?");
                Console.WriteLine("Digite o número:\r\n 1 - para 'Sim'\r\n 2 - para 'Não'");
                string sMaisImagens = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(sMaisImagens))
                {
                    Console.WriteLine("Opa! Acho que faltou algo. Por favor, digite uma opção :s");
                    continue;
                }
                else if (sMaisImagens != "1" && sMaisImagens != "2")
                {
                    Console.WriteLine("Opa! O número " + sMaisImagens + " não é uma opção válida :s");
                    continue;
                }
                else if (sMaisImagens == "2")
                {
                    ExitProgram();
                    return;
                }
                else
                {
                    break;
                }
            }
        }
    }

    static void DisplayImages(List<string> imageUrls)
    {
        for (int i = 0; i < imageUrls.Count; i++)
        {
            OpenUrlInBrowser(imageUrls[i]);
        }
    }

    //API de imagens
    static async Task<List<string>> GetRandomImages(HttpClient client, string query)
    {
        const string apiKey = "JCWg96jCaiw-LKYWdidKZCzOLxv8XwFprGy8AIVDKhk";
        const string apiUrl = "https://api.unsplash.com/photos/random?count={0}&query={1}&client_id={2}";

        Console.WriteLine("Quantas imagens você deseja visualizar?");
        int imageCount;
        while (!int.TryParse(Console.ReadLine(), out imageCount) || imageCount < 1)
        {
            Console.WriteLine("Digite um número válido (maior que 0):");
        }

        string url = string.Format(apiUrl, imageCount, query, apiKey);

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();
        List<UnsplashImage>? images = JsonConvert.DeserializeObject<List<UnsplashImage>>(json);

        List<string> imageUrls = new List<string>();
        if (images != null)
        {
            foreach (UnsplashImage image in images)
            {
                if (image.Urls != null && image.Urls.Regular != null)
                {
                    imageUrls.Add(image.Urls.Regular);
                }
            }
        }

        return imageUrls;
    }

    static void OpenUrlInBrowser(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível abrir o navegador: " + ex.Message);
        }
    }

    static void ExitProgram()
    {
        Console.WriteLine("Certo, agradeço por ter chegado até aqui.");

        for (int i = 5; i > 0; i--)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("Como não há nada no que eu possa te ajudar, estarei encerrando esse programa em " + i + " segundos.");
            Task.Delay(1000).Wait();
        }

        Environment.Exit(0);
    }
}

class UnsplashImage
{
    public UnsplashImageUrls? Urls { get; set; }
}

class UnsplashImageUrls
{
    public string? Regular { get; set; }
}
