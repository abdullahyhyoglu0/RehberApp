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

namespace RehberApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-8S2D0E3\SQLEXPRESS01;Initial Catalog=rehber;Integrated Security=True;Encrypt=False");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtad.Text = "";
                txtsoyad.Text = "";
                maskmail.Text = "";
                msktel.Text = "";
                sql.Open();
                SqlCommand cmd = new SqlCommand("delete from TBLREHBER where ID=@P1", sql);
                cmd.Parameters.AddWithValue("@p1", txtıd.Text);
                cmd.ExecuteNonQuery();
                sql.Close();
                listele();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("İşlem Gerçekleşemedi");

            }
        }
        void listele()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from TBLREHBER", sql);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // DataGridView'in sütunlarını veriye sığdır
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Open();
                SqlCommand CMD = new SqlCommand("insert into TBLREHBER(ID,AD,SOYAD,TELEFON,gmail) values (@p1,@p2,@p3,@p4,@p5)", sql);
                if (txtıd.Text == "" && txtad.Text == "" && txtsoyad.Text == "")
                {
                    MessageBox.Show("bütün bilgileri girin");
                    sql.Close();
                }
                else
                {
                    CMD.Parameters.AddWithValue("@p1", txtıd.Text);
                    CMD.Parameters.AddWithValue("@p2", txtad.Text);
                    CMD.Parameters.AddWithValue("@p3", txtsoyad.Text);
                    CMD.Parameters.AddWithValue("@p4", msktel.Text);
                    CMD.Parameters.AddWithValue("@p5", maskmail.Text);
                    CMD.ExecuteNonQuery();
                    listele();
                    MessageBox.Show("Kayıt başarıyla eklendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                sql.Close();
            }
        }

        public void buttontemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void buttongüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Open();
                SqlCommand nw = new SqlCommand("update TBLREHBER set AD=@P2,SOYAD=@P3,gmail=@P4,TELEFON=@P5 WHERE ID=@P1", sql);
                nw.Parameters.AddWithValue("@p1", txtıd.Text);
                nw.Parameters.AddWithValue("@p2", txtad.Text);
                nw.Parameters.AddWithValue("@p3", txtsoyad.Text);
                nw.Parameters.AddWithValue("@p4", maskmail.Text);
                nw.Parameters.AddWithValue("@p5", msktel.Text);
                nw.ExecuteNonQuery();
                listele();
                MessageBox.Show("Veriler başarıyla Güncellendi");
                temizle();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("VERİ GÜNCELLENEMEDİ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
        
        
        }
        void temizle()
        {
            txtıd.Text = "";
            txtsoyad.Text = "";
            txtad.Text = "";
            maskmail.Text = "";
            msktel.Text = "";
        }

        private void msktel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }
    
