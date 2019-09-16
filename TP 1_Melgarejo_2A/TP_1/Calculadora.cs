using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora  
    {
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string operadores;

            operadores = ValidarOperador(operador);

            switch (operadores)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        private static string ValidarOperador(string operador) // valida los operadores y caso contrario retornara +
        {
            while (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;

            }
            return "+";
        }
    }
}
