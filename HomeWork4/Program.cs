using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Program
    {
        public static int? GratestNumber(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else if (b > a)
            {
                return b;
            }
            else
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            ///Упражнение 5.1
            Console.WriteLine("Упражнение 5.1: Написать метод, возвращающий наибольшее из двух чисел." +
                " Входные\r\nпараметры метода – два целых числа. Протестировать метод.");
            try
            {
                Console.Write("Введите первое число (целое): ");
                if (int.TryParse(Console.ReadLine(), out int num1))
                {
                    Console.Write("Введите второе число (целое): ");
                    if (int.TryParse(Console.ReadLine(), out int num2))
                    {
                        int? result = GratestNumber(num1, num2);
                        if (result == null)
                        {
                            Console.WriteLine("Числа равны");
                        }
                        else
                        {
                            Console.WriteLine($"Наибольшее число: {result}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы неправильно указали второе число, или не указали вовсе.\n" +
                            "Указанное значение должно быть целым числом без посторонних символов");
                    }
                }
                else
                {
                    Console.WriteLine("Вы неправильно указали первое число, или не указали вовсе.\n" +
                            "Указанное значение должно быть целым числом без посторонних символов");
                }
            }
            catch
            {
                Console.WriteLine("");
            }

            ///
        }
    }
}
