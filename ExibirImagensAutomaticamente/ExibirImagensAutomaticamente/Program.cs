using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string sImagens;
        string sTiposImagens;

        do
        {
            Console.WriteLine("Você gostaria de ver algumas imagens que podem alegrar seu dia?");
            Console.WriteLine("Digite o número:\r\n 1 - para 'Sim'\r\n 2 - para 'Não'");
            sImagens = Console.ReadLine() ?? string.Empty;

            if (sImagens == "1")
            {
                Console.WriteLine("Quais tipos de Imagem você gostaria de ver?");
                Console.WriteLine("Digite o número:\r\n 1 - para 'Animais Fofos'\r\n 2 - para 'Paisagens'\r\n 3 - para 'Calmantes'\r\n 4 - para 'Variadas'\r\n 5 - para 'Céu Noturno'\r\n 6 - para 'Espaço e Estrelas'\r\n 7 - para 'Aleatórias'\r\n 8 - para 'Não quero mais ver imagens'");
                sTiposImagens = Console.ReadLine() ?? string.Empty;

                HttpClient client = new HttpClient();
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
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                DisplayImages(imageUrls);

                Console.WriteLine("Deseja ver mais imagens? (Digite 'S' para Sim ou qualquer outra tecla para Sair)");
                sImagens = Console.ReadLine() ?? string.Empty;
            }

        } while (sImagens.ToUpper() == "S");
    }

    static void DisplayImages(List<string> imageUrls)
    {
        foreach (string imageUrl in imageUrls)
        {
            OpenUrlInBrowser(imageUrl);
        }
    }

    static async Task<List<string>> GetRandomImages(HttpClient client, string query)
    {
        const string apiKey = "JCWg96jCaiw-LKYWdidKZCzOLxv8XwFprGy8AIVDKhk";
        const string apiUrl = "https://api.unsplash.com/photos/random?count={0}&query={1}&client_id={2}";

        Console.WriteLine("Quantas imagens você deseja exibir?");
        int imageCount;
        while (!int.TryParse(Console.ReadLine(), out imageCount) || imageCount < 1)
        {
            Console.WriteLine("Quantidade inválida. Digite um número inteiro maior que zero.");
        }

        string requestUrl = string.Format(apiUrl, imageCount, query, apiKey);
        string response = await client.GetStringAsync(requestUrl);
        List<UnsplashImage> images = JsonConvert.DeserializeObject<List<UnsplashImage>>(response);

        List<string> imageUrls = new List<string>();

        foreach (UnsplashImage image in images)
        {
            imageUrls.Add(image.Urls.Regular);
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
            Console.WriteLine("Erro ao abrir a URL: " + ex.Message);
        }
    }

    class UnsplashImage
    {
        [JsonProperty("urls")]
        public UnsplashUrls Urls { get; set; }
    }

    class UnsplashUrls
    {
        [JsonProperty("regular")]
        public string Regular { get; set; }
    }
}
