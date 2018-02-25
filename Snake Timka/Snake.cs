using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public int lastx, lasty;
        public List<Point> body;
        string sign;
        ConsoleColor color;
        public Snake()
        {
            body = new List<Point>(); // Создаем тело которое состоит из координат
            body.Add(new Point(3, 3)); // Добавляем нашу голову на координату 3 и 3
            sign = "o"; // Наша голова
            color = ConsoleColor.Yellow;
        }
        public void Move(int dx, int dy) //  Функция которая меняет местоположение змейки при нажатий кнопок
        {
            lastx = body[body.Count - 1].x;
            lasty = body[body.Count - 1].y;
            for (int i = body.Count - 1; i > 0; i--) // При добавлений нового элемнента, он добавляется к хвосту
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            body[0].x += dx;
            body[0].y += dy;
            Console.SetCursorPosition(lastx, lasty);
            Console.Write(" ");

            if (body[0].x < 1)
                body[0].x = Console.WindowWidth - 17; // У нас есть Score и Name, чтобы не пересекало их
            if (body[0].x > Console.WindowWidth - 17) // Но она нужна для того, если наша змейка выйдет заграницу, вернуть её по нужному местоположению
                body[0].x = 1;
            if (body[0].y < 1)
                body[0].y = Console.WindowHeight - 1;
            if (body[0].y > Console.WindowHeight - 1)
                body[0].y = 1;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red; // Голова змейки красного цвета
            Point head = body.ElementAt(0); // Наша голова 
            Console.SetCursorPosition(head.x, head.y); // Передаем координаты
            Console.Write(sign); // Рисуем голову
            /*foreach (Point p in body.GetRange(1, body.Count - 1)) // Остальные элементы после головы
            {
                //int index = 0;
                //if (index == 0) 
                Console.ForegroundColor = ConsoleColor.Green; // Красим в зеленый
                Console.SetCursorPosition(p.x, p.y); // Передаем координаты
                Console.Write(sign); // Прорисовываем
                //index++;
            }*/
        }
        public bool CollisionWithWall(Wall w) // Колижш со стенкой
        {
            foreach (Point p in w.body)
            {
                if (p.x == body[0].x && p.y == body[0].y)
                    return true;
            }
            return false;
        }
        public bool Collision() // Колижн с самим  собой
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
        public bool CollisionWithFood(Fruit f) // Когда он кушает фрукт
        {
            if (body[0].x == f.fruit.x && body[0].y == f.fruit.y) return true;
            else return false;
        }

    }
}