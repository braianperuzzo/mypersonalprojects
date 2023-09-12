using System;

namespace VerificandoNumeros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resposta;
            string invalida;

            //Desenvolvimento de um algoritmo que verifica se o número digitado é par ou impar.
            do {

                //Declaração da variavel numero
                int numero;
                
                                //Exbição de campo de digitação na tela e conversão da váriavel número para ser lida
                Console.WriteLine("Informe o Número: ");
                numero = Convert.ToInt32(Console.ReadLine());

                //Para verificar se é par ou impar basta verificar se o número é divisivel por 2

                if (numero % 2 == 0)
                {
                    Console.WriteLine("O número informado é PAR");
                }
                else
                {
                    Console.WriteLine("O número informado é IMPAR");
                }

                do
                {
                    Console.WriteLine("Deseja verificar outro número? (S/N): ");
                        resposta = Console.ReadLine();

                    if (resposta.ToUpper() != "S" && resposta.ToUpper() != "N")
                        Console.WriteLine("Opção inválida");

                } while (resposta.ToUpper() != "S" && resposta.ToUpper() != "N");

            } while (resposta.ToUpper() == "S");

        }
    }
}