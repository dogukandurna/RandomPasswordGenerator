using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomPasswordCreater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || textBox2.Text == "Uzunluk")
            {
                errorProvider2.SetError(textBox2,"Uzunluk Boş Geçilemez");
                errorProvider1.BlinkRate = 0;
            }
            else
            {
                errorProvider2.Clear();
                int a = Convert.ToInt32(textBox2.Text);
                int uzunluk = a;
                StringBuilder result = new StringBuilder();
                Random rast = new Random();
                textBox1.MaxLength = 25;

                for (int i = 0; i < uzunluk; i++)
                {
                    const string Harfler = "abcçdefgğhiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ";
                    const string İfadeler = "!>'£^#+$%&/()=?*-_|";
                    const string İfaHarf = "!>'£^#+$%&/()=?*-_|!>'£^#+=?*-_abcçdefgğhiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ";
                    const string Sayİfa = "0123456789!>'£^#+$%&/()=?*-_|";
                    string karışık = "0123456789012345678901234567890123456789012345abcçdefgğhiıjklmnoöprsştuüvyzabcçdefgğhiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZabcçdefgğhi";
                    string hepsi = "!>'£^#+$%&/()=?*-_|0123456789!>'£^#+$%&/()=?*-_|abcçdefgğhiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ";
                    // string[] SayHarf = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a","b","c","ç","d","e","f","g","ğ","hiıjklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ" }; */
                    if (checkBox4.Checked && !checkBox1.Checked && !checkBox2.Checked)
                    {
                        result.Append(Harfler[rast.Next(Harfler.Length)]);
                    }
                    else if (!checkBox4.Checked && checkBox1.Checked && !checkBox2.Checked)
                    {
                        // result.Append(Sayılar[rast.Next(Sayılar.Length)]);
                        int şifre = rast.Next(48, 57);
                        char karakter = Convert.ToChar(şifre);
                        result.Append(karakter);
                    }
                    else if (!checkBox4.Checked && !checkBox1.Checked && checkBox2.Checked)
                    {
                        result.Append(İfadeler[rast.Next(İfadeler.Length)]);
                    }
                    else if (checkBox1.Checked && checkBox4.Checked && !checkBox2.Checked)
                    {
                        result.Append(karışık[rast.Next(karışık.Length)]);
                    }
                    else if (checkBox4.Checked && !checkBox1.Checked && checkBox2.Checked)
                    {
                        result.Append(İfaHarf[rast.Next(İfaHarf.Length)]);
                    }
                    else if (!checkBox4.Checked && checkBox1.Checked & checkBox2.Checked)
                    {
                        result.Append(Sayİfa[rast.Next(Sayİfa.Length)]);
                    }
                    else if (checkBox4.Checked && checkBox1.Checked && checkBox2.Checked)
                    {
                        result.Append(hepsi[rast.Next(hepsi.Length)]);
                    }

                    errorProvider1.Clear();

                    /* int şifre = rast.Next(32, 127);
                    char karakter = Convert.ToChar(şifre);
                    result.Append(karakter); */
                }

                textBox1.Text = result.ToString();
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1,"Şifre Alanı boş");
                errorProvider1.BlinkRate = 0;
            }
            else
            {
                errorProvider1.Clear();
                Clipboard.SetText(textBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == "Uzunluk")
            {
                errorProvider2.SetError(textBox2, "Uzunluk Boş Geçilemez");
                errorProvider1.BlinkRate = 0;
            }
            else
            {
                errorProvider2.Clear();
                int a = Convert.ToInt32(textBox2.Text);
                int uzunluk = a;
                StringBuilder result = new StringBuilder();
                Random rast = new Random();

                for (int i = 0; i < uzunluk; i++)
                {
                    int şifre = rast.Next(32, 127);
                    char karakter = Convert.ToChar(şifre);
                    result.Append(karakter);
                }
                textBox1.Text = result.ToString();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
