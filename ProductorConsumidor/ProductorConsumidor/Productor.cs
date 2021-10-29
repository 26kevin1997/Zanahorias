using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
namespace ProductorConsumidor
{
    class Productor
    {
        public bool dormido;
        public int posicion;
        List<Casilla> casillas;
        public Productor(List<Casilla> _casillas)
        {
            casillas = _casillas;   
        }
        public void produce()
        {
            
            if (!casillas[posicion].conProducto)
            {
                casillas[posicion].pictureBox.Image = Image.FromFile("zanahoria.png");
                casillas[posicion].conProducto = true;
                casillas[posicion].pictureBox.Refresh();

                if (posicion == 34)
                    posicion = 0;
                else
                    posicion = posicion + 1;

                Thread.Sleep(300);
            }

        }
        
    }
}
