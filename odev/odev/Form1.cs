using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class Secim : Form 
    {
        public Secim()
        {
            //BackColor = Color.Lime;
            //TransparencyKey = Color.Lime;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mod5 ModBes = new Mod5();
            ModBes.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mod7 ModYedi = new Mod7();
            ModYedi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
