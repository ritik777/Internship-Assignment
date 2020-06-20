using System;
using System.Collections.Generic;
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
    }
}
