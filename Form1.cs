using System.Text;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _06_12_2022_C_sharp_acad_line
{

    public partial class Form1 : Form
    {
        public string filename_f =null;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            void FilesRead(string filename) // TODO считывание из файл "»ћя.txt"
            {
                string something = File.ReadAllText(filename);
            }
            //открываем диалог дл€ выбора файла
                       OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = @"C:\Users\Fishman.DB.CORP\Documents\GitHub
            \06-12-2022_C_sharp_acad_line\bin\Debug\net6.0-windows";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(OPF.FileName, "‘айл считан");
                filename_f= OPF.FileName;
                Stream stream = OPF.OpenFile();
                //File.ReadAllText(filename_f, Encoding.GetEncoding("windows-1251"));
                textBox1.Text = File.ReadAllText(filename_f);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}