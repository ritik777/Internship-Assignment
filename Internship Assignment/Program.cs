using System;
using System.Globalization;

namespace Internship_Assignment
{
    class Program
    {

       
        static void Main(string[] args)
        {
            int y =LongestSubstring("cccpoiijklmnoo");
            Console.WriteLine(y);
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
    }
}
