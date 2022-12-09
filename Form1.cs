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

        public struct CadCoord // ������� ��������� ��� �������� ����������� ������ �� �������� 8 �����
        {
            public string number_p; // ����� �� ������� 1)
            public string name_block; // ��� ����� � �������� "ElectrikKabinet" - ������ 2)
            public string cordX; // ���������� X  20422.6312	- ������ 3)
            public string cordY; // ���������� Y  29950.5828    - ������ 4)
            public string cordZ;  // ���������� Z 	0.0000      - ������ 5)
            public string name_kable; // ��� ������ 101.2-K1       - ������ 6)
            public string beginning; // ������ (������ ���� ������)  ��� ���101   - ������ 7)
            public string ending; // // ����� (���� ���� ������)    	��� ���101  - ������ 8)
        }
        public string filename_f = null;
        public int count_string = 0;

        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //void FilesRead(string filename) // TODO ���������� �� ���� "���.txt"
            //{
            //    string something = File.ReadAllText(filename);
            //}
            //��������� ������ ��� ������ �����
            OpenFileDialog OPF = new OpenFileDialog();
            // ���� �� ���������
            OPF.InitialDirectory = @"C:\Users\Fishman.DB.CORP\Documents\GitHub
            \06-12-2022_C_sharp_acad_line\bin\Debug\net6.0-windows";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show(OPF.FileName, "���� ������");
                filename_f = OPF.FileName;
                // Stream stream = OPF.OpenFile();
                // ������� ���� � TextBox
                textBox1.Text = File.ReadAllText(filename_f);
                // ��������� ���� �� ���������, ��� � ����������
                // ����� ������ ����� � �������� ��� ��������
                //  StreamReader sr = new StreamReader(stream);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e) // ������ ��� �������� ������� �����
        {
            // ��� ���������� ������ ��������
            //List<string> myList = new List<string>();
            if (filename_f != null)
            {

                //   textBox2.Text = File.ReadAllText(filename_f);  // TODO ������� ���������� ����� � textbox2
                string[] MassString = File.ReadAllLines(filename_f); // TODO ������� ������ �����
                string[] MassSubString = MassString[1].Split('\t');

                if (count_string <= MassSubString.Length - 1)
                {
                    // System.Threading.Thread.Sleep(1000);
                    textBox2.Text = MassSubString[count_string];
                    count_string++;
                }
                else
                {
                    count_string = 0;
                }
            }
            else
            {
                MessageBox.Show("�������� ����");
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

                //   textBox2.Text = File.ReadAllText(filename_f);  // TODO ������� ���������� ����� � textbox2
                string[] MassString = File.ReadAllLines(filename_f); // TODO ������� ������ �����
                string[] MassSubString = MassString[1].Split('\t');

                if (count_string <= MassSubString.Length - 1)// ��������� ��������� ��� �������� ����������� ������ �� �������� 8 �����
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
                }
                

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // ��������� ������� �����
        }
    }
}