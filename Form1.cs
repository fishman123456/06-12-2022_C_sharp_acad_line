using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _06_12_2022_C_sharp_acad_line
{

    public partial class Form1 : Form
    {
        public string filename_f =null;
        public int count_string = 0;

        public Form1()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //void FilesRead(string filename) // TODO считывание из файл "»ћя.txt"
            //{
            //    string something = File.ReadAllText(filename);
            //}
            //открываем диалог дл€ выбора файла
                       OpenFileDialog OPF = new OpenFileDialog();
            // путь по умолчанию
            OPF.InitialDirectory = @"C:\Users\Fishman.DB.CORP\Documents\GitHub
            \06-12-2022_C_sharp_acad_line\bin\Debug\net6.0-windows";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
               // MessageBox.Show(OPF.FileName, "‘айл считан");
                filename_f= OPF.FileName;
               // Stream stream = OPF.OpenFile();
         // выводим файл в TextBox
                textBox1.Text = File.ReadAllText(filename_f);
                // разбиваем файл на подстроки, где в дальнейшем
                // будем искать ключи и значени€ дл€ словарей
                //  StreamReader sr = new StreamReader(stream);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // дл€ заволнени€ списка строками
            //List<string> myList = new List<string>();
               if (filename_f!=null) {  
            
             //   textBox2.Text = File.ReadAllText(filename_f);  // TODO выводим содержимое файла в textbox2
                string[] MassString = File.ReadAllLines(filename_f); // TODO создаем массив строк
                textBox2.Text = MassString[count_string];
            }
            else
            {
                MessageBox.Show("—читайте файл");
            }
            count_string++;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}