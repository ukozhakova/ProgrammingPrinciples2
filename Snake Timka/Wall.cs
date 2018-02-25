using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    public class Wall
    {
        public List<Point> body;
        public string sign;
        public ConsoleColor color;
        public void ReadLevel(int level)
        {
            StreamReader sr = new StreamReader(@level + ".txt"); // Считываем наш файл с уровнем
            int n = int.Parse(sr.ReadLine()); // В нашем файле на 1ой строке будет число рядов
            for (int i = 0; i < n; i++) // Проходимся по этому числу
            {
                string s = sr.ReadLine(); // Читаем наши ряды
                for(int j = 0; j < s.Length; j++)
                    if (s[j] == '#' || s[j] == '@' || s[j] == '&' || s[j] == '%') // Если какой-то знак соотвествует этому
                        body.Add(new Point(j, i)); // Добавляем его
            }
            sr.Close(); // Закрываем поток
        }
        public Wall(int level)                                          
        {
            body = new List<Point>(); // Создаем лист из Поинта ( координаты )
            sign = "#"; // Наши штучки для прорисовки карты
            if (level == 2) sign = "@";
            if (level == 3) sign = "%";
            color = ConsoleColor.Blue; // Наша стенка будет синей)
            ReadLevel(level); // Функция которая помогает нам проверить нужный элемент и добавить его на карту
        }
        public void Draw()
        {
            Console.ForegroundColor = color; 
            foreach (Point p in this.body) // Проходимся по стеночке
            {
                Console.SetCursorPosition(p.x, p.y); // Задаем курсор
                Console.Write(sign); // Прорисовываем стеночку
            }
        }
    }
}