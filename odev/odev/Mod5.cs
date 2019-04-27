using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace odev
{
    public partial class Mod5 : Form
    {        
        int[,] TasiyiciDizi;
        int[,] Tasiyici;
        int[,] SifreliDizi;
        int sinir, sinir2;
        int desifreliSatir, desifreliSutun;
        int satir, sutun;
        int yukseklik, genislik;
        int k = 0, a = 0, y = 0;
        bool kontrol = false;

        public Mod5()
        {
            InitializeComponent();
        }
        public int bestenOnlugaCevirBoyut(int[] dizi)
        {
            int onluk = dizi[4] + 5 * dizi[3] + 25 * dizi[2] + 125 * dizi[1] + 625 * dizi[0];
            return onluk;
        }
        public int bestenOnlugaCevirPiksel(int[] dizi)
        {
            int sonuc = dizi[3] + 5 * dizi[2] + 25 * dizi[1] + 125 * dizi[0];
            return sonuc;
        }
        public void sifreleMod5(int sonucMod, int indis)
        {
            sonucMod = (TasiyiciDizi[y, k] + 2 * TasiyiciDizi[y, k + 1]) % 5;
            switch (indis - sonucMod)
            {
                case 0:
                    k += 2;
                    if (k == sinir)
                    {
                        k = 0;
                        y++;
                    }
                    break;
                case 1:
                    if (TasiyiciDizi[y, k] != 255)
                    {
                        TasiyiciDizi[y, k]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 255 && TasiyiciDizi[y, k + 1] != 255)
                    {
                        TasiyiciDizi[y, k]--;
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 255 && TasiyiciDizi[y, k + 1] == 255)
                    {
                        TasiyiciDizi[y, k + 1] -= 2;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
                case 2:
                    if (TasiyiciDizi[y, k + 1] != 255)
                    {
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] != 0 && TasiyiciDizi[y, k + 1] == 255)
                    {
                        TasiyiciDizi[y, k]--;
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 0 && TasiyiciDizi[y, k + 1] == 255)
                    {
                        TasiyiciDizi[y, k] += 2;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
                case 3:
                    if (TasiyiciDizi[y, k] != 255 && TasiyiciDizi[y, k + 1] != 255)
                    {
                        TasiyiciDizi[y, k]++;
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] != 255 && TasiyiciDizi[y, k + 1] == 255)
                    {
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 255 && TasiyiciDizi[y, k + 1] != 0)
                    {
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 255 && TasiyiciDizi[y, k + 1] == 0)
                    {
                        TasiyiciDizi[y, k] -= 2;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 255 && TasiyiciDizi[y, k + 1] == 255)
                    {
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;

                case 4:
                    if (TasiyiciDizi[y, k] != 0)
                    {
                        TasiyiciDizi[y, k]--;

                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 0 && TasiyiciDizi[y, k + 1] != 0)
                    {
                        TasiyiciDizi[y, k]++;
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 0 && TasiyiciDizi[y, k + 1] == 0)
                    {
                        TasiyiciDizi[y, k + 1] += 2;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
                case -1:
                    if (TasiyiciDizi[y, k] != 0)
                    {
                        TasiyiciDizi[y, k]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 0)
                    {
                        TasiyiciDizi[y, k]++;
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
                case -2:
                    if (TasiyiciDizi[y, k + 1] != 0)
                    {
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k + 1] == 0)
                    {
                        TasiyiciDizi[y, k]++;
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
                case -3:
                    if (TasiyiciDizi[y, k] != 0 && TasiyiciDizi[y, k + 1] != 0)
                    {
                        TasiyiciDizi[y, k]--;
                        TasiyiciDizi[y, k + 1]--;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 0 && TasiyiciDizi[y, k + 1] != 255)
                    {
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k + 1] == 0)
                    {
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
                case -4:
                    if (TasiyiciDizi[y, k] != 255)
                    {
                        TasiyiciDizi[y, k]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    else if (TasiyiciDizi[y, k] == 255)
                    {
                        TasiyiciDizi[y, k]--;
                        TasiyiciDizi[y, k + 1]++;
                        k += 2;
                        if (k == sinir)
                        {
                            k = 0;
                            y++;
                        }
                    }
                    break;
            }
        }
        public string tabanCevirPiksel(int sayi)
        {
            int[] gecici = new int[4];
            int boyut = 3;
            if (sayi == 0)
            {
                for (int m = 0; m < 4; m++)
                    gecici[m] = 0;
            }
            else
            {
                while (sayi >= 1)
                {
                    gecici[boyut] = sayi % 5;
                    sayi /= 5;
                    boyut -= 1;
                }
            }
            string ids = String.Join("", gecici.Select(p => p.ToString()).ToArray());
            return ids;
        }
        public string tabanCevirBoyut(int sayi)
        {
            int[] gecici = new int[5];
            int boyut = 4;
            if (sayi == 0)
            {
                for (int m = 0; m < 5; m++)
                    gecici[m] = 0;
            }
            else
            {
                while (sayi >= 1)
                {
                    gecici[boyut] = sayi % 5;
                    sayi /= 5;
                    boyut -= 1;
                }
            }
            string ids = String.Join("", gecici.Select(p => p.ToString()).ToArray());
            return ids;
        }

        private void SifrelenecekResimSec_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Dosyaları|*.jpg|Bütün Dosyalar (*.*)|*.*";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SifrelenecekResim.ImageLocation = dialog.FileName;

            }
        }

        private void TasiyiciResimSec_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Dosyaları|*.jpg|Bütün Dosyalar (*.*)|*.*";
            dialog.InitialDirectory = ".";
            dialog.Title = "Bir resim dosyası seçiniz";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TasiyiciResim.ImageLocation = dialog.FileName;

            }
        }

        private void Sifrele_Click(object sender, EventArgs e)
        {
            if (SifrelenecekResim.Image != null && TasiyiciResim.Image != null)
            {
                Bitmap desifreliResim = new Bitmap(TasiyiciResim.Image.Width, TasiyiciResim.Image.Height);
                Bitmap bitmap1 = new Bitmap(SifrelenecekResim.Image);
                SifrelenecekResim.Image = bitmap1;
                Bitmap bitmap2 = new Bitmap(TasiyiciResim.Image);
                if (bitmap1.Height * bitmap1.Width * 8 < bitmap2.Width * bitmap2.Height)
                {
                    if (SifrelenecekResim.Image != null && TasiyiciResim.Image != null)
                    {
                        SifreliResim.Show();
                        TasiyiciDizi = new int[bitmap2.Height, bitmap2.Width * 3];
                        Tasiyici = new int[bitmap2.Height, bitmap2.Width * 3];
                        SifreliDizi = new int[bitmap2.Height, bitmap2.Width * 3];
                        int[,] SifrelenecekDizi = new int[bitmap1.Height, bitmap1.Width * 3];
                        int l = 0;
                        int z = 0;
                        int[,] sonuc = new int[bitmap2.Height, bitmap2.Width * 3];
                        int sonucMod = 0;
                        int bir, iki, uc, dort, bes;
                        int[] pikselDizisi = new int[4];
                        int[] boyutDizisi = new int[5];
                        sinir = new int();
                        sinir = bitmap2.Width * 3;
                        desifreliSutun = desifreliResim.Width;
                        desifreliSatir = desifreliResim.Height;
                        string ids;
                        Color renk;
                        for (int i = 0; i < bitmap2.Height; i++)
                        {
                            for (int j = 0; j < bitmap2.Width; j++)
                            {
                                renk = bitmap2.GetPixel(j, i);
                                TasiyiciDizi[i, z] = renk.R;
                                TasiyiciDizi[i, z + 1] = renk.G;
                                TasiyiciDizi[i, z + 2] = renk.B;
                                Tasiyici[i, z] = TasiyiciDizi[i, z];
                                Tasiyici[i, z+1] = TasiyiciDizi[i, z+1];
                                Tasiyici[i, z+2] = TasiyiciDizi[i, z+2];
                                z += 3;
                            }
                            z = 0;
                        }                       
                        for (int i = 0; i < bitmap1.Height; i++)
                        {
                            for (int j = 0; j < bitmap1.Width; j++)
                            {
                                SifrelenecekDizi[i, l] = bitmap1.GetPixel(j, i).R;
                                SifrelenecekDizi[i, l + 1] = bitmap1.GetPixel(j, i).G;
                                SifrelenecekDizi[i, l + 2] = bitmap1.GetPixel(j, i).B;
                                l += 3;
                            }
                            l = 0;
                        }
                    
                        //boyut şifreleme
                        for (int i = 0; i < 1; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                //if (y == 0 && k < 17)
                                //    j = 0;
                                if (k < 10)
                                {
                                    ids = tabanCevirBoyut(bitmap1.Height);

                                    bir = Int32.Parse(ids.Substring(0, 1));
                                    iki = Int32.Parse(ids.Substring(1, 1));
                                    uc = Int32.Parse(ids.Substring(2, 1));
                                    dort = Int32.Parse(ids.Substring(3, 1));
                                    bes = Int32.Parse(ids.Substring(4, 1));
                                    boyutDizisi[0] = bir;
                                    boyutDizisi[1] = iki;
                                    boyutDizisi[2] = uc;
                                    boyutDizisi[3] = dort;
                                    boyutDizisi[4] = bes;                                   
                                }
                                else if (k < 20)
                                {
                                    ids = tabanCevirBoyut(bitmap1.Width);

                                    bir = Int32.Parse(ids.Substring(0, 1));
                                    iki = Int32.Parse(ids.Substring(1, 1));
                                    uc = Int32.Parse(ids.Substring(2, 1));
                                    dort = Int32.Parse(ids.Substring(3, 1));
                                    bes = Int32.Parse(ids.Substring(4, 1));
                                    boyutDizisi[0] = bir;
                                    boyutDizisi[1] = iki;
                                    boyutDizisi[2] = uc;
                                    boyutDizisi[3] = dort;
                                    boyutDizisi[4] = bes;
                                    
                                }

                                for (int t = 0; t < 5; t++)
                                {
                                    sifreleMod5(sonucMod, boyutDizisi[t]);

                                }                              
                            }
                        }
                        //Piksel şifreleme
                        for (int i = 0; i < bitmap1.Height; i++)
                        {
                            for (int j = 0; j < bitmap1.Width * 3; j++)
                            {
                                bir = Int32.Parse(tabanCevirPiksel(SifrelenecekDizi[i, j]).Substring(0, 1));
                                iki = Int32.Parse(tabanCevirPiksel(SifrelenecekDizi[i, j]).Substring(1, 1));
                                uc = Int32.Parse(tabanCevirPiksel(SifrelenecekDizi[i, j]).Substring(2, 1));
                                dort = Int32.Parse(tabanCevirPiksel(SifrelenecekDizi[i, j]).Substring(3, 1));
                                pikselDizisi[0] = bir;
                                pikselDizisi[1] = iki;
                                pikselDizisi[2] = uc;
                                pikselDizisi[3] = dort;

                                for (int t = 0; t < 4; t++)
                                {
                                    sifreleMod5(sonucMod, pikselDizisi[t]);

                                }
                            }
                        }
                        //şifreli resim pikselleri
                        for (int t = 0; t < bitmap2.Height; t++)
                        {
                            for (int b = 0; b < bitmap2.Width * 3; b++)
                            {
                                SifreliDizi[t, b] = TasiyiciDizi[t, b];                               
                            }
                            
                        }
                        
                        int o = 0, u = 0;
                        for (int i = 0; i < TasiyiciResim.Image.Height; i++)
                        {
                            for (int j = 0; j < TasiyiciResim.Image.Width; j++)
                            {
                                Convert.ToByte(SifreliDizi[i, j]);
                                byte r = Convert.ToByte(SifreliDizi[u, o]);
                                byte g = Convert.ToByte(SifreliDizi[u, o + 1]);
                                byte b = Convert.ToByte(SifreliDizi[u, o + 2]);
                                o += 3;
                                Color myNewColor = Color.FromArgb(r, g, b);
                                desifreliResim.SetPixel(j, i, myNewColor);
                            }
                            o = 0;
                            u++;
                        }
                        SifreliResim.Image = desifreliResim;

                        //PSNR DEĞERİ HESAPLAMA
                        double mse = 0, temp = 0, psnr = 0;
                        int m = SifreliResim.Image.Height;
                        int p = SifreliResim.Image.Width * 3;
                        for (int i = 0; i < m - 1; i++)
                        {
                            for (int j = 0; j < p - 1; j++)
                            {
                                temp = SifreliDizi[i, j] - Tasiyici[i, j];
                                mse += temp * temp;
                            }

                        }
                        mse = mse / (m * p * 3); // Because of RGB
                        psnr = (20 * Math.Log10(255)) - (10 * Math.Log10(mse));
                        psnr = Math.Round(psnr, 0);
                        label5.Text = psnr.ToString();
                    }
                }
                else
                    MessageBox.Show("sığdıramadım");
            }
            else
                MessageBox.Show("lütfen resim seçiniz.");
            k = 0;
            y = 0;

        }

        private void Desifrele_Click(object sender, EventArgs e)
        {
            Bitmap desifre = new Bitmap(SifrelenecekResim.Image.Height, SifrelenecekResim.Image.Width);
            int y = 0, z = 0, a = 0;
            int[] pikselDizisi = new int[4];
            int[] boyutDizisi = new int[5];
            int s = 0, n = 0;
            int d = 0;
            int k = 20;            
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            boyutDizisi[m] = (SifreliDizi[z, y] + 2 * SifreliDizi[z, y + 1]) % 5;
                            y += 2;

                        }
                        d++;
                        if (d == 1)
                            genislik = bestenOnlugaCevirBoyut(boyutDizisi);
                        else
                            yukseklik = bestenOnlugaCevirBoyut(boyutDizisi);

                    }
                }
                int[,] desifreliDizi = new int[genislik, yukseklik * 3];
                for (int i = 0; i < genislik; i++)
                {
                    for (int j = 0; j < yukseklik * 3; j++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            pikselDizisi[l] = (SifreliDizi[a, k] + 2 * SifreliDizi[a, k + 1]) % 5;
                            k += 2;
                            if (k == desifreliSutun * 3)
                            {
                                k = 0;
                                a++;
                            }
                        }
                        desifreliDizi[s, n] = bestenOnlugaCevirPiksel(pikselDizisi);
                        n++;
                        if (n == yukseklik * 3)
                        {
                            n = 0;
                            s++;
                        }
                    }
                }
                int t = 0, v = 0;
                for (int i = 0; i < genislik; i++)
                {
                    for (int j = 0; j < yukseklik; j++)
                    {
                        Convert.ToByte(desifreliDizi[i, j]);
                        byte r = Convert.ToByte(desifreliDizi[v, t]);
                        byte g = Convert.ToByte(desifreliDizi[v, t + 1]);
                        byte b = Convert.ToByte(desifreliDizi[v, t + 2]);
                        t += 3;
                        Color myNewColor = Color.FromArgb(r, g, b);
                        desifre.SetPixel(i, j, myNewColor);
                    }
                    t = 0;
                    v++;
                }
                Sonuc.Image = desifre;
                Sonuc.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu Ana = new Menu();
            Ana.Show();
            this.Close();

        }

        private void Mod5_Load(object sender, EventArgs e)
        {
        }

        private void Kaydet_Click(object sender, EventArgs e)
        {
        }

        private void Kaydet_Click_1(object sender, EventArgs e)
        {
        }
    }
}
