using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms3
{
    public partial class Form1 : Form
    {
        List<Form> recs = new List<Form>(20);
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
            for(int i=0;i<20;i++)
            {
                Form f = new Rect();
                recs.Add(f);
                f.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
                e.Cancel = true;
        }
        public bool CloseCancel()
        {
            if ((recs.Count - 1 >= 0))
            {
                recs[recs.Count - 1].Close();
                recs.RemoveAt(recs.Count - 1);
                return false;
            }
            else return true;
        }
    }
}
