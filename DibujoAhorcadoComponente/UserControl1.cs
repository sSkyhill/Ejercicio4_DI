using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DibujoAhorcadoComponente
{
    [DefaultEvent("CambiaError")]
    [DefaultProperty("Errores")]
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();


        }

        private int errores;
        [Category("Mis propiedades")]
        [Description("Número de errores cometidos")]
        public int Errores
        {
            get { return errores; }
            set
            {
                if (value == 9)
                {
                    OnAhorcado(this, EventArgs.Empty);
                }
                errores = value;
                OnCambiaError(this, EventArgs.Empty);
                Refresh();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen lapiz = new Pen(Color.Black, 3);
            int altura = this.Height;
            int anchura = this.Width;
            g.DrawLine(lapiz, (float)(anchura * 0.3), (float)(altura * 0.9), (float)(anchura * 0.6), (float)(altura * 0.9));
            bool cambio = false;

            if (errores >= 1)
            {
                g.DrawLine(lapiz, (float)(anchura * 0.45), (float)(altura * 0.9), (float)(anchura * 0.45), (float)(altura * 0.2));

            }
            if (errores >= 2)
            {
                g.DrawLine(lapiz, (float)(anchura * 0.45), (float)(altura * 0.2), (float)(anchura * 0.8), (float)(altura * 0.2));

            }
            if (errores >= 3)
            {

                g.DrawLine(lapiz, (float)(anchura * 0.8), (float)(altura * 0.2), (float)(anchura * 0.8), (float)(altura * 0.3));


            }
            if (errores >= 4)
            {

                g.DrawEllipse(lapiz, (float)(anchura * 0.75), (float)(altura * 0.3), (float)(anchura * 0.1), (float)(altura * 0.1));

            }
            if (errores >= 5)
            {

                g.DrawLine(lapiz, (float)(anchura * 0.8), (float)(altura * 0.4), (float)(anchura * 0.8), (float)(altura * 0.7));

            }
            if (errores >= 6)
            {

                g.DrawLine(lapiz, (float)(anchura * 0.9), (float)(altura * 0.47), (float)(anchura * 0.8), (float)(altura * 0.47));

            }
            if (errores >= 7)
            {

                g.DrawLine(lapiz, (float)(anchura * 0.8), (float)(altura * 0.47), (float)(anchura * 0.7), (float)(altura * 0.47));

            }
            if (errores >= 8)
            {

                g.DrawLine(lapiz, (float)(anchura * 0.8), (float)(altura * 0.7), (float)(anchura * 0.9), (float)(altura * 0.8));

            }
            if (errores >= 9)
            {

                g.DrawLine(lapiz, (float)(anchura * 0.8), (float)(altura * 0.7), (float)(anchura * 0.7), (float)(altura * 0.8));
                OnAhorcado(this, e);
            }

            lapiz.Dispose();





        }


        [Category("Mis eventos")]
        [Description("Se produce cuando se cambia el número de errores")]
        public event EventHandler CambiaError;
        protected virtual void OnCambiaError(object sender, EventArgs e)
        {
            CambiaError?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Cambió");
        }

        [Category("Mis eventos")]
        [Description("Se produce cuando el número de errores llega a 9 (cuando el jugador pierde :C )")]
        public event EventHandler Ahorcado;

        protected virtual void OnAhorcado(object sender, EventArgs e)
        {
            Ahorcado?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Perdiste");
        }


    }
}
