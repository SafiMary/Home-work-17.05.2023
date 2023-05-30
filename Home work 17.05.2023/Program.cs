using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_17._05._2023
{

    internal class Program
    {
        
        static string[] readFileToArray(string filename)
        {
            try
            {
                // Открыли, прочитали, закрыли
                var sr = new StreamReader(filename);
                string buffer = sr.ReadToEnd();
                sr.Close();
                // разбираем, посредством Split на слова.
                
                var _arr = buffer.Split(' ', '\n', '\r'/*, '.',','*/);
                return _arr;
            }
            catch
            {
                Console.WriteLine($"Не удалось прочитать файл {filename}");
                string[] _arr = new string[] { };
                return _arr;
            }
        }
        static void writeToFile(string filename, string _text, bool append = true)
        {
            try
            {
                // Используя конструкцию using, автоматически закрываем поток для записи
                using (var sw = new StreamWriter(filename, append))
                {
                    sw.WriteLine(_text);
                }
            }
            catch
            {
                Console.WriteLine($"Не удалось записать в файл {filename}");
            }
        }
        static void Main(string[] args)
        {
            string path1 = "text1.txt";
            string path2 = "text2.txt";

            try
            {
                path1 = args[0];
                path2 = args[1];
            }

            catch
            {
                Console.WriteLine("аргументы не переданны");
            }

            string[] _arr01 = readFileToArray(path1);
            string[] _arr02 = readFileToArray(path2);
            var result = _arr01.Intersect(_arr02);
            foreach (var item in result)
            {
                Console.WriteLine(item);
                writeToFile("result.txt", item);
            }



        }
    }
}