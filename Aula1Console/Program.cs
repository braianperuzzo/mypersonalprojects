using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Aula1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string sEstadodeSaude;
            string sEstadodeSaudeRuim;
            Console.WriteLine("Olá!");
            Console.WriteLine("Como você está?");
            Console.WriteLine("Digite o número:\r\n 1 - para 'Estou Bem'\r\n 2 - para 'Estou Mal'");
            sEstadodeSaude = Console.ReadLine();

            if (sEstadodeSaude == "1")
            {
                Console.WriteLine("Que ótimo que você está bem ^^");

                int iContador = 5; // Tempo em segundos

                while (iContador > 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop); // Posiciona o cursor no início da linha
                    Console.Write("Como não há nada no que eu possa te ajudar, estarei encerrando esse programa em " + iContador + " segundos.");
                    iContador--;
                    System.Threading.Thread.Sleep(1000);
                }

                return; // Encerra o programa
            }
            else if (sEstadodeSaude == "2")
            {
                Console.WriteLine("Poxa :/ que pena. Mas me conta, o que aconteceu?");
                sEstadodeSaudeRuim = Console.ReadLine();
                Console.WriteLine("Prontinho! Registrei seu estado de saúde atual. Aqui estão algumas piadas para te animar:");

                // Obtém 3 piadas aleatórias em português
                for (int i = 0; i < 3; i++)
                {
                    string joke = GetRandomJoke();

                    // Exibe a piada na janela do console
                    Console.WriteLine(joke);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(sEstadodeSaude))
                    Console.WriteLine("Opa! Acho que faltou algo. Por favor, digite uma opção :s");

                if (sEstadodeSaude != "1" && sEstadodeSaude != "2")
                    Console.WriteLine("Opa! O número " + sEstadodeSaude + " não é uma opção válida :s");

                while (sEstadodeSaude != "1" && sEstadodeSaude != "2")
                {
                    Console.WriteLine("Como você está?");
                    Console.WriteLine("Digite o número:\r\n 1 - para 'Estou Bem'\r\n 2 - para 'Estou Mal'");
                    sEstadodeSaude = Console.ReadLine();

                    if (sEstadodeSaude == "1")
                    {
                        Console.WriteLine("Que ótimo que você está bem ^^");
                    }
                    else if (sEstadodeSaude == "2")
                    {
                        Console.WriteLine("Poxa :/ que pena. Posso te ajudar em algo?");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sEstadodeSaude))
                            Console.WriteLine("Opa! Acho que faltou algo. Por favor, digite uma opção :s");

                        if (sEstadodeSaude != "1" && sEstadodeSaude != "2")
                            Console.WriteLine("Opa! O número " + sEstadodeSaude + " não é uma opção válida :s");
                    }
                }
            }

            Console.ReadKey();
        }

        static string GetRandomJoke()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://v2.jokeapi.dev/joke/Any?lang=pt&type=single";
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonData = JsonConvert.DeserializeObject(json);
                    string joke = jsonData.joke;
                    return joke;
                }
                else
                {
                    throw new Exception("Erro ao obter uma piada: " + response.StatusCode);
                }
            }
        }
    }
}
