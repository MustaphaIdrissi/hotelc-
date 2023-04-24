using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace hotel1
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ajouteHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addho ajh = new addho();
            ajh.MdiParent = this;
            ajh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ajh.ShowIcon = false;
            ajh.Show();
        }

        private void aJOUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ajchamber ajch = new ajchamber();
            ajch.MdiParent = this;
            ajch.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ajch.ShowIcon = false;
            ajch.Show();
        }

        private void index_Load(object sender, EventArgs e)
        {


            panel3.Controls.Clear();
            Home fhd = new Home();
            fhd.TopLevel = false;
            panel3.Controls.Add(fhd);
            fhd.FormBorderStyle= System.Windows.Forms.FormBorderStyle.None;
            fhd.AutoScroll = true;
            
            fhd.Show();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
    }
}
