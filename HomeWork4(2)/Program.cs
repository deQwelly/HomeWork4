using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HomeWork4_2_
{
    internal class Program
    {
        public static string ShowArray(params int[] arr)
        {
            string str = "";
            foreach(int i in arr)
            {
                str += i.ToString() + " ";
            }
            return str;
        }

        public static int DoSomethingWithArray(ref int prod, out int avg, params int[] array)
        {
            int sum = 0;
            foreach (int i in array)
            {
                prod *= i;
                sum += i;
            }
            avg = sum / array.Length;
            return sum;
        }

        public static string MultiplyString(string str, int m)
        {
            if (m != 0)
            {
                string temp = str;
                for (int i = 0; i < (m - 1); i++)
                {
                    str += temp;
                }
                return str;
            }
            else
            {
                return "";
            }
        }

        public enum GrumnbleLvl
        {
            Low_lvl = 1,
            Mid_lvl = 2,
            High_lvl = 3
        }

        public static void ArrayToLower(params string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].ToLower().Replace("!", "");
            }
        }

        public struct Grandpa
        {
            public string name;
            public GrumnbleLvl lvl;
            public string[] phrases;
            public byte bruises_count;
            public void BeatGrandpa(params string[] bad_words)
            {
                ArrayToLower(bad_words);
                ArrayToLower(phrases);
                foreach (string word in phrases)
                {
                    if (bad_words.Count(x => x.Equals(word)) > 0)
                    {
                        bruises_count++;
                    }
                }                
            }
        }

        static void Main(string[] args)
        {
            ///Упражнение 1
            Console.WriteLine("Упражнение 1: Вывести на экран массив из 20 случайных чисел. " +
                "Ввести два числа из этого массива,\r\nкоторые нужно поменять местами. Вывести на экран получившийся массив.");
            int[] arr = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                arr[i] = rnd.Next(100, 1000);
            }
            Console.WriteLine(ShowArray(arr));
            Console.Write("Введите первый элемент массива: ");
            try
            {
                if (int.TryParse(Console.ReadLine(), out int value1))
                {
                    Console.Write("Введите второй элемент массива: ");
                    if (int.TryParse(Console.ReadLine(), out int value2))
                    {
                        int value1_indx = Array.FindIndex(arr, x => x == value1);
                        int value2_indx = Array.FindIndex(arr, x => x == value2);
                        if ((value1_indx != -1) & (value2_indx != -1))
                        {
                            int temp = arr[value1_indx];
                            arr[value1_indx] = arr[value2_indx];
                            arr[value2_indx] = temp;
                            Console.WriteLine(ShowArray(arr));
                        }
                        else
                        {
                            if ((value1_indx == -1) & (value2_indx == -1))
                            {
                                Console.WriteLine("Ни одно из введенных значений не является элементом массива");
                            }
                            else if (value1_indx == -1)
                            {
                                Console.WriteLine("Первое введенное значение не является элементом массива");
                            }
                            else
                            {
                                Console.WriteLine("Второе введенное значение не являтеся элементом массива");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовсе\n" +
                            "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                    }
                }
                else
                {
                    Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовсе\n" +
                            "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }

            ///Упражнение 2
            Console.WriteLine("\nУпражнение 2: Написать метод, где в качества аргумента будет передан массив" +
                "\nВывести сумму элементов массива (вернуть). Вывести (ref) произведение массива.\n" +
                "Вывести (out) среднее арифметическое в массиве.");
            Console.Write("Сколько элементов массива вы хотите задать?: ");
            try
            {
                if (byte.TryParse(Console.ReadLine(), out byte count))
                {
                    int[] arr2 = new int[count];
                    bool flag = true;
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write($"Введите {i + 1}-ое число массива: ");
                        if (int.TryParse(Console.ReadLine(), out int temp))
                        {
                            arr2[i] = temp;
                        }
                        else
                        {
                            Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовсе\n" +
                                "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        int prod = 1;
                        Console.WriteLine($"Сумма элементов массива = {DoSomethingWithArray(ref prod, out int avg, arr2)}\n" +
                            $"Произведение массива = {prod}\nСреднее арифметическое = {avg}");
                    }

                }
                else
                {
                    Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовсе\n" +
                                    "Проверьте: число должно быть целым, не должно содержать посторонних символов");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнении программы");
            }

            ///Упражнение 3
            Console.WriteLine("\nУпражнение 3: Пользователь вводит числа. Если числа от 0 до 9, то необходимо " +
                "в консоли нарисовать\r\nизображение цифры в виде символа #.Если число больше 9 или меньше 0, " +
                "то консоль\r\nдолжна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. " +
                "Если\r\nпользователь ввёл не цифру, то программа должна выпасть в исключение. Программа\r\nзавершает " +
                "работу, если пользователь введёт слово: exit или закрыть (оба варианта\r\nдолжны сработать) - консоль закроется.");
            Console.Write("Введите цифру от 1 до 9 или напишите exit для завершения программы: ");
            string enterd_value = Console.ReadLine().ToLower();
            try
            {
                if (byte.TryParse(enterd_value, out byte number))
                {
                    if ((number >= 0) & (number <= 9))
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            if (i == 2)
                            {
                                Console.WriteLine("  " + MultiplyString(number.ToString(), 12));
                            }
                            if (i == 4)
                            {
                                Console.WriteLine(MultiplyString(number.ToString(), 12));
                            }
                            else
                            {
                                Console.WriteLine($"{MultiplyString(" ", (6 - i))}{number}      {number}");
                            }
                        }
                    }
                    else if ((enterd_value.Equals("exit")) || (enterd_value.Equals("выход")))
                    {
                        Console.WriteLine("Переходим к следующему упражнению...");
                    }
                    else if ((number < 0) || (number > 9))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(MultiplyString(" ", 120));
                        Thread.Sleep(3000);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовсе\n" +
                                        "Проверьте: число должно быть целым, не должно содержать посторонних символов");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }

            ///Упражнение 4
            Console.WriteLine("\nУпражнение 4: Создать структуру Дед. У деда есть имя, уровень ворчливости" +
                " (перечисление), массив\r\nфраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество" +
                " синяков от ударов\r\nбабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное" +
                " количество фраз для\r\nворчания. Напишите метод (внутри структуры), который на вход принимает" +
                " деда,\r\nсписок матерных слов (params). Если дед содержит в своей лексике матерные слова" +
                " из\r\nсписка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.");

            try
            {
                Grandpa grandpa1, grandpa2, grandpa3, grandpa4, grandpa5;
                grandpa1.name = "Василич";
                grandpa1.lvl = (GrumnbleLvl)2;
                grandpa1.bruises_count = 0;
                grandpa1.phrases = new string[] { "Шило мне в тапок!", "Дураки!", "Проститутки!", "Садамиты!" };

                grandpa2.name = "Михалыч";
                grandpa2.lvl = (GrumnbleLvl)3;
                grandpa2.bruises_count = 0;
                grandpa2.phrases = new string[] { "Проститутки!", "Говнюки!", "Гады!", "Мерзавцы!" };

                grandpa3.name = "Петрович";
                grandpa3.lvl = (GrumnbleLvl)1;
                grandpa3.bruises_count = 0;
                grandpa3.phrases = new string[] { "Садамиты!", "Шило мне в тапок", "Зараза!", "Идиот!" };

                grandpa4.name = "Палыч";
                grandpa4.lvl = (GrumnbleLvl)2;
                grandpa4.bruises_count = 0;
                grandpa4.phrases = new string[] { "Проститутки!", "Екарный Бабай!", "Дураки!", "Зараза!" };

                grandpa5.name = "Евгенич";
                grandpa5.lvl = (GrumnbleLvl)3;
                grandpa5.bruises_count = 0;
                grandpa5.phrases = new string[] { "Проститутки!", "Идиот!", "Говнюки!", "Садамиты!" };

                Console.WriteLine("\nШило мне в тапок, Дураки, Проститутки, Садамиты, Гады, Мерзавцы, Зараза, Идиот, " +
                    "Екарный Бабай", "Говнюки");
                Console.WriteLine("Из предложенных слов и фраз выберите 5");
                string[] user_phrases = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Введите {i + 1}-ое слово или фразу: ");
                    user_phrases[i] = Console.ReadLine();
                }

                grandpa1.BeatGrandpa(user_phrases);
                grandpa2.BeatGrandpa(user_phrases);
                grandpa3.BeatGrandpa(user_phrases);
                grandpa4.BeatGrandpa(user_phrases);
                grandpa5.BeatGrandpa(user_phrases);

                Console.WriteLine("Количество синяков: ");
                Console.WriteLine($"{grandpa1.name} - {grandpa1.bruises_count}");
                Console.WriteLine($"{grandpa2.name} - {grandpa2.bruises_count}");
                Console.WriteLine($"{grandpa3.name} - {grandpa3.bruises_count}");
                Console.WriteLine($"{grandpa4.name} - {grandpa4.bruises_count}");
                Console.WriteLine($"{grandpa5.name} - {grandpa5.bruises_count}");
            }
            catch
            {
                Console.WriteLine("Ошибка при выполнении программы");
            }
        }
    }
}
