using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hotel1
{
    public partial class ajchamber : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ZAIKAY;Integrated Security=True");
        SqlCommand cmd;
        int idh = 0;
        public ajchamber()
        {
            InitializeComponent();
        }

        private void ajchamber_Load(object sender, EventArgs e)
        {
            hotl();
          
        }

        private void hotl()
        {
            SqlDataAdapter adb = new SqlDataAdapter("select * from Hotel", con);

            DataTable dt = new DataTable();
            adb.Fill(dt);
            nomht.DataSource = dt;
            nomht.ValueMember = "HOT_ID";
            nomht.DisplayMember = "HOT_NOM";
        }

        private void ctg()
        {
            SqlDataAdapter adb = new SqlDataAdapter("select * from Categorie  ", con);

            DataTable dt = new DataTable();
            adb.Fill(dt);
            cbctego.DataSource = dt;
            cbctego.ValueMember = "CAT_ID";
            cbctego.DisplayMember = "DESIGNATION";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (idh != 0)
            {
               
                cmd = new SqlCommand("insert into Chambre(CHB_NUMERO,CHB_ETAGE,NBR_LITS,HOT_ID,CAT_ID) values(@chnum,@chetg,@nblit,@idh,@idct)", con);

                cmd.Parameters.AddWithValue("@chnum", textBox8.Text);
                cmd.Parameters.AddWithValue("@chetg", textBox4.Text);
                cmd.Parameters.AddWithValue("@nblit", textBox7.Text);

                cmd.Parameters.AddWithValue("@idh", idh);
                int ct = Convert.ToInt32(cbctego.SelectedValue);
                cmd.Parameters.AddWithValue("@idct", ct);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ajoute avec succes ....!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            idh = Convert.ToInt32(nomht.SelectedValue);
            ctg();
        }
    }
}
