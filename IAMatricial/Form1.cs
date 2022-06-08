using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IAMatricial
{
    public partial class Form1 : Form
    {
        
        string ruta,ruta2;
        int m1 = 0, m2 = -3, entrada = -1, salida = -2, n = 0, ban = 0, archivo = 0, P = 0, n2 = 0, c=0, c2=0;
        string e = "-----";
        public Form1()
        {
            InitializeComponent();
            LimpiarDatos();
            BotonCargar();
            label6.Text ="";
            checkBox3.Visible = false;
        }

        // codigos de interfaz

        private void LimpiarDatos() {
            label1.Text = "";
            label1.Text = "N/A x N/A \nN/A \nN/A \nN/A";
            label3.Text = "";
            label3.Text = "Tamaño de la matriz de datos : -" + e + e + e + "\nEntrada (E) : "
                + e + e + e + e + e + e + e + e + e + "\nSalida (S) : ---" + e + e + e + e + e + e + e + e + e + "\nPatrones (P) : ---" + e + e + e + e + e + e + e + e;
            ruta = "";
            ruta2 = "";
            m1 = 0;
            m2 = -3;
            entrada = -1;
            salida = -2; 
            n = 0; 
            ban = 0;
            P = 0;
            n2 = 0;
            c = 0;
            c2 = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            groupBox1.Enabled = false;
            groupBox11.Enabled = false;
            groupBox5.Enabled = false;
            LimpiarListas();
            //groupBox5.Enabled = false;
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
                groupBox11.Enabled = true;
                ban = 1;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                groupBox2.Enabled = false;
                groupBox11.Enabled = false;
                groupBox5.Enabled = false;
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
                groupBox11.Enabled = true;
                ban = 1;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                groupBox2.Enabled = false;
                groupBox11.Enabled = false;
                groupBox5.Enabled = false;
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
                groupBox11.Enabled = true;
                ban = 1;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                comboBoxFuncion.Items.Clear();
                comboBoxRegla.Items.Clear();
                groupBox2.Enabled = false;
                groupBox11.Enabled = false;
                groupBox5.Enabled = false;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumeroBox1(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Dato no valido o vacio, ingresar solo numeros mayores a 0");
                textBox1.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumeroBox2(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Dato no valido o vacio, ingresar solo numeros mayores a 0 y menos a 1");
                textBox2.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumeroBox2(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Dato no valido o vacio, ingresar solo numeros mayores a 0 y menos a 1");
                textBox3.Clear();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private Boolean NumeroBox1(string cadena)
        {
            try
            {
                int numero = Convert.ToInt32(cadena);
                if (numero>0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch
            {
                return true;
            }
        }

        private Boolean NumeroBox2(string cadena)
        {
            try
            {
                if (cadena.Equals("0,")|| cadena.Equals("0"))
                {
                    return false;
                }
                else
                {
                    double numero = Convert.ToDouble(cadena);
                    if (numero > 0 && numero < 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return true;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                errorProvider1.SetError(textBox1,"Ingresar valores numericos mayores a 0");
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                errorProvider1.SetError(textBox2, "Ingresar valores numericos mayores a 0 y menor a 1");
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                errorProvider1.SetError(textBox3, "Ingresar valores numericos mayores a 0 y menor a 1");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!ruta.Equals(""))
                Process.Start("explorer.exe", ruta);
        }

        // fin codigos de interfaz

        //codigos de parametrizacion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ruta = openFile.FileName;
                ruta2 = ruta;
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
                P++;
            }
            string respuesta = m1+" x "+m2+ "\n"+entrada + "\n"+salida+ "\n"+ P;
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
            double[,] Matriz = new double [m1, m2];
            double[] umbrales = new double[salida];
            for (int i = 0;i < entrada; i++)
            {
                for (int j = 0; j < salida; j++)
                {
                    recupera = num.Next(-10, 11);
                    Matriz[i,j] = (recupera) / 10;
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
                        linea = linea + matriz[i,j] + ";";
                    }
                    writer.WriteLine($"{linea}");
                    linea = "";
                }
                for (int k = 0; k < salida; k++)
                {
                    linea = linea + umbral[k] + ":";
                }
                writer.WriteLine($"{linea}");
                writer.Close();
                file.Close();
                ruta = ruta.Split('.')[0] + "_Pesos_y_umbrales.txt";
                label6.Text = "Se guardo en la ruta \n" + ruta;
            }
            catch (Exception e)
            {
                MessageBox.Show("No Se Pudo Cargar El Archivo" + e.Message);
            }
        }

        private double[] FuncionSoma(string[,] matrizdePesos, string[] umbral, string[,] matrizdeEntrada)
        {
            double[] resultado =  new double[salida];
            double paso;
            for (int i = 0; i < entrada; i++)
            {
                resultado[i] = 0;
                for (int j = 0; j < salida; j++)
                {
                    paso = double.Parse(matrizdeEntrada[i, j]) * double.Parse(matrizdePesos[i, j]);
                    resultado[i] = resultado[i] + paso ;
                }
                resultado[i] = resultado[i] - double.Parse(umbral[i]);
            }
            return resultado;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int bandera = 0;
            if(textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Faltan Parametros de entrenamiento");
                bandera = 1;
            }
            if (label6.Text.Equals(""))
            {
                MessageBox.Show("No se han cargado datos de pesos y umbrales");
                bandera = 1;
            }
            if (bandera == 0) 
            {
                int q = 0;
                double[] SFuncion = new double[salida];
                double[] SSalida = new double[salida];
                double[] ELineal = new double[salida];
                int dato = entrada * salida;
                double[] LineaSalida = new double[dato];
                double[,] TodoSalida = new double[entrada,salida];
                string[,] matrizres = LeerSalidas(ruta2);
                for (int i = 0; i < salida; i++)
                {
                    for (int j = 0; j < salida; j++)
                    {
                        TodoSalida[j, i] = Convert.ToDouble(matrizres[i, j]);
                    }
                }
                while (q <= Convert.ToInt32(textBox1.Text))
                {
                    LineaSalida = ObtenerLinea(TodoSalida, q);
                    SFuncion = FuncionSoma(LeerPesos(ruta), LeerUmbrales(ruta), LeerEntradas(ruta2));
                    if (checkBox1.Checked)
                    {
                        int ciclo = 0;
                        while (ciclo < salida)
                        {
                            if (SFuncion[ciclo] < 0)
                            {
                                SSalida[ciclo] = 0;
                            }
                            if (SFuncion[ciclo] >= 0)
                            {
                                SSalida[ciclo] = 1;
                            }
                            ciclo++;
                        }
                    }
                    if (checkBox2.Checked)
                    {
                        SSalida = SFuncion;
                    }
                    ELineal = ErrorLineal(LineaSalida, SSalida, dato);
                    q++;
                    MessageBox.Show("entra"+ Convert.ToInt32(textBox1.Text));
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ruta = openFile.FileName;
                label6.Text = "Se cargaron los datos de \n" + ruta;
            }
            else
            {
                MessageBox.Show("No Se Pudo Cargar El Archivo");
            }
        }

        private string[] LeerUmbrales(string fileName)
        {
            string[] umbralesLectura = new string[salida];
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea;
            c = 0;
            while ((linea = reader.ReadLine()) != null)
            {
                while (DatoUmbrales(linea, n2) && n2<salida)
                {
                    umbralesLectura[c] = linea.Split(':')[n2];
                    n2++;
                    c++;
                }
            }
            n2 = 0;
            c = 0;
            Graficar(umbralesLectura);
            return umbralesLectura;
        }

        private string[,] LeerPesos(string fileName)
        {
            string[,] umbralesLectura = new string[entrada,salida];
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea;
            while ((linea = reader.ReadLine()) != null && c<entrada)
            {
                while (DatoPeso(linea, n2))
                {
                    umbralesLectura[c,c2] = linea.Split(';')[n2];
                    n2++;
                    c2++;
                }
                c++;
                c2 = 0;
                n2 = 0;
            }
            c = 0;
            return umbralesLectura;
        }

        private string[,] LeerEntradas(string fileName)
        {
            string[,] umbralesLectura = new string[entrada, salida];
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea;
            while ((linea = reader.ReadLine()) != null && c < entrada )
            {
                while (DatoEntrada(linea, n2))
                {
                    umbralesLectura[c,c2] = linea.Split('|')[n2];
                    n2++;
                    c2++;
                }
                c++;
                c2 = 0;
                n2 = 0;
            }
            c = 0;
            return umbralesLectura;
        }

        private string[,] LeerSalidas(string fileName)
        {
            string[,] umbralesLectura = new string[entrada, salida];
            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea;
            while ((linea = reader.ReadLine()) != null && c < entrada)
            {
                while (DatoSalida(linea, n2+1))
                {
                    umbralesLectura[c,c2] = linea.Split(';')[n2+1];
                    n2++;
                    c2++;
                }
                c++;
                c2 = 0;
                n2 = 0;
            }
            c = 0;
            return umbralesLectura;
        }

        private Boolean DatoUmbrales(string linea, int n)
        {
            try
            {
                double convertir = Convert.ToDouble(linea.Split(':')[n]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean DatoPeso(string linea, int n)
        {
            try
            {
                double convertir = Convert.ToDouble(linea.Split(';')[n]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean DatoEntrada(string linea, int n)
        {
            try
            {
                double convertir = Convert.ToDouble(linea.Split('|')[n]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean DatoSalida(string linea, int n)
        {
            try
            {
                double convertir = Convert.ToDouble(linea.Split(';')[n]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Graficar(string[] umbralesLectura)
        {
            chart1.Palette = ChartColorPalette.Pastel;
            for (int i = 0; i < c; i++) 
            {
                Series series = chart1.Series.Add("Iteracion "+i);
                series.Points.Add(Convert.ToDouble(umbralesLectura[i]));
            }
        }


        private double[] ObtenerLinea(double[,] matriz, int k)
        {
            int dato = entrada * salida;
            double[] LineaSalida = new double[dato];
            int c = 0;
            for (int i = 0; i < salida; i++)
            {
                for (int j = 0; j < salida; j++)
                {
                    if (k == i)
                    {
                        LineaSalida[c] = matriz[i, j];
                    }
                }
            }
            return LineaSalida;
        }

        private double[] ErrorLineal(double[]vectorsalida, double[] resultado, int dato)
        {
            double[] resul = new double[dato];
            for (int i = 0; i < entrada; i++)
            {
                resul[i] = vectorsalida[i] - resultado[i];
            }
            return resul;
        }
    }
}
