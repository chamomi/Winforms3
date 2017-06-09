using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms3
{
    public partial class Rect : Form
    {
        GraphicsPath wantedshape = new GraphicsPath();
        Color[] colors = { Color.Gold, Color.Coral, Color.Turquoise, Color.Crimson , Color.PowderBlue, Color.Indigo, Color.DarkCyan};
        private readonly Random r = new Random();
        int click_counter = 0, i;
        int changex, changey;
        int changes = 10;

        public Rect(int n)
        {
            InitializeComponent();
            i = n;
        }

        private void Rectangle_Load(object sender, EventArgs e)
        {
            int wid = r.Next(100, 150);
            this.Width = wid;
            this.Height = wid;
            wantedshape.AddEllipse(0, 0, this.Width, this.Width);            
            this.Region = new Region(wantedshape);

            Location = new Point(r.Next(0, Screen.PrimaryScreen.Bounds.Width-this.Width), r.Next(0, Screen.PrimaryScreen.Bounds.Height-this.Height));
            Thread.Sleep(20);
            BackColor = colors[r.Next(0, 7)];
            changey = r.Next(-20, 20);
            Thread.Sleep(10);
            changex = r.Next(-20, 20);
            
            timer1.Interval = r.Next(30, 40);
            timer1.Start();

            timer2.Interval = r.Next(60,80);
            timer2.Start();
        }

        private void form_Click(object sender, MouseEventArgs e)
        {
            click_counter++;

            if (click_counter == 1)
            {
                this.Opacity = .5;
            }
            else if (click_counter == 2)
            {
                timer1.Stop();
                timer2.Stop();
            }
            else
            {
                try
                {
                    Form1.recs.RemoveAt(i - 1);
                    this.Close();
                }
                catch (ArgumentOutOfRangeException) { this.Close(); }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((this.Width >= this.MaximumSize.Width) || (this.Width <= this.MinimumSize.Width)) changes *= -1;
            this.Width += changes;
            this.Height += changes;

            wantedshape.Reset();
            wantedshape.AddEllipse(0, 0, this.Width, this.Width);
            this.Region = new Region(wantedshape);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (((this.Location.X + changex + this.Width) >= Screen.PrimaryScreen.Bounds.Width)||((this.Location.X + changex)<=0)) changex *= -1;
            if (((this.Location.Y + changey + this.Height) >= Screen.PrimaryScreen.Bounds.Height)||((this.Location.Y + changey)<=0)) changey *= -1;

            Location = new Point(this.Location.X + changex, this.Location.Y + changey);
        }
    }
}
