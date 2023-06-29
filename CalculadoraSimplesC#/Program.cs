using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraSimplesC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while{

                /* IDEIA FUTURA PARA DIGITAÇÃO LIVRE DA FÓRMULA
                Console.WriteLine("Digite a fórmula:");

                string formula = Console.ReadLine();

                string[] sPartes = formula.Split('+');
                string sEmpresa = sPartes[0];
                string sPedido = sPartes[1];
                
                Console.WriteLine("Resultado da operação: {0} {1}", sEmpresa, sPedido);*/
                                
                Console.WriteLine("Qual operação deseja fazer?:");
                Console.WriteLine("1 - Adição");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão \n");
                int operacao = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o primeiro número da operação:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o segundo número da operação:");
                int num2 = int.Parse(Console.ReadLine());

                int resultado = 0;

                string operador = string.Empty;

                switch (operacao)
                {
                    case 1:
                        {
                            resultado = num1 + num2;
                            operador = "+";
                            break;
                        }
                    case 2:
                        {
                            resultado = num1 - num2;
                            operador = "-";
                            break;
                        }
                    case 3:
                        {
                            resultado = num1 * num2;
                            operador = "*";
                            break;
                        }
                    case 4:
                        {
                            resultado = num1 / num2;
                            operador = "/";
                            break;
                        }

            }

                Console.WriteLine("Resultado da operação: {0} {1} {2} = {3}", num1, operador, num2, resultado);
            }
        }
    }
}