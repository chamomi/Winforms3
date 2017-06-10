using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms3
{
    public partial class Form1 : Form
    {
        public static int n = 20; //numbers of floating circles
        public static List<Form> recs = new List<Form>(n);
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
            for(int i=0;i<n;i++)
            {
                Form f = new Rect(this);
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
            if ((recs.Count > 1))
            {
                recs[recs.Count - 1].Close();
                recs.RemoveAt(recs.Count - 1);
                return false;
            }
            else return true;
        }
    }
}
