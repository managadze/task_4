using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskk_4
{
    class Program
    {
        static void Show(int[] mas)
        {
            foreach (int d in mas)
            {
                Console.Write(d + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] digits = new int[158];//результат
            int[] mas2 = new int[80];//для умножения
            int[] sum1 = new int[158];
            int[] sum2 = new int[159];

            int n = 21;
            for (int i = 0; i < mas2.Length; i++)
            {
                mas2[i] = n;
                n++;
            }
            long fak = 1;
            for (int i = 1; i < 21; i++)
            {
                fak *= i;
            }
            int temp = 0;
            int[] ddd = fak.ToString().Select(c => (int)char.GetNumericValue(c)).ToArray();
            for (int i = 0; i < ddd.Length; i++)
            {
                digits[digits.Length - 1 - i] = ddd[ddd.Length - 1 - i];
            }

            for (int i = 0; i < mas2.Length; i++)
            {
                for (int x = 0; x < digits.Length; x++)
                {
                    sum1[digits.Length - 1 - x] = ((digits[digits.Length - 1 - x] * (mas2[i] % 10)) % 10 + temp) % 10;
                    temp = ((digits[digits.Length - 1 - x] * (mas2[i] % 10)) + temp) / 10;
                }
                temp = 0;
                for (int x = 0; x < digits.Length; x++)
                {
                    sum2[sum2.Length - 2 - x] = ((digits[digits.Length - 1 - x] * (mas2[i] / 10)) % 10 + temp)%10;
                    temp = ((digits[digits.Length - 1 - x] * (mas2[i] / 10))+temp) / 10;
                }
                temp = 0;
                for (int y = 0; y < sum1.Length; y++)
                {
                    digits[digits.Length - 1 - y] = ((sum1[sum1.Length - 1 - y] + sum2[sum2.Length - 1 - y]) % 10 + temp)%10;
                    temp = ((sum1[sum1.Length - 1 - y] + sum2[sum2.Length - 1 - y])+temp) / 10;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("100! = ");
            Console.ResetColor();
            Show(digits);
            Console.ReadKey();
        }
    }
}
