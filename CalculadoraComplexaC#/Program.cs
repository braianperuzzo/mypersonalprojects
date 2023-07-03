using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma expressão matemática: ");
        string expressao = Console.ReadLine();

        double resultado = AvaliarExpressao(expressao);

        Console.WriteLine("Resultado: " + resultado);
    }

    static double AvaliarExpressao(string expressao)
    {
        List<char> caracteres = new List<char>(expressao.Replace(" ", ""));

        return AvaliarExpressaoRecursivo(caracteres);
    }

    static double AvaliarExpressaoRecursivo(List<char> caracteres)
    {
        Stack<double> numeros = new Stack<double>();
        Stack<char> operadores = new Stack<char>();

        while (caracteres.Count > 0)
        {
            char caractereAtual = caracteres[0];
            caracteres.RemoveAt(0);

            if (char.IsDigit(caractereAtual) || caractereAtual == '.')
            {
                string numeroStr = caractereAtual.ToString();

                while (caracteres.Count > 0 && (char.IsDigit(caracteres[0]) || caracteres[0] == '.'))
                {
                    numeroStr += caracteres[0];
                    caracteres.RemoveAt(0);
                }

                double numero;
                if (!double.TryParse(numeroStr, out numero))
                {
                    throw new ArgumentException("Número inválido: " + numeroStr);
                }

                numeros.Push(numero);
            }
            else if (caractereAtual == '(')
            {
                double resultadoParenteses = AvaliarExpressaoRecursivo(caracteres);
                numeros.Push(resultadoParenteses);
            }
            else if (caractereAtual == ')')
            {
                break;
            }
            else if (caractereAtual == '+' || caractereAtual == '-' || caractereAtual == '*' || caractereAtual == '/')
            {
                while (operadores.Count > 0 && TemPrecedencia(caractereAtual, operadores.Peek()))
                {
                    CalcularOperador(numeros, operadores);
                }

                operadores.Push(caractereAtual);
            }
            else
            {
                throw new ArgumentException("Caractere inválido: " + caractereAtual);
            }
        }

        while (operadores.Count > 0)
        {
            CalcularOperador(numeros, operadores);
        }

        return numeros.Pop();
    }

    static bool TemPrecedencia(char operadorAtual, char operadorAnterior)
    {
        if (operadorAnterior == '(' || operadorAnterior == ')')
            return false;

        if ((operadorAtual == '*' || operadorAtual == '/') && (operadorAnterior == '+' || operadorAnterior == '-'))
            return false;

        return true;
    }

    static void CalcularOperador(Stack<double> numeros, Stack<char> operadores)
    {
        double numero2 = numeros.Pop();
        double numero1 = numeros.Pop();

        char operador = operadores.Pop();

        double resultado = RealizarCalculo(numero1, operador, numero2);
        numeros.Push(resultado);
    }

    static double RealizarCalculo(double numero1, char operador, double numero2)
    {
        switch (operador)
        {
            case '+':
                return numero1 + numero2;
            case '-':
                return numero1 - numero2;
            case '*':
                return numero1 * numero2;
            case '/':
                return numero1 / numero2;
            default:
                throw new ArgumentException("Operador inválido: " + operador);
        }
    }
}