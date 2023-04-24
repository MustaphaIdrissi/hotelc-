using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using Image = System.Net.Mime.MediaTypeNames.Image;

namespace hotel1
{
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ZAIKAY;Integrated Security=True");
        SqlCommand cmd;
        int xx = 0, yy = 12, l = 0, yl = 0;
        int i = 0, max = 3, j = 0, x = 352, y = 250,witd,hett;

        private void flwhome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        string rqt = "select * from Hotel";

        private void button1_Click(object sender, EventArgs e)
        {
            string red="";
            int nb=0;
            rqt = "";
            rqt += "select * from Hotel where ";
            if ((nomhote.Text == "") && (comboBox1.SelectedIndex != 0) && (comboBox2.SelectedIndex == 0))
            {

                red = comboBox1.SelectedItem.ToString();

                rqt+= " HOT_SITUATION like'%"+ red + "%'";


            }
            else if ((nomhote.Text == null) && (comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex != 0))
            {
                nb =Convert.ToInt32(comboBox2.SelectedItem.ToString());

                rqt += " HOT_NBR_ETOILES ="+ nb;

              
              
            }else 
            if ((nomhote.Text != "") && (comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex == 0))
            {
                
                rqt += " HOT_NOM like'%" + nomhote.Text + "%'";

               
            }
            
            else if ((nomhote.Text == "") && (comboBox1.SelectedIndex != 0) && (comboBox2.SelectedIndex != 0))
            {

                red = comboBox1.SelectedItem.ToString();
                nb = Convert.ToInt32(comboBox2.SelectedItem.ToString());



                rqt += " HOT_SITUATION like'%" + red + "%' and HOT_NBR_ETOILES =" + nb  ;
            }
            else if ((nomhote.Text != "") && (comboBox1.SelectedIndex == 0) && (comboBox2.SelectedIndex != 0))
            {

               
                nb = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                


                rqt += " HOT_NBR_ETOILES =" + nb + " and HOT_NOM like'%" + nomhote.Text + "%'";
            }
            else if ((nomhote.Text != "") && (comboBox1.SelectedIndex != 0) && (comboBox2.SelectedIndex == 0))
            {

                red = comboBox1.SelectedItem.ToString();
               



                rqt += " HOT_SITUATION like'%" + red + "%' and HOT_NOM like'%" + nomhote.Text + "%'";
            }
            else if ((nomhote.Text != "") && (comboBox1.SelectedIndex != 0) && (comboBox2.SelectedIndex != 0))
            {

                red = comboBox1.SelectedItem.ToString();
                nb = Convert.ToInt32(comboBox2.SelectedIndex.ToString());


               
                rqt += " HOT_SITUATION like'%" + red + "%' and HOT_NBR_ETOILES =" + nb + " and HOT_NOM like'%" + nomhote.Text + "%'";
             
            }
            else
            {
                rqt = "select * from Hotel";
            }
                affifageh(rqt);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public Home()
        {
            InitializeComponent();
         
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void Home_Load(object sender, EventArgs e)
        {


            rqt = "select * from Hotel";
            affifageh(rqt);
        }
        public void affifageh(string rqt)
        {


            flwhome.Controls.Clear();
         
          

            cmd = new SqlCommand(rqt, con);
           SqlCommand cmdd = new SqlCommand(rqt, con);
           
          
                                       
           

         
            
            
            
            
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
           
            if (rd.HasRows) { 
            while (rd.Read())
                {
                    string urlim = "";
                    Button button1 = new Button();

                if (i <= max)
                {

                    l = xx + l + i;
                    xx = x;
                    i++;
                }

                button1.Location = new Point(l, yl);
                  
                    button1.Font = new System.Drawing.Font("arial", 16f, FontStyle.Bold, GraphicsUnit.Point);
                button1.ImageAlign = ContentAlignment.MiddleRight;
                button1.TextAlign = ContentAlignment.BottomCenter;
                button1.Size = new Size(x, y);
                button1.Text = rd[1].ToString();
                button1.ForeColor = Color.Black;
                    button1.Name = rd[0].ToString();
                button1.Padding = new Padding(0,0,0,8);

                    // byte[] MyImg = (byte[])rd[4];

                  byte[] MyImg = ((byte[])rd[4]);





                    if (MyImg != null)
                    {


                        MemoryStream ms = new MemoryStream(MyImg);
                        button1.BackgroundImage = System.Drawing.Image.FromStream(ms);

                    


                    }
                    else
                    {
                       // button1.BackgroundImage = Image.FromFile(@"C:\Users\StevenStart\source\repos\hotel1\hotel1\image\imgdefault.png");
                    }
                    button1.BackgroundImageLayout = ImageLayout.Stretch;
                button1.Click += new EventHandler(DynamicButton_Click);
                flwhome.Controls.Add(button1);

                if (i >= max)
                {
                    l = 0;
                    i = 0;
                    xx = 0;

                    yl = y + yl + yy;

                }
            }
           
            }
            else
            {
                Label lb = new Label();
                lb.Text = "Aucun Résultat...!";
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Font = new System.Drawing.Font("arial", 14f, FontStyle.Bold, GraphicsUnit.Point);
                lb.Location= new Point(1000, 1000);
                lb.Size = new Size(200, 46);
                lb.ForeColor = Color.Red;
                flwhome.Controls.Add(lb);

            }
            con.Close();
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
           

            int tr = Int32.Parse(((Button)sender).Name);
            
         

            Reserve objForm = new Reserve(tr);
            objForm.TopLevel = true;
           
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            objForm.Dock = DockStyle.Fill;

            objForm.Show();

        }

    }
}
