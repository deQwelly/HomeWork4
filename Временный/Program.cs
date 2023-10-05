using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Временный
{
    internal class Program
    {
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
        public static void ArrayToLower(params string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].ToLower();
            }
        }

        static void Main(string[] args)
        {
            string[] arr = new string[] { "abc", "efd", "sdf", "abc" };
            Console.WriteLine(Array.FindIndex(arr, x => x.Equals("abc")));
            Console.WriteLine(MultiplyString("1", 5));
            Console.WriteLine(arr.Count(x => x.Equals("abc")));
            string[] arrstr = new string[] { "SDF", "SD", "SDF" };
            ArrayToLower(arrstr);
            foreach (string str in arrstr) { Console.WriteLine(str); }
        }
    }
}
