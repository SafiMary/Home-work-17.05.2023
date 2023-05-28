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

            var streamWriter = new StreamWriter("solution.txt");
            string[] lines1 = File.ReadAllLines(path1);
            Console.WriteLine(String.Join(Environment.NewLine, lines1));
            string[] lines2 = File.ReadAllLines(path2);
            Console.WriteLine(String.Join(Environment.NewLine, lines2));
            //string[] lines1 = { "Пиво", "Вино", "Водка", "Вермут" };
            //string[] lines2 = { "Пиво", "Сок", "Абсент", "Водка" };
            var result = lines1.Intersect(lines2).ToList();
            foreach (var s in result) { 
                streamWriter.WriteLine(s);
            }
            streamWriter.Close();
        }
    }
}
