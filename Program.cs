// 06-12-2022 
// Программа для автокада чтобы рисовать отрезки
// (кабельные линии) откуда куда и координаты



namespace _06_12_2022_C_sharp_acad_line
{
 
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
           
            void FilesWrite(string filename)  // TODO запись в файл "ИМЯ.txt"
            {
                string path = filename;
                string text = @"Some Text";
                File.WriteAllText(path, text);
            }

            void FilesRead(string filename) // TODO считывание из файл "ИМЯ.txt"
            { 
            string something = File.ReadAllText(filename);
            }

            //FilesWrite("1.lsp");
           // FilesRead(filename);
            Application.Run(new Form1());
        }
    }

}