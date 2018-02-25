using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Fruit
    {
        Wall w;
        Random rnd = new Random(); // наш рандомчик
        public Point fruit = new Point(0, 0);
        public Fruit(Wall w)
        {
            this.w = w;
            FoodMaker(w);
        }
        public void FoodMaker(Wall w) // Проверка на Colission со стенкой
        {
            bool isCollision = true;
            while (true)
            {
                fruit.x = rnd.Next(5, Console.WindowWidth - 16);
                fruit.y = rnd.Next(5, Console.WindowHeight - 5);
                foreach (Point p in w.body)
                {
                    if (p.x == fruit.x && p.y == fruit.y)
                    {
                        isCollision = true; // Если фрукт спаунится в стенке, то делаем рекурсию и спауним обратно фрукт
                        FoodMaker(w);
                    }
                    else isCollision = false;  // Если все окей, колизия = ложь
                }
                if (!isCollision) // Если все окей, просто делаем брейк и выходим из вечного цикла, наш фрукт создается нормально
                {
                    break;
                }
                return;
            }
        }
        public void FoodDrawer()
        {
            Console.SetCursorPosition(fruit.x, fruit.y); // Передаем координаты фрукта
            Console.ForegroundColor = ConsoleColor.Yellow; // Наш фрукт будет жёлтым
            Console.Write("$"); // Прорисовываем фрукт
        }
    }
}