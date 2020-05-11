using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        bool dondur = true;//true=X döndur ;false=O döndür
        int dondur_sayisi = 0;
        int sayac = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Geliştirici:Bilgisayar Mühendisi");//İnfo kısmını ekrana yazdırıyor.
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)//Uygulamadan çıkışı sağlıyor.
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)//Butonları tek click de toplayıp basıldığında X veya O yazdırıyor.
        {
            Button b = (Button)sender;
            if (dondur)
            {
                b.Text = "X";
                oyuncu.Text = "O";
            }
            else
            {
                b.Text = "O";
                oyuncu.Text = "X";
            }
            dondur = !dondur;
            b.Enabled = false;
            dondur_sayisi++;//Beraberlik kontrolü için sayac görevi görüyor.
            KazananıKontrolEt();
        }
        private void KazananıKontrolEt()
        {
           bool KazanaKim = false;
            //yatay kontrol da eşleşmeleri kontrol ettirip kazananı belirliyor.
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                KazanaKim = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text)&&(!B1.Enabled))
                KazanaKim = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                KazanaKim = true;

            //dikey kontrol da eşleşmeleri kontrol ettirip kazananı belirliyor.
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                KazanaKim = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                KazanaKim = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                KazanaKim = true;

            //diyagonal kontrol da eşleşmeleri kontrol ettirip kazananı belirliyor.
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                KazanaKim = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                KazanaKim = true;
            


            if (KazanaKim)//Eşleşen sonuca göre kazananı ekrana yazdırıyor.
            {
                TekrarButton();
                string kazanan = "";
                if (dondur)
                    kazanan = "O";
                else
                    kazanan = "X";
                MessageBox.Show(kazanan + " kazandı");
            }
            else
            {
                if (dondur_sayisi == 9)//Eşleşme bulunamazsa ve hamle sayısı sayacı 9 olursa beraberlik durumu oluşturuyor.
                    MessageBox.Show("Berabere kaldı.");
            }
        }
        private void TekrarButton()
        {
            try//Basılan butona tekrar basmasını engellemek ve oyun bitininde hamle yapmayı engellemek için kullanılan kod.
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            }
            catch { }
        }

        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)//Oyunu ve sayacı sıfırlıyor.
        {
            try
            {
                if (sayac % 2 == 0)//Burada her yeni oyunda sayac değişkenine çiftse X ile tek sayısı ise O ile başlatıyor.
                {
                    dondur = false;
                }
                else
                {
                    dondur = true;
                }
                dondur_sayisi = 0;
                sayac++;//Sayac bir artırılarak bir sonra ki oyun başlangıcında ki hamle geçişini sağlıyor.
                foreach (Control c in Controls)//Buttonları tekrar aktif edip içlerini temizleyip sıfırlıyor.
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    siradaki.Text = "Sıradaki Oyuncu:";
                }
            }
            catch { }
               
        }

        private void button1_Click(object sender, EventArgs e)//sıradaki oyuncu geçiş göstergesi
        {
            try
            {
               
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    siradaki.Text = "Sıradaki Oyuncu:";

                }
            }
            catch { }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void siradaki_Click(object sender, EventArgs e)
        {

        }
    }
} 
