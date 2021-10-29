using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProductorConsumidor
{
    class Casilla
    {
        public PictureBox pictureBox;
        public bool conProducto;
        public Casilla(PictureBox _pictureBox)
        {
            pictureBox = _pictureBox;
        }
    }
}
