using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G191210053
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Yiyecekler");
            comboBox1.Items.Add("Icecekler");
            comboBox1.Items.Add("Faaliyetler");
            comboBox1.Items.Add("Sanayi");
            comboBox1.Items.Add("Tarım");

            comboBox2.Items.Add("Barajlar");
            comboBox2.Items.Add("Faaliyetler");
            comboBox2.Items.Add("Icecekler");
            comboBox2.Items.Add("Sanayi");
            comboBox2.Items.Add("Tarım");
            comboBox2.Items.Add("Şehirler");
            comboBox2.Items.Add("Ülkeler");
            comboBox2.Items.Add("Yiyecekler");

            label6.Text = "";

           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Yiyecekler")
            {
                yiyeceklistele();
            }

            else if (comboBox1.Text == "Icecekler")
            {
                iceceklistele();
            }

            else if (comboBox1.Text == "Faaliyetler")
            {
                faaliyetlistele();
            }

            else if (comboBox1.Text == "Sanayi")
            {
                sanayilistele();
            }

            else if (comboBox1.Text == "Tarım")
            {
                tarimlistele();
            }

            if (comboBox1.Text == "Faaliyetler")
            {
                label4.Text = "Faaliyet Süresi";
                label4.Enabled = true;
                textBox3.Enabled = true;

            }

            if (comboBox1.Text == "Yiyecekler" || comboBox1.Text == "Icecekler")
            {
                label4.Text = "Fiyatı: ";
                label4.Enabled = true;
                textBox3.Enabled = true;
            }

            if (comboBox1.Text == "Sanayi" || comboBox1.Text == "Tarım")
            {
                label4.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server= localHost;port=5432; Database= G191210053; user ID= postgres; password=123456");

        void yiyeceklistele()
        {
            string sorgu = "select * from yiyeceklistesi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        void iceceklistele()
        {
            string sorgu = "select * from iceceklistesi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        void faaliyetlistele()
        {
            string sorgu = "select * from faaliyetlistesi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        void sanayilistele()
        {
            string sorgu = "select * from sanayilistesi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        void tarimlistele()
        {
            string sorgu = "select * from tarimlistesi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Yiyecekler")
            {
               
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("insert into yiyeceklistesi(yiyecekno, yiyecekadi, yiyecekfiyati,yiyecekharcanansu) values (@p1, @p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
                    komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    yiyeceklistele();
                }


            }

            else if (comboBox1.Text == "Icecekler")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("insert into iceceklistesi(icecekno, icecekadi, icecekfiyati,icecekharcanansu) values (@p1, @p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
                    komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    iceceklistele();
                }

            }

            else if (comboBox1.Text == "Faaliyetler")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("insert into faaliyetlistesi(faaliyetno, faaliyetadi, faaliyetsuresi,faaliyetharcanansu) values (@p1, @p2,@p3,@p4)", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
                    komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    faaliyetlistele();
                }
            }

            else if (comboBox1.Text == "Sanayi")
            {
                if (textBox1.Text !="" && textBox2.Text != "" && textBox4.Text != "") { 
                     baglanti.Open();
                     NpgsqlCommand komut = new NpgsqlCommand("insert into sanayilistesi(sanayino, sanayiadi, sanayiharcanansu) values (@p1, @p2,@p3)", baglanti);
                     komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                     komut.Parameters.AddWithValue("@p2", textBox2.Text);
                     komut.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
                     komut.ExecuteNonQuery();
                     baglanti.Close();
                    sanayilistele();
                }
            }

            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("insert into tarimlistesi(tarimno, tarimadi, tarimharcanansu) values (@p1, @p2,@p3)", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    tarimlistele();
                }

            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
          
            if (comboBox1.Text == "Yiyecekler")
            {

                if (textBox1.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut2 = new NpgsqlCommand("Delete From yiyeceklistesi where yiyecekno =@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    yiyeceklistele();
                }


            }

            else if (comboBox1.Text == "Icecekler")
            {
                if (textBox1.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut2 = new NpgsqlCommand("Delete From iceceklistesi where icecekno =@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    iceceklistele();
                }

            }

            else if (comboBox1.Text == "Faaliyetler")
            {
                if (textBox1.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut2 = new NpgsqlCommand("Delete From faaliyetlistesi where faaliyetno=@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    faaliyetlistele();
                }
            }

            else if (comboBox1.Text == "Sanayi")
            {
                if (textBox1.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut2 = new NpgsqlCommand("Delete From sanayilistesi where sanayino =@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    sanayilistele();
                }
            }

            else
            {
                if (textBox1.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut2 = new NpgsqlCommand("Delete From tarimlistesi where tarimno =@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    tarimlistele();
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

           
            if (comboBox1.Text == "Yiyecekler")
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("Update yiyeceklistesi set yiyecekadi=@p2, yiyecekfiyati=@p3, yiyecekharcanansu=@p4 where yiyecekno=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
                    komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    yiyeceklistele();
                }


            }

            else if (comboBox1.Text == "Icecekler")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("Update iceceklistesi set icecekadi=@p2, icecekfiyati=@p3, icecekharcanansu=@p4 where icecekno=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
                    komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    iceceklistele();
                }

            }

            else if (comboBox1.Text == "Faaliyetler")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("Update faaliyetlistesi set faaliyetadi=@p2, faaliyetsuresi=@p3, faaliyetharcanansu=@p4 where faaliyetno=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
                    komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    faaliyetlistele();
                }
            }

            else if (comboBox1.Text == "Sanayi")
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("Update sanayilistesi set sanayiadi=@p2, sanayiharcanansu=@p3 where sanayino=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    sanayilistele();
                }
            }

            else
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("Update tarimlistesi set tarimadi=@p2, tarimharcanansu=@p3 where tarimno=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komut.Parameters.AddWithValue("@p2", textBox2.Text);
                    komut.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    tarimlistele();
                }

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                if (textBox5.Text != "")
                {
                    label9.Text = "";
                    if (comboBox2.Text == "Barajlar")
                    {
                        string sorgu1 = "Select * From baraj where barajno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sorgu1, baglanti);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        dataGridView2.DataSource = ds1.Tables[0];
                    }

                    else if (comboBox2.Text == "Faaliyetler")
                    {
                        string sorgu2 = "Select * From faaliyetlistesi where faaliyetno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dataGridView2.DataSource = ds2.Tables[0];
                    }

                    else if (comboBox2.Text == "Icecekler")
                    {
                        string sorgu3 = "Select * From iceceklistesi where icecekno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        dataGridView2.DataSource = ds3.Tables[0];
                    }

                    else if (comboBox2.Text == "Sanayi")
                    {
                        string sorgu4 = "Select * From sanayilistesi where sanayino='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, baglanti);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        dataGridView2.DataSource = ds4.Tables[0];
                    }

                    else if (comboBox2.Text == "Tarım")
                    {
                        string sorgu5 = "Select * From tarimlistesi where tarimno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, baglanti);
                        DataSet ds5 = new DataSet();
                        da5.Fill(ds5);
                        dataGridView2.DataSource = ds5.Tables[0];
                    }

                    else if (comboBox2.Text == "Şehirler")
                    {
                        string sorgu6 = "Select * From sehir where sehirno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu6, baglanti);
                        DataSet ds6 = new DataSet();
                        da.Fill(ds6);
                        dataGridView2.DataSource = ds6.Tables[0];
                    }

                    else if (comboBox2.Text == "Ülkeler")
                    {
                        string sorgu7 = "Select * From ulke where ulkeno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(sorgu7, baglanti);
                        DataSet ds7 = new DataSet();
                        da7.Fill(ds7);
                        dataGridView2.DataSource = ds7.Tables[0];
                    }

                    else if (comboBox2.Text == "Yiyecekler")
                    {
                        string sorgu8 = "Select * From yiyeceklistesi where yiyecekno='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(sorgu8, baglanti);
                        DataSet ds8 = new DataSet();
                        da8.Fill(ds8);
                        dataGridView2.DataSource = ds8.Tables[0];
                    }

                }

                else
                {
                    label9.Text = " Aranacak veri giriniz..!! ";
                }

            }


            else if (radioButton2.Checked)
            {
                if (textBox5.Text != "")
                {
                    label9.Text = "";
                    if (comboBox2.Text == "Barajlar")
                    {
                        string sorgu1 = "Select * From baraj where barajadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sorgu1, baglanti);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        dataGridView2.DataSource = ds1.Tables[0];
                    }

                    else if (comboBox2.Text == "Faaliyetler")
                    {
                        string sorgu2 = "Select * From faaliyetlistesi where faaliyetadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dataGridView2.DataSource = ds2.Tables[0];
                    }

                    else if (comboBox2.Text == "Icecekler")
                    {
                        string sorgu3 = "Select * From iceceklistesi where icecekadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
                        DataSet ds3 = new DataSet();
                        da3.Fill(ds3);
                        dataGridView2.DataSource = ds3.Tables[0];
                    }

                    else if (comboBox2.Text == "Sanayi")
                    {
                        string sorgu4 = "Select * From sanayilistesi where sanayiadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, baglanti);
                        DataSet ds4 = new DataSet();
                        da4.Fill(ds4);
                        dataGridView2.DataSource = ds4.Tables[0];
                    }

                    else if (comboBox2.Text == "Tarım")
                    {
                        string sorgu5 = "Select * From tarimlistesi where tarimadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, baglanti);
                        DataSet ds5 = new DataSet();
                        da5.Fill(ds5);
                        dataGridView2.DataSource = ds5.Tables[0];
                    }

                    else if (comboBox2.Text == "Şehirler")
                    {
                        string sorgu6 = "Select * From sehir where sehiradi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu6, baglanti);
                        DataSet ds6 = new DataSet();
                        da.Fill(ds6);
                        dataGridView2.DataSource = ds6.Tables[0];
                    }

                    else if (comboBox2.Text == "Ülkeler")
                    {
                        string sorgu7 = "Select * From ulke where ulkeadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(sorgu7, baglanti);
                        DataSet ds7 = new DataSet();
                        da7.Fill(ds7);
                        dataGridView2.DataSource = ds7.Tables[0];
                    }

                    else if (comboBox2.Text == "Yiyecekler")
                    {
                        string sorgu8 = "Select * From yiyeceklistesi where yiyecekadi='" + textBox5.Text + "'";
                        NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(sorgu8, baglanti);
                        DataSet ds8 = new DataSet();
                        da8.Fill(ds8);
                        dataGridView2.DataSource = ds8.Tables[0];
                    }

                }

                else
                {
                    label9.Text = " Aranacak veri giriniz..!! ";
                }

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Aranan Numara";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Aranan Ad";
        }
  
    }
}
