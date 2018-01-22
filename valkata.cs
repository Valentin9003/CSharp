using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            List<double> rain = new List<double>();
            bool f = true;
            for (int i = 0; i < n; i++)
            {



                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int raindropsCount = input[0];
                int squareMeters = input[1];


                if (raindropsCount != 0 || squareMeters != 0)
                {


                    double result = (double)raindropsCount / (double)squareMeters;
                    rain.Add(result);

                }

                if (raindropsCount == 0 || squareMeters == 0)
                {
                    f = false;
                }
            }
            double ddd = rain.Sum();

            if (f)
            {
                ddd = ddd / p;
                Console.WriteLine("{0:f3}", ddd);
            }
            else
            {
                Console.WriteLine("{0:f3}", ddd);
            }


        }

    }
}