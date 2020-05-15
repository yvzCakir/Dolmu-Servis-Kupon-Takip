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
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }
       

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'servisDataSet.TBLSERVİS' table. You can move, or remove it, as needed.
            this.tBLSERVİSTableAdapter.Fill(this.servisDataSet.TBLSERVİS);


                  

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P9F8OIM\SQLEXPRESS;Initial Catalog=Servis;Integrated Security=True");
            DataTable dt = new DataTable();
            string sql = "Select  * from TBLSERVİS where TARIH BETWEEN @tarih1 and @tarih2";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            da.SelectCommand.Parameters.AddWithValue("@tarih1", dateTimePicker1.Value);
            da.SelectCommand.Parameters.AddWithValue("@tarih2", dateTimePicker2.Value);
            baglanti.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

       



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
            uyg.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                myRange.Value2 = dataGridView1.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = dataGridView1[i, j].Value;

                }
            }

        }
    }
}
