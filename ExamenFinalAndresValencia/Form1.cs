using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ExamenFinalAndresValencia
{
    public partial class Form1 : Form
    {
        int z, j, limite;
        string informe;
        double netoterapia, promedio, valorterapia, descuento1;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            Application.Exit();
    
        }

        private void btnprocesar_Click(object sender, EventArgs e)
        {
            do
            {
                limite = int.Parse(Interaction.InputBox("Cantidad de Pacientes : "));
                if (limite <= 0)
                {
                    MessageBox.Show("Numero de pacientes no validos, Intente Otra vez.");

                }
            } while (limite <= 0);

            string[] nomPaciente = new string[limite];
            double[] descuento = new double[limite];

            for (z = 0; z < nomPaciente.Length; z++)
            {
                nomPaciente[z] = Interaction.InputBox("Nombre del paciente: ");
                valorterapia = double.Parse(Interaction.InputBox("Valor de la consulta: "));
                if (valorterapia < 500 || valorterapia > 1000) {
                    MessageBox.Show("Valor de Consulta no validos, Intente Otra vez.");
                }
                descuento1 = calculardescuento(valorterapia, descuento1);
                descuento[z] = descuento1;
                netoterapia += valorterapia;
            }

            informe = generarinforme(nomPaciente, descuento);
            promedio = netoterapia / limite;
            MessageBox.Show("Promedio: " + promedio);
            MessageBox.Show("INFORME: " + informe);
            textBox1.Text = promedio.ToString();
            richTextBox1.Text = ("\nINFORME: " + "\n" + informe);
        }
       
        private double calculardescuento(double valor_terapia, double descuento1)
        {
            if (valor_terapia > 500 || valor_terapia > 1000)
            {
                descuento1 = valor_terapia * 0.30;
            }
            else
            {
                descuento1 = valor_terapia * 0.10;
            }
            return descuento1;
        }

        public string generarinforme(string[] nomPaciente, double[] descuento)
        {
            for (z = 0; z < limite; z++)
            {
                informe += "\nNombre del paciente: " + nomPaciente[z] + "\n Descuento: " + descuento[z];
            }
            return informe;
        }
    }

}   