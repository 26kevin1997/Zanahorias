using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace ProductorConsumidor
{
    class Consumidor
    {
        public bool dormido;
        public int posicion;
        List<Casilla> casillas;
        public Consumidor(List<Casilla> _casillas)
        {
            casillas = _casillas;
        }
        public void consume()
        {
            casillas[posicion].pictureBox.Image = null;
            casillas[posicion].conProducto = false;
            
            if (posicion == 34)
                posicion = 0;
            else
                posicion = posicion + 1;
            Thread.Sleep(300);

        } 
    }
}
