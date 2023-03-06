using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PassLenLabel.Text = trackBar1.Value.ToString();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                Clipboard.SetText(label1.Text);
            }
            else
            {
                MessageBox.Show("Для начала сгенеруруйте пароль!!!");
            }
            
        }

        private void button_generation_Click(object sender, EventArgs e)
        {
            int passLen = trackBar1.Value;
            // СОздание рандомного пароля
            string[] arr = {"", "B", "C", "D", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z", "b", "c", "d", "f", "g", "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z", "A", "E", "U", "Y", "a", "e", "i", "o", "u", "y" };
            string[] arrNumb = {"", "", "", "", "", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string[] arrSpecial = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ".", ",", "!", "@", "#", "$", "%", "^", "&", "№", "?", "@", "*", "/", "+", "-", "_", "="};
            string iPass = "";
            Random rnd = new Random();      
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                while(iPass.Length < passLen)
                {
                    iPass = iPass + arr[rnd.Next(0, 48)] + arrNumb[rnd.Next(0,14)];
                }
            }
            if (checkBox2.Checked == true && checkBox1.Checked == false)
            {
                while (iPass.Length < passLen)
                {
                    iPass = iPass + arr[rnd.Next(0, 48)] + arrSpecial[rnd.Next(0, 32)];
                }
            }
            if (checkBox2.Checked == true && checkBox1.Checked == true)
            {
                while (iPass.Length < passLen)
                {
                    iPass = iPass + arr[rnd.Next(0, 48)] + arrNumb[rnd.Next(0, 14)] + arrSpecial[rnd.Next(0, 32)];
                }
            }
            else
            {
                while (iPass.Length < passLen)
                {
                    iPass = iPass + arr[rnd.Next(0, 48)];
                }
            }

            // Проверка длины пароля
            if (passLen != iPass.Length)
            {
                iPass = iPass.Remove(passLen, iPass.Length - passLen);
            }

            label1.Text = iPass;
        }
    }
}
