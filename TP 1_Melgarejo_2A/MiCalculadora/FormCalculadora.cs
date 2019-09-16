using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            string[] operadores = { "+", "-", "/", "*" };

            for (int i = 0; i < 4; i++)
            {
                this.cmbOperador.Items.Add(operadores[i]);
            }

            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperador.SelectedIndex = 0;
        }


        

        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calcu = new Calculadora();
            retorno = calcu.Operar(num1, num2, operador);

            return retorno;


        }




        private void Limpiar()
        {
            this.txtNumero1.ResetText();
            this.txtNumero2.ResetText();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }


        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            this.txtNumero1.Multiline = true;
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            this.txtNumero2.Multiline = true;
        }



        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = 0;

            resultado =Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

            this.lblResultado.Text = resultado.ToString();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                Numero num = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor Invalido";
            }

        }

        private void btnConvertitADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                Numero num = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor Invalido";

            }

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }
    }

      

        
    
}
