using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestTopN
{
    class Program
    {
        /// <summary>
        /// An algorithm when given an arbitrarily large file containing individual numbers on each line 
        /// (e.g. 200Gb file) and a number N, will output the largest N numbers from highest first. 
        /// </summary>
        static void Main(string[] args)
        {
            // Call the algorithm to retrieve the largest top 100 numbers from the local test file.
            int[] topNArray = LargestTopN.GetLargestTopN(100);

            Console.Out.Write("[");
            for (int i = 0; i < topNArray.Length; i++)
            {
                Console.Out.Write(topNArray[i]);
                if (i != topNArray.Length - 1)
                    Console.Out.Write(",");
            }
            Console.Out.Write("]");
        }
    }
}
