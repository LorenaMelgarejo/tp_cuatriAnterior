using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;


        private string SetNumero
        {

            set { this._numero = this.ValidarNumero(value); }
        }


        #region Metodos


        public Numero()  // constructor por defecto que inicializa numero en 0
        {
            this._numero = 0;
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string strNumero)
        {

            this.SetNumero = strNumero;
        }



        public string BinarioDecimal(string binario)
        {
           
            int exponente = binario.Length - 1;
            int num_decimal = 0;

            for (int i = 0; i < binario.Length; i++)
            {

                if (int.Parse(binario.Substring(i, 1)) == 1)
                {
                    num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                }

                exponente--;
            }
            return num_decimal.ToString();
        }
            


           
        

        public string DecimalBinario(double numero)
        {
            string bin= "";

            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        bin = "0" + bin;
                    }
                    else
                    {
                        bin = "1" + bin;
                    }
                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                bin= "0";
            }
            return bin;
        }


        public string DecimalBinario(string numero)
        {

            string cadena = "";

            cadena = this.DecimalBinario(Convert.ToDouble(numero));

            return cadena;

        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }

        private double ValidarNumero(string strNumero) // valida q sea doble y en caso contrario retornara 0
        {
            double valor;

            if (double.TryParse(strNumero, out valor))
            {
                return valor;
            }

            else
            {
                return 0;
            }

        }
        #endregion
    }
}

