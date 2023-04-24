using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.EntitySql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace hotel1
{
    public partial class addho : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ZAIKAY;Integrated Security=True");
        SqlCommand cmd;
        int idh = 0;
        string urlim="";
        public addho()
        {
            InitializeComponent();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "image files (*.jpg)|*.jpg|(*.png)|*.png|(*.gif)|*.gif";
          
           
            op.ShowDialog();
            urlim = op.FileName.ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation= urlim;
            


            }

        private void button1_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("insert into Hotel(HOT_NOM,HOT_SITUATION,HOT_NBR_ETOILES,Imageho) values(@nom,@adre,@eto,@imgf)", con);
            Byte[] imge = null;
            FileStream fs = new FileStream(urlim, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imge = br.ReadBytes((int)fs.Length);

            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@adre", textBox2.Text);
            cmd.Parameters.AddWithValue("@eto", textBox3.Text);
            cmd.Parameters.AddWithValue("@imgf", imge);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ajoute avec succes ....!");
        }

        private void addho_Load(object sender, EventArgs e)
        {
            string reqt = "select max(HOT_ID) from Hotel ";

            cmd = new SqlCommand(reqt, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                idh = Convert.ToInt32(rd[0].ToString());
            }
                con.Close();
       
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
      

       

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
