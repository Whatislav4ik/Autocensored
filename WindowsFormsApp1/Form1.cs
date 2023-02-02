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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            counts = 0;
        }

        public static String censor(String text,
                     String word)
        {

            // Разделение по пробелу
            String[] word_list = text.Split(' ');

            String result = "";

            // цензурирование слова * по его длине
            String stars = "";
            for (int i = 0; i < word.Length; i++)
                stars += '*';

            // соединение 
            int index = 0;
            foreach (String i in word_list)
            {
                if (i.CompareTo(word) == 0)

                    word_list[index] = stars;
                index++;
            }

            // соединение слов
            foreach (String i in word_list)
                result += i + " ";

            return result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || richTextBox1.Text.Equals(""))
                label4.Text = "Повторите ввод!";
            string ssd = string.Copy(textBox1.Text);
            string asd = string.Copy(richTextBox1.Text);
            string sad = censor(asd, ssd);
            richTextBox2.Clear();
            richTextBox2.AppendText(sad);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                StreamReader sr = File.OpenText(openFileDialog1.FileName);

                string line = null;
                line = sr.ReadLine();

                while (line != null)
                {
                    richTextBox1.AppendText(line);
                    richTextBox1.AppendText("\r\n");
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            StreamWriter sw = File.CreateText(saveFileDialog1.FileName + ".txt");

            // Чтение строк с richTextBox1 и добавление их в файл
            string line;
            for (int i = 0; i < richTextBox2.Lines.Length; i++)
            {
                //  Чтение одной строки
                line = richTextBox2.Lines[i].ToString();

                //  Добавление этой строки в файл
                sw.WriteLine(line);

            }
            //  Закрыть объект sw
            sw.Close();
        }

        int counts;
 
        public void Button4_Click(object sender, EventArgs e)
        {

            Form2 newfrm = new Form2();
            newfrm.Show();
            counts++;
        }
    }
}
