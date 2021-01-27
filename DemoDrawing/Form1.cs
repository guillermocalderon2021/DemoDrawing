using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoDrawing
{
    public partial class Form1 : Form
    {
        Graphics area;
       
        public Form1()
        {
            InitializeComponent();
            area = panel1.CreateGraphics();
            String[] colores = Enum.GetNames(typeof(System.Drawing.KnownColor));
            cmbColores.Items.AddRange(colores);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Point punto = panel1.PointToClient(Cursor.Position);
            nudX.Value = punto.X;
            nudY.Value = punto.Y;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16( nudX.Value);
            int y = Convert.ToInt16(nudY.Value);
            int size = Convert.ToInt16(nudTamano.Value);
            int opcion = cmbFigura.SelectedIndex;
            Color color = Color.FromName(cmbColores.SelectedItem.ToString());
            Pen lapiz = new Pen(color, 5);
            SolidBrush pincel = new SolidBrush(color);



            switch (opcion)
            {
                case 0: // Circulo
                    area.DrawEllipse(lapiz, x - size / 2, y - size / 2, size, size);
                    area.FillEllipse(pincel, x - size / 2, y - size / 2, size, size);
                    break;
                case 1: // Cuadrado 
                    area.DrawRectangle(lapiz, x, y, size, size);
                    area.FillRectangle(pincel, x, y, size, size);
                    break;
                case 2: //linea
                    area.DrawLine(lapiz, new Point(x, y), new Point(x + size, y));
                    break;

                default:
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbColores.SelectedIndex = 0;
            cmbFigura.SelectedIndex = 0;
        }
    }
}
