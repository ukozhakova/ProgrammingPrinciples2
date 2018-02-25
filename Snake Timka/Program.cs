using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    class Program
    {
        static void f1(Snake a, Snake b, Wall c, Fruit d, string e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Snake));
            XmlSerializer xs1 = new XmlSerializer(typeof(Snake));
            XmlSerializer xss = new XmlSerializer(typeof(Wall));
            XmlSerializer xsss = new XmlSerializer(typeof(Fruit));
            XmlSerializer xssss = new XmlSerializer(typeof(string));
            FileStream fs = new FileStream(@"s1.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fs1 = new FileStream(@"s2.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fs2 = new FileStream(@"wall.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fs3 = new FileStream(@"fruit.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fs4 = new FileStream(@"name.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, a);
            xs1.Serialize(fs1, b);
            xss.Serialize(fs2, c);
            xsss.Serialize(fs3, d);
            xssss.Serialize(fs4, e);
            fs.Close();
        }
        static void f2()
        {
            Snake snake3 = new Snake();
            Snake snake4 = new Snake();
            //Wall Voll = new Wall(level);
            //Fruit froot = new Fruit();
            //Staring Namee = new string();
        }
        static void Main(string[] args)
        {
            string name = "";
            int FinalScore = 0;
            Console.CursorVisible = false; // Чтобы было приятно глазу
            int level = 1;
            int BestScore = 0;
            /* if(level == 1)
            {
                Console.SetCursorPosition(40, 15);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press C if you want to Continue the last game");
                ConsoleKeyInfo jey = Console.ReadKey();
                if(jey.Key == ConsoleKey.C)
                else break;
                {
                    snake3 = xs.Deserialize(fs) as Snake;
                    snake4 = xs1.Deserialize(fs) as Snake;
                    w1 = xss.Deserialize(fs) as Wall;
                    c = xsss.Deserialize(fs) as Fruit;
                    namee = xssss.Deserialize(fs) as string;
                    fs.Close();
                }
            } */
            if (level == 1) // Получаем имя нашего игрока
            {
                Console.SetCursorPosition(40, 10);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your name : ");
                Console.SetCursorPosition(59, 10);
                name = Console.ReadLine();
                Console.Clear();

            }
            Snake snake = new Snake();
            Wall wall = new Wall(level);
            Fruit f = new Fruit(wall);
            Fruit p = new Fruit(wall);
            Fruit d = new Fruit(wall);
            snake.Draw();
            wall.Draw();
            f.FoodDrawer();
            Snake snake1 = new Snake();
            snake1.Draw();
            Console.SetCursorPosition(Console.WindowWidth - 16, 1); // Здесь оно будет показывать имя пользователя
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name " + name);
            Console.SetCursorPosition(Console.WindowWidth - 16, Console.WindowHeight - 1); // А так же его счёт
            Console.ForegroundColor = ConsoleColor.Green;
            int n = snake.body.Count - 1;
            Console.WriteLine("Score = " + n);


            int cnt = 0;
            int cnt1 = 0;
            while (true) // Бесконечный цикл, игра началась
            {
                Console.SetCursorPosition(Console.WindowWidth - 16, Console.WindowHeight - 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press E to Save");
                Console.SetCursorPosition(Console.WindowWidth - 16, 1); // Тут чтобы обновлялись наши очки каждый раз и не пропадали
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Name " + name);
                Console.SetCursorPosition(Console.WindowWidth - 16, Console.WindowHeight - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                n = snake.body.Count - 1;
                Console.WriteLine("Score = " + n);
                ConsoleKeyInfo key = Console.ReadKey(); // Проверяем какую кнопку мы нажали чтобы передвигать змейку
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (cnt == 1 && snake.body.Count != 1) continue; // Блочим змейку если она после низа хочет пойти навверх
                    snake.Move(0, 1); // Ислключение если у змейка имеется только голова
                    cnt = 2;
                }
                if (key.Key == ConsoleKey.E)
                {
                    f1(snake, snake1, wall, f, name);
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (cnt == 2 && snake.body.Count != 1) continue;
                    snake.Move(0, -1);
                    cnt = 1;
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (cnt == 3 && snake.body.Count != 1) continue;
                    snake.Move(-1, 0);
                    cnt = 4;
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (cnt == 4 && snake.body.Count != 1) continue;
                    snake.Move(1, 0);
                    cnt = 3;
                }
                if (key.Key == ConsoleKey.S)
                {
                    if (cnt1 == 1 && snake1.body.Count != 1) continue;
                    snake1.Move(0, 1);
                    cnt1 = 2;
                }
                if (key.Key == ConsoleKey.W)
                {
                    if (cnt1 == 2 && snake1.body.Count != 1) continue;
                    snake1.Move(0, -1);
                    cnt1 = 1;
                }
                if (key.Key == ConsoleKey.A)
                {
                    if (cnt1 == 3 && snake1.body.Count != 1) continue;
                    snake1.Move(-1, 0);
                    cnt1 = 4;
                }
                if (key.Key == ConsoleKey.D)
                {
                    if (cnt1 == 4 && snake1.body.Count != 1) continue;
                    snake1.Move(1, 0);
                    cnt1 = 3;
                }
                if (key.Key == ConsoleKey.R) // Для рестарта игры
                {
                    level = 1;
                    snake = new Snake();
                    wall = new Wall(level);
                    f = new Fruit(wall);
                    FinalScore = 0;
                    snake1 = new Snake();
                    Console.Clear();
                }
                if (snake.CollisionWithWall(wall) || snake.Collision()) // Проверяем не столкнулась наша змейка со стеной или самой собой
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over, Good Luck Next Time");
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine("Press R To Restart or any other button to exit");
                    ConsoleKeyInfo Pey = Console.ReadKey();
                    if (Pey.Key == ConsoleKey.R)
                    {
                        snake = new Snake();
                        level = 1;
                        snake1 = new Snake();
                        wall = new Wall(level);
                        f = new Fruit(wall);
                        FinalScore = 0;
                        Console.Clear();
                    }
                    else break;
                }
                if (snake1.CollisionWithWall(wall) || snake1.Collision()) // Проверяем не столкнулась наша змейка со стеной или самой собой
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over, Good Luck Next Time");
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine("Press R To Restart or any other button to exit");
                    ConsoleKeyInfo Pey = Console.ReadKey();
                    if (Pey.Key == ConsoleKey.R)
                    {
                        snake = new Snake();
                        level = 1;
                        snake1 = new Snake();
                        wall = new Wall(level);
                        f = new Fruit(wall);
                        FinalScore = 0;
                        Console.Clear();
                    }
                    else break;
                }
                // Console.Clear();
                if (snake.CollisionWithFood(f)) // Проверка, скушала ли наша змейка фрукт
                {
                    snake.body.Add(new Point(snake.body.Last().x + 1, snake.body.Last().y + 1));
                    f = new Fruit(wall);
                    f.FoodDrawer();
                    /* if(level == 2)
                    {
                        p = new Fruit(wall);
                        p.FoodDrawer();
                    }
                    if(level == 3)
                    {
                        p = new Fruit(wall);
                        p.FoodDrawer();
                        d = new Fruit(wall);
                        d.FoodDrawer();
                    } */
                }
                if (snake1.CollisionWithFood(f)) // Проверка, скушала ли наша змейка фрукт
                {
                    snake1.body.Add(new Point(snake1.body.Last().x + 1, snake1.body.Last().y + 1));
                    f = new Fruit(wall);
                    f.FoodDrawer();
                    /* if(level == 2)
                    {
                        c = new Fruit(wall);
                        c.FoodDrawer();
                    }
                    if(level == 3)
                    {
                        c = new Fruit(wall);
                        c.FoodDrawer();
                        d = new Fruit(wall);
                        d.FoodDrawer();
                    } */
                }

                if (snake.body.Count % 6 == 0 && level == 1) // Переходим на 2ой лвл 
                {
                    level++;
                    wall = new Wall(level);
                    snake = new Snake();
                    snake1 = new Snake();
                    f = new Fruit(wall);
                    Console.Clear();
                    wall.Draw();
                    snake.Draw();
                    f.FoodDrawer();
                    FinalScore += 5;
                }
                if (snake.body.Count % 11 == 0 && level == 2) // Переходим на 3 лвл
                {
                    level++;
                    wall = new Wall(level);
                    snake = new Snake();
                    snake1 = new Snake();
                    f = new Fruit(wall);
                    Console.Clear();
                    wall.Draw();
                    snake.Draw();
                    f.FoodDrawer();
                    FinalScore += 10;
                }
                if (snake.body.Count % 16 == 0 && level == 3) // Переходим к поздравлениям
                {
                    FinalScore += 15;
                    level++;
                    Console.Clear();
                }
                if (level == 4) // Поздравление + финальные поинты
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("Congratuations, you have won this game " + name + "!!!!");
                    Console.SetCursorPosition(40, 11);
                    Console.WriteLine("Your Final Score was " + FinalScore);
                    Console.SetCursorPosition(40, 20);
                    Console.WriteLine("Press R to Restart");
                    Console.SetCursorPosition(40, 22);
                    Console.WriteLine("Press Any Other Key To Exit");
                    //Console.Clear();
                    var pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.R) // Чтобы начать игру заново после прохождения
                    {
                        level = 1;
                        Console.Clear();
                        Main(null);
                    }
                    else break;

                }
                snake.Draw();
                snake1.Draw();
                wall.Draw();
                f.FoodDrawer();
            }
        }
    }
}