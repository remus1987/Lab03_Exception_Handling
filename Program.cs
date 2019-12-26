using System;
using System.Text;
using System.IO;

namespace Lab03_B_Exception_FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandlingExceptionLab FE = new FileHandlingExceptionLab();
            FE.CreateFile();
            FE.TestTheUsingKeyboard();
        }
    }

    #region FileHandlingException_class
    public class FileHandlingExceptionLab
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
        public void CreateFile()
        {
            FileInfo info = null;
            try
            {
                string file = GetUserInput();
                info = new FileInfo(file);
                info.CreateText();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.FileName, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(info.FullName); 
            }
        }
        //The using statement
        public void TestTheUsingKeyboard()
        {
            using (FileStream fl = new FileStream("My_File.gif", FileMode.Create))
            {
                fl.Write(UTF8Encoding.UTF8.GetBytes("some text"), 0, 2);
                fl.Close();
            }
        }
    }
    #endregion
}
