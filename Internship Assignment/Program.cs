using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Internship_Assignment
{
    class Program
    {

       
        static void Main(string[] args)
        {
            Console.Write("Distinguish Strings are");
            int y =LongestSubstring("cccpoiijklmnooasdfghjklqwer");
            Console.WriteLine(y);

            int[] q4 = new int[] { 2, 2, 2, 4, 4, 4,6,7,8,9,9 };
            ContainsDuplicate(q4);

            Console.WriteLine(" ");
            PascalTriangle(5);

        }

        public static int LongestSubstring(String s)
        {

            //dg
            int counter = 0;
            //converting string to character array
            char[] char_array = s.ToCharArray();

            //initializing length
            int length = 0;
            int new_length = 0;
            int i = 1;

            for ( i = 1; i < char_array.Length; i++)
            {
                for (int j = i - 1; j >= counter; j--)
                {
                    if (s[i] == s[j])
                    {
                        int l = i - counter;
                        new_length = s.Substring(counter,l ).Length;
                        counter = i;
                        if (new_length > length)
                        {
                            length = new_length;
                        }
                        break;
                    }

                }

            }
            if (i == char_array.Length)
            {
                int w = i - counter;
                int last = s.Substring(counter, w).Length;
                if (last > length)
                {
                    length = last;
                }
            }
            return length;

        }
        public static void ContainsDuplicate(int[] arr) {

            Dictionary<int, int> myDict = new Dictionary<int, int>();
            int value = 1;
            for (int i = 0; i < arr.Length; i++) {
                if (!myDict.ContainsKey(arr[i]))
                {
                    myDict.Add(arr[i], value);
                }
                else {
                    myDict[arr[i]] = value + 1;
                }
            
            }

            foreach (KeyValuePair<int, int> item in myDict)
            {
                if (item.Value > 1)
                {
                    Console.Write(" " + item.Key);
                }
            }

        }

        public static void PascalTriangle(int numrows)
        {
            /*pascal triangle is as :
            1
            11
            121
            1331
            14641

            As we can see each element below is just an addition of its immediate numbers
            above with 1 in the corners. I will create an algorithm which does the same
            for instance : line 2 and 3 
            11
            121
            we can see how 1+1 in line 2 is giving 2 to the line 3 surrounded by one

            similarly 
            121
            1331
            we can see 1+1 and 2+1 in line 3 is giving -> 3 and 3 surrounded by 1 to line 4. 
             */

            /*Algorithm:
             I am solving pascal triangle using multidimensional array as data structure
             1) create two dimensional array of dimensions (linesize * linesize)
             2) fill elements in array such that corners are 1 and middle elements are addition of immediate upper line numbers
             3) for instance  line 3 and 4 of pascals triangle is 
             121
             1331
             so array addition for line 3 which is derived from line 2 or array with 2nd line
                              , array[3][1] =1 
                                     [3][2] = [2][0] + [2][1]
                                     [3][3] = [2][2] + [2][2]
                                     [3][3] = 1
                        operation to perform similarly for each line
             
             
             
             */

            //creating a 2 dimensional array of size numrows
            int[,] array = new int[numrows,numrows];

            for (int i = 0; i < numrows; i++) {
                for (int j = 0; j <= i; j++) {
                    if (j == 0 || j == i)
                    {
                        array[i, j] = 1;
                    }
                    else {
                        array[i, j] = array[i - 1, j-1] + array[i - 1, j];
                    }
                }
            }

            for (int i = 0; i < numrows; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write(" " + array[i,j]);
                }
                Console.WriteLine(" ");
            }
            
        }
    }
}
