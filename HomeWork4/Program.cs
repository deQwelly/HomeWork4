using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static void ChangeValues(ref string value1, ref string value2)
        {
            string temp = value1;
            value1 = value2;
            value2 = temp;
        }

        public static void ComputeFactorial(string number, out ulong? factorial)
        {
            if (ulong.TryParse(number, out ulong factorial_end))
            {
                if (factorial_end != 0)
                {
                    try
                    {
                        checked
                        {
                            factorial = 1;
                            for (ulong i = 1; i <= factorial_end; i++)
                            {
                                factorial *= i;
                            }
                        }
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Факториал заданного числа слишком большой. Переполнение");
                        factorial = null;
                    }
                }
                else
                {
                    factorial = null;
                    Console.WriteLine("Ошибка. Введите число > 0");
                }

            }
            else
            {
                factorial = null;
                Console.WriteLine("Ошибка. Некорректный ввод данных. Указанное число слишком большое или < 0.\n" +
                    "Проверьте так же, не ввели ли вы посторонние символы");
            }
        }

        public static ulong ComputeFactorialRecurse(ulong x)
        {
            try
            {
                if (x == 1)
                {
                    return 1;
                }
                return checked(x * ComputeFactorialRecurse(x - 1));
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Вы ввели слишком большое число. При подсчсете факториала произошло переполнение");
                return 0;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Факториал указанного числа слишком большой. Переполнение");
                return 0;
            }
        }

        public static uint? GetFibonacciValue(ulong n)
        {
            try
            {
                if (n == 0)
                {
                    return 0;
                }
                if (n == 1)
                {
                    return 1;
                }
                return GetFibonacciValue(n - 1) + GetFibonacciValue(n - 2);
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Слишком много операций. Переполнение");
                return null;
            }
        }

        public static uint ComputeGratestCommonDivision(uint a, uint b)
        {
            while (a % b != 0)
            {
                uint temp = b;
                b = a % b;
                a = temp;
            }
            return b;
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
            catch (OverflowException)
            {
                Console.WriteLine("Вы указали слишком большое или слишком маленькое число." +
                    "Введите значение поменьше");
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }

            ///Упражнение 5.2
            Console.WriteLine("\nУпражнение 5.2 Написать метод, который меняет местами значения" +
                " двух передаваемых\r\nпараметров. Параметры передавать по ссылке. Протестировать метод.");
            try
            {
                Console.Write("Введите 1-ый параметр: ");
                string value1 = Console.ReadLine();
                if (!value1.Equals(""))
                {
                    Console.Write("Введите 2-ой параметр: ");
                    string value2 = Console.ReadLine();
                    if (!value2.Equals(""))
                    {
                        ChangeValues(ref value1, ref value2);
                        Console.WriteLine($"{value1} {value2}");
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели пустой параметр");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели пустой параметр");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }

            ///Упражнение 5.3
            Console.WriteLine("\nУпражнение 5.3 Написать метод вычисления факториала" +
                " числа, результат вычислений\r\nпередавать в выходном параметре. Если" +
                " метод отработал успешно, то вернуть значение true;\r\nесли в процессе" +
                " вычисления возникло переполнение, то вернуть значение false. Для\r\nотслеживания" +
                "переполнения значения использовать блок checked.");
            Console.Write("Введите число, факториал которого хотите найти: ");
            try
            {
                ComputeFactorial(Console.ReadLine(), out ulong? factorial);
                if (factorial != null)
                {
                    Console.WriteLine($"Факториал заданного числа: {factorial}");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }

            /// Упражнение 5.4
            Console.WriteLine("\nУпражнение 5.4: Написать рекурсивный метод вычисления факториала числа.");
            try
            {
                Console.Write("Введите число, факториал которого хотите найти: ");
                if (ulong.TryParse(Console.ReadLine(), out ulong number_to_factorial))
                {
                    ulong fact = ComputeFactorialRecurse(number_to_factorial);
                    if (fact != 0)
                    {
                        Console.WriteLine($"Факториал заданного числа: {fact}");
                    }
                }
                else
                {
                    Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовспе.\n" +
                        "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }

            ///Домашнее задание 5.1
            Console.WriteLine("\nДомашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел" +
                "\r\n(алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех\r\nнатуральных чисел.");
            Console.Write("Введите первое число: ");
            try
            {
                if (uint.TryParse(Console.ReadLine(), out uint number1))
                {
                    Console.Write("Введите второе число: ");
                    if (uint.TryParse(Console.ReadLine(), out uint number2))
                    {
                        if ((number1 != 0) & (number2 != 0))
                        {
                            Console.WriteLine($"НОД этих чисел: {ComputeGratestCommonDivision(number1, number2)}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовспе.\n" +
                        "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                    }
                }
                else
                {
                    Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовспе.\n" +
                        "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                }
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("При поиске НОДа данных чисел произошло переполнение." +
                    " Укажите значения меньше");
            }

            ///Домашнее задание 5.2
            Console.WriteLine("\nДомашнее задание 5.2: Написать рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи.");
            Console.Write("Введите номер числа из ряда Фибоначчи: ");
            try
            {
                if (ulong.TryParse(Console.ReadLine(), out ulong number))
                {
                    Console.WriteLine(GetFibonacciValue(number));
                }
                else
                {
                    Console.WriteLine("Введено число неправильного типа, не число или не введено ничего вовспе.\n" +
                            "Проверьте: число должно быть целым > 0, не должно содержать посторонних символов");
                }
            }
            catch
            {
                Console.WriteLine("Ошибка в ходе выполнения программы");
            }
        }
    }
}
