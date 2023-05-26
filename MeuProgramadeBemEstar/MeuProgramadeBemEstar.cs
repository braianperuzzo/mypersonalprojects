using System;

namespace MeuProgramadeBemEstar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá!"); // Exibe uma mensagem de saudação
            Console.WriteLine("Como você está?"); // Pergunta como o usuário está

            while (true) // Loop infinito para manter o programa em execução
            {
                RunProgram(); // Chama a função RunProgram para executar o programa principal
            }
        }

        static void RunProgram()
        {
            string sEstadodeSaude; // Variável para armazenar o estado de saúde informado pelo usuário

            Console.WriteLine("Digite o número:\r\n 1 - para 'Estou Bem'\r\n 2 - para 'Estou Mal'"); // Exibe as opções para o usuário
            sEstadodeSaude = Console.ReadLine() ?? string.Empty; // Lê a entrada do usuário e atribui à variável sEstadodeSaude. Caso seja nulo, atribui uma string vazia.

            if (sEstadodeSaude == "1") // Se o estado de saúde informado for "1"
            {
                Console.WriteLine("Que ótimo que você está bem ^^"); // Exibe uma mensagem de resposta positiva

                int iContador = 5; // Tempo em segundos

                while (iContador > 0) // Loop para contar de 5 a 1
                {
                    Console.SetCursorPosition(0, Console.CursorTop); // Posiciona o cursor no início da linha
                    Console.Write("Como não há nada no que eu possa te ajudar, estarei encerrando esse programa em " + iContador + " segundos."); // Exibe uma mensagem informando que o programa será encerrado em determinados segundos
                    iContador--; // Decrementa o contador
                    System.Threading.Thread.Sleep(1000); // Aguarda 1 segundo antes de continuar
                }

                Environment.Exit(0); // Encerra o programa
            }
            else if (sEstadodeSaude == "2") // Se o estado de saúde informado for "2"
            {
                Console.WriteLine("Poxa :/ que pena. Mas me conta, o que aconteceu?"); // Exibe uma mensagem de resposta para um estado de saúde ruim
                string sEstadodeSaudeRuim = Console.ReadLine() ?? string.Empty; // Lê a entrada do usuário e atribui à variável sEstadodeSaudeRuim. Caso seja nulo, atribui uma string vazia.
                Console.WriteLine("Prontinho! Registrei seu estado de saúde atual."); // Exibe uma mensagem informando que o estado de saúde foi registrado

                int iContador = 5; // Tempo em segundos

                while (iContador > 0) // Loop para contar de 5 a 1
                {
                    Console.SetCursorPosition(0, Console.CursorTop); // Posiciona o cursor no início da linha
                    Console.Write("Como não há nada no que eu possa te ajudar, estarei encerrando esse programa em " + iContador + " segundos."); // Exibe uma mensagem informando que o programa será encerrado em determinados segundos
                    iContador--; // Decrementa o contador
                    System.Threading.Thread.Sleep(1000); // Aguarda 1 segundo antes de continuar
                }

                Environment.Exit(0); // Encerra o programa
            }
            else // Se o estado de saúde informado não for "1" nem "2"
            {
                if (string.IsNullOrEmpty(sEstadodeSaude)) // Se a entrada do usuário estiver vazia
                    Console.WriteLine("Opa! Acho que faltou algo. Por favor, digite uma opção :s"); // Exibe uma mensagem de aviso informando que algo está faltando

                else if (sEstadodeSaude != "1" && sEstadodeSaude != "2") // Se a entrada do usuário não for nem "1" nem "2"
                    Console.WriteLine("Opa! O número " + sEstadodeSaude + " não é uma opção válida :s"); // Exibe uma mensagem de aviso informando que a opção não é válida

                return; // Retorna ao início do programa
            }

            Console.ReadKey(); // Aguarda uma tecla ser pressionada antes de encerrar o programa (opcional)
        }
    }
}
