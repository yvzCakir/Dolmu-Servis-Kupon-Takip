using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Servis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P9F8OIM\SQLEXPRESS;Initial Catalog=Servis;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CmbPlaka.Text == " " || CmbGirisCikis.Text == " ") MessageBox.Show("Boş ALAN !");
            

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into TBLSERVİS (PLAKA,KARTBILGISI,TARIH,GİRİSCİKİS) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", CmbPlaka.Text);
            komut.Parameters.AddWithValue("@p2", TxtKart.Text);
            komut.Parameters.AddWithValue("@p3", LblTarih.Text);
            komut.Parameters.AddWithValue("@p4", CmbGirisCikis.Text);
                  

            komut.ExecuteNonQuery();
            baglanti.Close();
           
            MessageBox.Show("Giriş Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtKart.Clear();
            
          

        }     

        

         private void timer1_Tick(object sender, EventArgs e)
        {
            LblTarih.Text = DateTime.Now.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRapor fr = new FrmRapor();
            {
                fr.Show();
            }
        }
    }
    }
    
 
    
 
    

