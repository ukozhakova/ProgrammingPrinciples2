using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Background
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.SetWindowSize(35, 35);
            Console.SetBufferSize(35, 35);
            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            FileStream fs = new FileStream(@"TextFile1.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            sr.Close();
            fs.Close();
            
            Console.ForegroundColor = (ConsoleColor.Yellow);
            Console.SetCursorPosition(50, 17);
            string name;
            Console.WriteLine("Enter you name: ");
            Console.SetCursorPosition(66, 17);
            name  = Console.ReadLine();
            Console.SetCursorPosition(25, 18);
            Console.WriteLine(name + ", welcome to our game!! Please, select what you wanna do");
            Console.ReadKey();
        }
    }
}
