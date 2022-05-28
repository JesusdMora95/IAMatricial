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
        int m1 = 0, m2 = -2, entrada = -1, salida = -1, n = 0, ban=0, archivo=0;
        string e = "-----";
        public Form1()
        {
            InitializeComponent();
            LimpiarDatos();
            BotonCargar();
            groupBox5.Enabled = false;
            label6.Text ="";
        }

        // codigos de interfaz

        private void LimpiarDatos() {
            label1.Text = "";
            label1.Text = "N/A x N/A \nN/A \nN/A \nN/A";
            label3.Text = "";
            label3.Text = "Tamaño de la matriz de datos : -" + e + e + e + "\nEntrada (E) : "
                + e + e + e + e + e + e + e + e + e + "\nSalida (S) : ---" + e + e + e + e + e + e + e + e + e + "\nPatrones (P) : ---" + e + e + e + e + e + e + e + e;
            ruta="";
            m1 = 0;
            m2 = -2;
            entrada = -1;
            salida = -1; 
            n = 0; 
            ban = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            groupBox1.Enabled = false;
            LimpiarListas();
            groupBox5.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label6.Text = "";
        }

        private void LimpiarListas()
        {
            comboBoxFuncion.Items.Clear();
            comboBoxRegla.Items.Clear();
            comboBoxFuncion.Text = "Funcion De Activacion";
            comboBoxRegla.Text = "Regla De Entramiento";
            groupBox2.Enabled = false;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            ban = 0;
        }

        private void BotonCargar()
        {
            if (archivo==0)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                archivo = 1;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
                archivo = 0;
            }
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
                ban = 0;
            }
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
                ban = 0;
            }
        }

        private void comboBoxFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxRegla.Text.Equals("Regla De Entramiento")&&!comboBoxFuncion.Text.Equals("Funcion De Activacion"))
            {
                groupBox5.Enabled = true;
            }
        }

        private void comboBoxRegla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxRegla.Text.Equals("Regla De Entramiento") && !comboBoxFuncion.Text.Equals("Funcion De Activacion"))
            {
                groupBox5.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            BotonCargar();
        }

        // fin codigos de interfaz

        //codigos de parametrizacion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ruta = openFile.FileName;
                label1.Text = Leer(ruta);
                BotonCargar();
                groupBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Se Pudo Cargar El Archivo");
            }
            
        }
        
        private string Leer(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea;
            while ((linea = reader.ReadLine()) != null)
            {
                while (ParaCiclo(linea, n))
                {
                    if(SaberSiContinuaEntrada(linea, n))
                    {
                        entrada++;
                        m2++;
                    }
                    if(SaberSiContinuaSalida(linea, n))
                    {
                        salida++;
                        m2++;
                    }
                    n++;
                }
                m1++;
            }
            string respuesta = m1+" x "+m2+ "\n"+entrada + "\n"+salida+ "\n"+ m2;
            reader.Close();
            file.Close();
            return respuesta;
        }

        private Boolean ParaCiclo(string linea, int n)
        {
            if (SaberSiContinuaEntrada(linea, n) || SaberSiContinuaSalida(linea, n))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean SaberSiContinuaEntrada(string linea, int n)
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

        private Boolean SaberSiContinuaSalida(string linea, int n)
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

        private void button3_Click(object sender, EventArgs e)
        {
            LenarMatriz();
        }

        private void LenarMatriz()
        {
            Random num = new Random();
            double recupera;
            double[,] Matriz = new double [m2, m1];
            double[] umbrales = new double[m2];
            for (int i = 0;i < m2; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    recupera = num.Next(-10, 11);
                    Matriz[i, j] = (recupera) / 10;
                }
                recupera = num.Next(-10, 11);
                umbrales[i]= (recupera) / 10;
            }
            Guardar(Matriz,umbrales);
        }

        public void Guardar(double[,] matriz, double[] umbral)
        {
            string FileName = ruta.Split('.')[0] + "_Pesos_y_umbrales.txt", linea = "";
            try
            {
                FileStream file = new FileStream(FileName, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < entrada; i++)
                {
                    for (int j = 0; j < salida; j++)
                    {
                        linea = linea + matriz[j, i] + ";";
                    }
                    writer.WriteLine($"{linea}");
                    linea = "";
                }
                for (int k = 0; k < salida; k++)
                {
                    linea = linea + umbral[k] + ";";
                }
                writer.WriteLine($"{linea}");
                writer.Close();
                file.Close();
                label6.Text = "Se guardo en la rura \n" + ruta.Split('.')[0] + "_Pesos_y_umbrales.txt";
            }
            catch (Exception e)
            {
                MessageBox.Show("No Se Pudo Cargar El Archivo" + e.Message);
            }
        }
    }
}
