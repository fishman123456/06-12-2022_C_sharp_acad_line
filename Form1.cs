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
        public struct CadCoord // создаем структуру для храниния извлеченных данных из автокада 8 полей
        {
            public string number_p; // номер по порядку 1)
            public string name_block; // имя блока в автокаде "ElectrikKabinet" - пример 2)
            public string cordX; // Координата X  20422.6312	- пример 3)
            public string cordY; // Координата Y  29950.5828    - пример 4)
            public string cordZ;  // Координата Z 	0.0000      - пример 5)
            public string cordX2; // Координата X  20422.6312	- пример 6)
            public string cordY2; // Координата Y  29950.5828    - пример 7)
            public string cordZ2;  // Координата Z 	0.0000      - пример 8)
            public string name_kable; // имя кабеля 101.2-K1       - пример 9)
            public string beginning; // начало (откуда идет кабель)  Щит ШУК101   - пример 10)
            public string ending; // // конец (куда идет кабель)    	Щит ШСК101  - пример 11)
            public string beginning2; // начало (откуда идет кабель)  Щит ШУК101   - пример 12)
            public string ending2; // // конец (куда идет кабель)    	Щит ШСК101  - пример 13)
        }
        public string filename_f = null;
        public int count_string = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //void FilesRead(string filename) // TODO считывание из файл "ИМЯ.txt"
            //{
            //    string something = File.ReadAllText(filename);
            //}
            //открываем диалог для выбора файла
            OpenFileDialog OPF = new OpenFileDialog();
            // путь по умолчанию
            OPF.InitialDirectory = @"C:\Users\Fishman.DB.CORP\Documents\GitHub
            \06-12-2022_C_sharp_acad_line\bin\Debug\net6.0-windows";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show(OPF.FileName, "Файл считан");
                filename_f = OPF.FileName;
                // Stream stream = OPF.OpenFile();
                // выводим файл в TextBox
                textBox1.Text = File.ReadAllText(filename_f);
                // разбиваем файл на подстроки, где в дальнейшем
                // будем искать ключи и значения для словарей
                //  StreamReader sr = new StreamReader(stream);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e) // кнопка для создания массива строк
        {
            // для заволнения списка строками
            //List<string> myList = new List<string>();
            if (filename_f != null)
            {

                //   textBox2.Text = File.ReadAllText(filename_f);  // TODO выводим содержимое файла в textbox2
                string[] MassString = File.ReadAllLines(filename_f); // TODO создаем массив строк
                string[] MassSubString = MassString[0].Split('\t');

                if (count_string <= MassSubString.Length - 1)
                {
                    // System.Threading.Thread.Sleep(1000);
                    textBox2.Text = MassSubString[count_string];
                    count_string++;
                }
                else
                {
                    count_string = 0;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Считайте файл");
            }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            CadCoord aS = new CadCoord();
            if (filename_f != null)
            {
                //   textBox2.Text = File.ReadAllText(filename_f);  // TODO выводим содержимое файла в textbox2
                string[] MassString = File.ReadAllLines(filename_f); // TODO создаем массив строк
                string[] MassSubString = MassString[0].Split('\t');

                if (count_string <= MassSubString.Length - 1)// заполняем структуру для храниния извлеченных данных из автокада 8 полей
                {
                    // System.Threading.Thread.Sleep(1000);
                    aS.number_p = MassSubString[0];
                    aS.name_block = MassSubString[1];
                    aS.cordX = MassSubString[2];
                    aS.cordY = MassSubString[3];
                    aS.cordZ = MassSubString[4];
                    aS.name_kable = MassSubString[5];
                    aS.beginning = MassSubString[6];
                    aS.ending = MassSubString[7];
                    count_string++;
                    textBox3.Text = aS.name_kable +" "+  aS.beginning + " " + aS.ending;
                    comboBox1.Items.Add(aS.name_kable);
                    listBox1.Items.Add(aS.name_kable);
                }
                else
                {
                    MessageBox.Show("Считайте файл");
                }
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем текущую форму
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}