using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace testOdev4
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection baglan = new SqlConnection("Data Source=GLORY\\GLORY;Initial Catalog=sorular;Integrated Security=True");
        private static int soruSayac = 0, dogruSayac = 0, yanlisSayac = 0, toplamSoru = 7, saniye = 60, dakika = 2,sureTOP=0;
        private static double hesap = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            bgClear();
            lbl_soru.Text = soruSayac.ToString();
            lbl_dogru.Text = dogruSayac.ToString();
            lbl_yanlis.Text = yanlisSayac.ToString();
            lbl_topSoru.Text = "/" + toplamSoru.ToString();
     

            if (toplamSoru == soruSayac)
            {
                btn_basla.Visible = false;
                Timer1.Enabled = false;
                Panel1.Enabled = false;
                btn_sonuc.Visible = true;
                btn_cevap.Enabled = false;
            }
        }
        void bgClear() { btn1.BackColor = Color.Empty; btn2.BackColor = Color.Empty; btn3.BackColor = Color.Empty; btn4.BackColor = Color.Empty; }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            saniye = saniye - 1;
            sureTOP += 1;
            lbl_saniye.Text = Convert.ToString(saniye);
            lbl_dakika.Text = Convert.ToString(dakika - 1);
            if (saniye == 0)
            {
                dakika = dakika - 1;
                lbl_dakika.Text = Convert.ToString(dakika);
                saniye = 60;
            }

            if (lbl_dakika.Text == "-1")
            {
                Timer1.Enabled = false;
                lbl_saniye.Text = "0";
                lbl_dakika.Text = "0";
                Panel1.Visible = false;
                btn_basla.Text = "süren doldu";
            }
        }

        protected void btn_cevap_Click(object sender, EventArgs e)
        {
            btn_basla.Enabled = true;
            if (btn1.Text==lbl_cevap.Text)
            {
                btn1.BackColor = Color.DarkCyan;
                Panel1.Enabled = false;
                yanlisSayac++;
            }
             if (btn2.Text == lbl_cevap.Text)
            {
                btn2.BackColor = Color.DarkCyan;
                Panel1.Enabled = false;
                yanlisSayac++;
            }
             if (btn3.Text == lbl_cevap.Text)
            {
                btn3.BackColor = Color.DarkCyan;
                Panel1.Enabled = false;
                yanlisSayac++;
            }
            if(btn4.Text==lbl_cevap.Text)
            {
                btn4.BackColor = Color.DarkCyan;
                Panel1.Enabled = false;
                yanlisSayac++;
            }
        }

        protected void btn_sonuc_Click(object sender, EventArgs e)
        {
            lbl_sonuc.Visible = true;
            hesap = ((Convert.ToDouble(toplamSoru) - Convert.ToDouble(yanlisSayac))) / (Convert.ToDouble(toplamSoru));
            hesap = Math.Round(hesap * 100);
            lbl_sonuc.Text = "Doğruluk oranı:%" + hesap.ToString();
            //
            lbl_sureTOP.Text = sureTOP.ToString()+" saniye içerisinde çözdünüz!";

        }

        protected void btn1_Click(object sender, EventArgs e)
        {

            btn_basla.Enabled = true;
            if (btn1.Text == lbl_cevap.Text)
            {
                dogruSayac++;
                lbl_dogru.Text = dogruSayac.ToString();
                btn1.BackColor = Color.Green;

            }
            else
            {
                yanlisSayac++;
                lbl_yanlis.Text = yanlisSayac.ToString();
                btn1.BackColor = Color.Red;
            }

        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            btn_basla.Enabled = true;
            if (btn2.Text == lbl_cevap.Text)
            {
                dogruSayac++;
                lbl_dogru.Text = dogruSayac.ToString();
                btn2.BackColor = Color.Green;
            }
            else
            {
                yanlisSayac++;
                lbl_yanlis.Text = yanlisSayac.ToString();
                btn2.BackColor = Color.Red;
            }
        }
        protected void btn3_Click(object sender, EventArgs e)
        {

            btn_basla.Enabled = true;
            if (btn3.Text == lbl_cevap.Text)
            {
                dogruSayac++;
                lbl_dogru.Text = dogruSayac.ToString();
                btn3.BackColor = Color.Green;
            }
            else
            {
                yanlisSayac++;
                lbl_yanlis.Text = yanlisSayac.ToString();
                btn3.BackColor = Color.Red;
            }
        }
        protected void btn4_Click(object sender, EventArgs e)
        {

            btn_basla.Enabled = true;
            if (btn4.Text == lbl_cevap.Text)
            {
                dogruSayac++;
                lbl_dogru.Text = dogruSayac.ToString();
                btn4.BackColor = Color.Green;
            }
            else
            {
                yanlisSayac++;
                lbl_yanlis.Text = yanlisSayac.ToString();
                btn4.BackColor = Color.Red;
            }

        }

        protected void btn_basla_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = true;
            TextBox1.Enabled = false;
            btn_basla.Enabled = false;
            Timer1.Enabled = true;
            soruSayac++;

            lbl_soru.Text = soruSayac.ToString();
            btn_basla.Text = "Sonraki";

            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM soru1 WHERE id=" + soruSayac, baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                btn1.Text = (oku["a"].ToString());
                btn2.Text = (oku["b"].ToString());
                btn3.Text = (oku["c"].ToString());
                btn4.Text = (oku["d"].ToString());
                TextBox1.Text = (oku["soru"].ToString());
                lbl_cevap.Text = (oku["cevap"].ToString());
            }
            baglan.Close();
        }

    }
}