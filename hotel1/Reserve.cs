using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotel1
{
    public partial class Reserve : Form
    {
        int  idho, hett;
        public Reserve(int idho)
        {
            InitializeComponent();
            
           
            this.idho = idho;
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Reserve_Load(object sender, EventArgs e)
        {
           

            
            dtfin.Value = DateTime.Now.AddDays(+1);
            
        }
        private void afchhot(int idh)
        {


        }
    }
}
