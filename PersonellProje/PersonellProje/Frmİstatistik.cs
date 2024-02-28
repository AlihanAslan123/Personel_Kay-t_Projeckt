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

namespace PersonellProje
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-4PDHGHB\\SQLEXPRESS;Initial Catalog=PersonelVeriTabanı;Integrated Security=True;Encrypt=False");

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read()) 
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            // Evli Personel Sayısı Bulma
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label4.Text = dr2[0].ToString();
            }
            baglanti.Close();

            // Bekar Personel Sayısı Bulma
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel Where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read()) 
            {
                label6.Text = dr3[0].ToString();
            }
            baglanti.Close();

            // Şehir İstatistiği bulma
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Count (distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read()) 
            {
                label8.Text = dr4[0].ToString();
            }
            baglanti.Close();

            // Toplam Maaş Bulma
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read()) 
            {
                label9.Text = dr5[0].ToString();
            }
            baglanti.Close();

            // Ortalama Maaş Bulma
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                label11.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
