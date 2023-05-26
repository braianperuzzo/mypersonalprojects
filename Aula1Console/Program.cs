using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string sCondicao;
            Console.WriteLine("Olá!");
            Console.WriteLine("Como você está?");
            sCondicao = Console.ReadLine();

            Console.WriteLine("A sua condição é: " + sCondicao);

            Console.ReadKey();
        }
    }
}