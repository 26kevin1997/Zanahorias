using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProductorConsumidor
{
    public partial class Form1 : Form
    {
        Thread productor;
        Productor p;
        Consumidor c;
        List<Casilla> casillas;
        int numero, numeroProductos, numero2;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            productor = new Thread(startProductor);

            casillas = new List<Casilla>();
            casillas.Add(new Casilla(pictureBox1)); casillas.Add(new Casilla(pictureBox2)); casillas.Add(new Casilla(pictureBox3));
            casillas.Add(new Casilla(pictureBox4)); casillas.Add(new Casilla(pictureBox5)); casillas.Add(new Casilla(pictureBox6));
            casillas.Add(new Casilla(pictureBox7)); casillas.Add(new Casilla(pictureBox8)); casillas.Add(new Casilla(pictureBox9));
            casillas.Add(new Casilla(pictureBox10)); casillas.Add(new Casilla(pictureBox11)); casillas.Add(new Casilla(pictureBox12));
            casillas.Add(new Casilla(pictureBox13)); casillas.Add(new Casilla(pictureBox14)); casillas.Add(new Casilla(pictureBox15));
            casillas.Add(new Casilla(pictureBox16)); casillas.Add(new Casilla(pictureBox17)); casillas.Add(new Casilla(pictureBox18));
            casillas.Add(new Casilla(pictureBox19)); casillas.Add(new Casilla(pictureBox20)); casillas.Add(new Casilla(pictureBox21));
            casillas.Add(new Casilla(pictureBox22)); casillas.Add(new Casilla(pictureBox23)); casillas.Add(new Casilla(pictureBox24));
            casillas.Add(new Casilla(pictureBox25)); casillas.Add(new Casilla(pictureBox26)); casillas.Add(new Casilla(pictureBox27));
            casillas.Add(new Casilla(pictureBox28)); casillas.Add(new Casilla(pictureBox29)); casillas.Add(new Casilla(pictureBox30));
            casillas.Add(new Casilla(pictureBox31)); casillas.Add(new Casilla(pictureBox32)); casillas.Add(new Casilla(pictureBox33));
            casillas.Add(new Casilla(pictureBox34)); casillas.Add(new Casilla(pictureBox35));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                productor.Abort();
                MessageBox.Show("Terminando Programa por ESC");
                this.Close();
            }
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxConsumidor_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = new Productor(casillas);
            c = new Consumidor(casillas);
            c.dormido = true;
            productor.Start();
        }

        void startProductor()
        {
            while (true)
            {
                Random random = new Random();
                numero = random.Next(3, 10);
                numero2 = random.Next(0, 100);
                if(numero2 % 2 == 0)
                {   //que se haga lo del productor
                    while(numero > 0)
                    {
                        if (!casillas[p.posicion].conProducto)
                        {
                            pictureBoxProductor.Location = new Point(casillas[p.posicion].pictureBox.Location.X, casillas[p.posicion].pictureBox.Location.Y - 66);
                            p.produce();
                            numero--;
                            numeroProductos++;
                        }
                        else
                        {
                            pictureBoxProductor.Location = new Point(718, 332);
                            Refresh();
                            Thread.Sleep(300);
                            break;
                        }
                    }
                    pictureBoxProductor.Location = new Point(718, 332);
                    Refresh();
                    Thread.Sleep(300);
                }
                else
                {   //que se haga lo del consumidor
                    while(numero > 0)
                    {
                        if (casillas[c.posicion].conProducto)
                        {
                            pictureBoxConsumidor.Location = new Point(casillas[c.posicion].pictureBox.Location.X, casillas[c.posicion].pictureBox.Location.Y);
                            c.consume();
                            numero--;
                            numeroProductos--;
                        }
                        else
                        {
                            pictureBoxConsumidor.Location = new Point(643, 356);
                            Refresh();
                            Thread.Sleep(300);
                            break;
                        }
                    }
                    pictureBoxConsumidor.Location = new Point(643, 356);
                    Refresh();
                    Thread.Sleep(300);
                }
            }
        }
    }
}
