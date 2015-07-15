using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestTopN
{
    public class LargestTopN
    {
        public LargestTopN() { }

        /// <summary>
        /// Read from a potential large file a list of numbers and provide a solution to return back
        /// an array of the largest top N elements.
        /// 
        /// The space complexity of this algorithm is driven by the size of the return top N elements. If
        /// this number is potentially large further analysis should be required to determine a more
        /// robust solution since reading in the first TOP N elements from the file initially could cause 
        /// memory problems.
        /// </summary>
        /// 
        /// <returns>An simple array of N largest top elements.</returns>
        public static int[] GetLargestTopN(int topNum)
        {
            // Create a top array of elements to hold the return collection of highest numbers
            List<int> topArray = new List<int>(topNum);

            // Open the FileStream reference
            using (FileStream fs = File.OpenRead("numbers.txt"))
            {
                TextReader sr = new StreamReader(fs, Encoding.UTF8);

                // Read the first topNum elements into the Array
                for (int i = 0; i < topNum; i++)
                {
                    int numberOnLine = Convert.ToInt32(sr.ReadLine());
                    topArray.Add(numberOnLine);
                }

                // Sort the ordered elements in descending order highest to lowest
                topArray.Sort(new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

                // Begin to read the rest of the elements and compare against the current top array
                while (true)
                {
                    string strNumOnLine = sr.ReadLine();
                    if (strNumOnLine == null)
                        break;

                    int numberOnLine = Convert.ToInt32(strNumOnLine);

                    // If the number read is less than or equal to the last element in the top array ignore
                    // as we are only interested in larger elements greater than the last current smallest element
                    if (numberOnLine <= topArray[topNum - 1])
                        continue;

                    // Add the element to the current list of array elements
                    topArray.Add(numberOnLine);              // List Add has a time complexity of O(1)

                    // C# List sorting uses QuickSort which is O(n log n) on average and O(n^2) worst case.
                    topArray.Sort(new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

                    // Remove the last index element since this is the previous smallest number and it is being 
                    // kicked out of the current top array due to the new addition above.
                    topArray.RemoveAt(topArray.Count - 1);   // List Remove has a time complexity of O(n)
                }
            }

            return (int[])topArray.ToArray();
        }

        /// <summary>
        /// Simple method to generate a file containing a give range of numbers.
        /// </summary>
        public static void GenerateNumbersFile()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);

            List<int> ll = new List<int>();

            // Open the FileStream reference
            using (FileStream fs = File.OpenWrite("numbers.txt"))
            {                
                TextWriter sw = new StreamWriter(fs, Encoding.UTF8);

                for (int i=0;  i<10000; i++)
                {
                    int rndVal = rnd.Next(1, 200000);
                    while (ll.Contains(rndVal))
                    {
                        rndVal = rnd.Next(1, 204323453);
                    }

                    ll.Add(rndVal);
                    sw.WriteLine(rndVal);
                }
            }
        }
    }
}
