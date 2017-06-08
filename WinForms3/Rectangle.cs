using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms3
{
    public partial class Rect : Form
    {
        Color[] colors = { Color.Gold, Color.Coral, Color.Turquoise, Color.Crimson , Color.PowderBlue, Color.Indigo, Color.DarkCyan};
        int velocity;
        private readonly Random r = new Random();
        int changex, changey;
        public Rect()
        {
            InitializeComponent();
        }

        private void Rectangle_Load(object sender, EventArgs e)
        {
            Location = new Point(r.Next(0, Screen.PrimaryScreen.Bounds.Width-120), r.Next(0, Screen.PrimaryScreen.Bounds.Height-172));
            Thread.Sleep(20);
            BackColor = colors[r.Next(0, 7)];
            changey = r.Next(-20, 20);
            Thread.Sleep(10);
            velocity = r.Next(20,30);
            changex = r.Next(-20, 20);
            
            timer1.Interval = velocity;
            timer1.Start();
        }

        int click_counter = 0;

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
            }
            else
            {
                this.Close();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (((this.Location.X + changex + 120) >= Screen.PrimaryScreen.Bounds.Width)||((this.Location.X + changex)<=0)) changex *= -1;
            if (((this.Location.Y + changey + 172) >= Screen.PrimaryScreen.Bounds.Height)||((this.Location.Y + changey)<=0)) changey *= -1;

            Location = new Point(this.Location.X + changex, this.Location.Y + changey);
        }
    }
}
