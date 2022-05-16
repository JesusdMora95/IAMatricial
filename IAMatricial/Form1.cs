using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAMatricial
{
    public partial class Form1 : Form
    {
        string ruta;
        int m1 = 0, m2 = -2, entrada = -1, salida = -1, n = 0, ban=0;
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            button1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ruta = openFile.FileName;
                label1.Text=Leer(ruta);
            }
            else
            {
                MessageBox.Show("No Se Pudo Cargar El Archivo");
            }
            //LenarMatriz();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (ban == 0)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                comboBoxFuncion.Items.Add("Lineal");
                comboBoxRegla.Items.Add("Regla delta");
                groupBox2.Enabled = true;
                ban = 1;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                groupBox2.Enabled = false;
                comboBoxFuncion.Text = "Funcion De Activacion";
                comboBoxRegla.Text = "Regla De Entramiento";
                EstadoBoton();
                ban = 0;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (ban == 0)
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                comboBoxFuncion.Items.Add("Sigmoide");
                comboBoxFuncion.Items.Add("Tangente hiperbolica");
                comboBoxRegla.Items.Add("Propagacion inversa");
                groupBox2.Enabled = true;
                ban = 1;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                groupBox2.Enabled = false;
                comboBoxFuncion.Text = "Funcion De Activacion";
                comboBoxRegla.Text = "Regla De Entramiento";
                EstadoBoton();
                ban = 0;
            }
        }

        private void comboBoxFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstadoBoton();
        }

        private void comboBoxRegla_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstadoBoton();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ban == 0)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                comboBoxFuncion.Items.Add("Escalon");
                comboBoxRegla.Items.Add("Recla delta");
                groupBox2.Enabled = true;
                ban = 1;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                groupBox2.Enabled = false;
                comboBoxFuncion.Text = "Funcion De Activacion";
                comboBoxRegla.Text = "Regla De Entramiento";
                EstadoBoton();
                ban = 0;
            }
        }

        private string Leer(string fileName)
        {
            string e = "-----";
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea;
            while ((linea = reader.ReadLine()) != null)
            {
                while (ParaCiclo(linea, n))
                {
                    if(SaberSiContunuaEntrada(linea, n))
                    {
                        entrada++;
                        m2++;
                    }
                    if(SaberSiContunuaSalida(linea, n))
                    {
                        salida++;
                        m2++;
                    }
                    n++;
                }
                m1++;
            }
            string respuesta = "Tamaño de la matriz : -" + e +" "+ m1+" x "+m2+ "\nEntrada : " 
                +e+e+e+e+e+ " "+entrada + "\nSalida : ---" +e+e+e+e+e+ " "+salida+ "\nPatrones : ---"+e+e+e+e+ " "+ m2;
            reader.Close();
            file.Close();
            return respuesta;
        }
        private Boolean ParaCiclo(string linea, int n)
        {
            if (SaberSiContunuaEntrada(linea, n) || SaberSiContunuaSalida(linea, n))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean SaberSiContunuaEntrada(string linea, int n)
        {
            try
            {
                string convertir = linea.Split('|')[n];
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean SaberSiContunuaSalida(string linea, int n)
        {
            try
            {
                string convertir = linea.Split(';')[n];
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void EstadoBoton()
        {
            if (!comboBoxFuncion.Text.Equals("Funcion De Activacion") && !comboBoxRegla.Text.Equals("Regla De Entramiento"))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        } 

        /*private void LenarMatriz()
        {
            Random num = new Random();
            double[,] Matriz = new double [m1++,m2++];
            for(int i = 0;i <= m1; i++)
            {
                for (int j = 0; j <= m2; j++)
                {
                    //Matriz[i,j] = num.Next(0,2);
                }
            }
            string mensaje = "" + Matriz[0, 0] + "  " +num.NextDouble()*(1+(-1))+(-1) ;
            label2.Text = mensaje;
        }*/
    }
}
