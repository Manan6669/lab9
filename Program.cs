using System;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Fight figth1 = new Fight(30, 67);
            Console.WriteLine(figth1.hp + " " + figth1.dm);
            figth1.Notify += DisplayMessage;
            figth1.Hill();
            figth1.Hill();
            figth1.Damage();
            figth1.Damage();

            Console.WriteLine("-----------------------------------------");

            Person person = new Person(60);
            Console.WriteLine(person.loss);
            person.Notify += DisplayMessage;
            person.Hill();
            person.Hill();
            person.Damage();
            person.Damage();
            person.Damage();


            Console.WriteLine("-----------------------------------------");


            Func<string, string> funcStr;
            string str = "H . e. e , e ., y ";

            Console.WriteLine($"Исходная строка:        {str}");
            funcStr = StringHandler.RemStr;
            Console.WriteLine(str = funcStr(str));
            funcStr = StringHandler.PemSpase;
            Console.WriteLine(str = funcStr(str));
            funcStr = StringHandler.AddToString;
            Console.WriteLine(str = funcStr(str));
            funcStr = StringHandler.Upper;
            Console.WriteLine(str = funcStr(str));
            funcStr = StringHandler.Lower;
            Console.WriteLine(str = funcStr(str));
           

        }
        private static void DisplayMessage(object sender, Game g)
        {
            Console.WriteLine(g.Message);
        }

        public delegate void fight(object sender, Game g);
        public class Game
        {
            public string Message { get; }
            public Game (string mess)
            {
                Message = mess;
            }
        }

        public class Fight
        {
            public event fight Notify;
            public int hp { get; set; }
            public int dm { get; set; }

            public void Hill()
            {
                if (hp<50)
                {
                    hp++;
                    Notify?.Invoke(this, new Game($"Персонаж был подхилен и его хп составляет {hp} "));
                }
                else
                {
                    Notify?.Invoke(this, new Game("Хп пероснажа максимально"));
                }
            }

            public void Damage()
            {
                dm -= 40;
                if (dm < 0)
                {
                    dm = 0;
                    Notify?.Invoke(this, new Game($"Урон персонажа отрицателен, пофиксите артефакты "));
                }
                else
                {
                    dm = 250;
                    Notify?.Invoke(this, new Game("Урон персонажа увеличился и составляет"+dm));

                }
            }
            public Fight(int num1, int num2)
                {
                    hp = num1;
                    dm = num2;
                }

        }

        public class Person
        {
            public event fight Notify;
            public int loss { get; set; }

            public Person(int num)
            {
                loss = num;
            }


            public void Hill()
            {
                loss -=20;
                if (loss<100)
                {
                    Notify?.Invoke(this, new Game($"Урон по персонажу составил {loss} "));
                }

                else
                {
                    loss = 0;
                    Notify?.Invoke(this, new Game("По вам не попали"));
                }
            }

            public void Damage()
            {
                if (loss !=0)
                {
                    loss += 20;
                    if (loss <0)
                    {
                        loss = 0;
                        Notify?.Invoke(this, new Game("Дамаг персонажа не уменьшился"));
                    }
                    else
                    {
                        Notify?.Invoke(this, new Game($"Урон персонажа уменьшился на {loss} "));
                    }
                }
                else
                {
                    Notify?.Invoke(this, new Game("Дамаг персонажа нормальный"));
                }
            }
        }


       public static class StringHandler
        {
            public static string RemStr(string str)
            {
                str = str.Replace(".", string.Empty);
                str = str.Replace(",", string.Empty);
                return str;
            }
            public static string AddToString(string str) => str += "oooooooooooo";
           
            public static string PemSpase(string str)
            {
                str.Replace(" ", string.Empty);
                return str;
            }
            public static string Upper(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str = str.Replace(str[i], char.ToUpper(str[i]));
                }
                return str;
            }
            public static string Lower(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str = str.Replace(str[i], char.ToLower(str[i]));
                }
                return str;
            }
        }

    }
}
