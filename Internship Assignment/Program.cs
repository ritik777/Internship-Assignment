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
            Console.Write("Enter the string");
            Console.WriteLine("    ");
            String s = Console.ReadLine();
            Console.WriteLine("    ");
            int y =LongestSubstring(s);
            Console.WriteLine("Longest substring in " + s +" has length " + y);


            Console.WriteLine(" ");
            Console.WriteLine("enter number of lines for pascal triangle");
            Console.WriteLine(" ");
            int num_lines1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pascal triangle is as follows");
            PascalTriangle(num_lines1);

            Console.WriteLine(" ");
            Console.WriteLine("enter kth row to find in pascal triangle");
            Console.WriteLine(" ");
            int k_line1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("elements ar line" +k_line1+ "are as follows");
            Console.WriteLine(" ");
            FindPascalRow(k_line1);

           



            Console.WriteLine("  ");
            int[] q4 = new int[] { 6, 21, 100, 6, 21, 11 };
            Console.WriteLine("Duplicates in" + " { 6, 21, 100, 6, 21, 11 }" + "are");
            Console.WriteLine("");
            ContainsDuplicate(q4);
            Console.WriteLine("");
            Console.WriteLine("  ");
            int[] q5 = new int[] { 3, 47, 200, 47, 3, 100000, 200, 3, 200 };
            Console.WriteLine("Duplicates in" + " { 3, 47, 200, 47, 3, 100000, 200, 3, 200 }" + "are");
            Console.WriteLine("");
            ContainsDuplicate(q5);



        }

        public static int LongestSubstring(String s)
        {
            /*To calculate the longest substring in a string with no repeating characters
•	My approach was to check each subsequent character in the string with the characters behind.
•	If there is a match of a subsequent character with any character behind, then I break the string using substr function till that subsequent character and determine length of that substring.

For Instance: if the string is “a b d a d f” 
Then I will have pointer 1 at first place i.e  ‘a’. pointer 2 at second place i.e ‘b’

1)	b will be checked against a. No match then pointer 2 will move to ‘d’.
2)	pointer 2 will backtrace and check b and a.No match then pointer 2 moves to ‘a’.
3)	pointer 2 will backtrace and check ‘d’, ‘b’ and ‘a’. there is a match
4)	substring till 4th place a i.e “abd” is taken out. Length is determined.
5)	Pointer 1 is changed to now 4th place ‘a’ (position of match) and pointer 2 to one position after that.i.e ‘d’. 
The whole process from 1 repeat but for subsequent characters till end of string

The substring with largest length wins.*/



            int counter = 0;
            //converting string to character array
            char[] char_array = s.ToCharArray();

            //initializing length
            int length = 0;
            int new_length = 0;
            int i = 1;

            for ( i = 1; i < char_array.Length; i++)
            {  // inner loop decrements till counter
                for (int j = i - 1; j >= counter; j--)
                {
                    // if match is found
                    if (s[i] == s[j])
                    {
                        // we need l for substring function to know till what length are  we extracting string
                        int l = i - counter;
                        // length of substring till counter i
                        new_length = s.Substring(counter,l ).Length;
                       
                         /*for instance if pqqkew is string then we got the substring till pq
                         now new counter is at q of qkew and i will move to k and backtracing will restart*/
                         
                        //new counter
                        counter = i;               
                        if (new_length > length)
                        {
                            length = new_length;
                        }
                        break;
                    }

                }

            }
            //tail end substring length match to determine largest length
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

            //created a dictionary with key and values as integers
            Dictionary<int, int> myDict = new Dictionary<int, int>();
            //initialized value to 1
            int value = 1;
            // iterated through each element of the array
            for (int i = 0; i < arr.Length; i++) {
                 /*if dictionary does not have that element has 
                the key push that element as the key with value as 1*/
                if (!myDict.ContainsKey(arr[i]))
                {
                    myDict.Add(arr[i], value);
                }
                else {
                    // else if key as already present then increment value of 1 that denotes count of that element
                    myDict[arr[i]] = value + 1;
                }
            
            }

            //print keys with values greater than 1
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
            we can see 1+1 and 2+1 in line 3 is giving -> 3 and 3 surrounded by 1 in line 4. 
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
                                     [3][3] = [2][1] + [2][2]
                                     [3][3] = 1
                        operation to perform similarly for each line
             
             
             
             */

            //creating a 2 dimensional array of size numrows
            int[,] array = new int[numrows,numrows];

            for (int i = 0; i < numrows; i++) {
                for (int j = 0; j <= i; j++) {
                    /*logic for implementing corners as 1 and middle 
                    elements as addition of immediate upper elements*/
                    if (j == 0 || j == i)
                    {
                        array[i, j] = 1;
                    }
                    else {
                    // if its not corners then array[i,j] is addition of upper elements in the triangles
                        array[i, j] = array[i - 1, j-1] + array[i - 1, j];
                    }
                }
            }
            //printing the array that results in a pascal triangle
            for (int i = 0; i < numrows; i++) {
                for (int j = 0; j <= i; j++) {
                    Console.Write(" " + array[i,j]);
                }
                Console.WriteLine(" ");
            }
            
        }

        public static void FindPascalRow(int k) {
            /* To find the kth row from pascal triangle:
             * I did not want to use the exact code as above and print the last line.
             * Made some code and logic changes to accomplish the goal

            Algorithm :
            * created two single dimensional arrays with size k.
            * one of them being temporary array to solve the preceeding line for pascals triangle
            * copied temporary array to main array for each iteration until k iterations.
       */
            // initialized the temp array and main_array
            int[] temp = new int[k];
            int[] main_array = new int[k];

            // outer loop denotes each line
            for (int i = 0; i < k; i++) {
                // inner loop denotes values in a line
                for (int j = 0; j <= i; j++) {
                    // code to convert corner values to 1
                    if (j == 0 || j == i)
                    {
                        temp[j] = 1;
                    }
                    else {
                        // temp array includes values in that line which were computed from previous line
                        temp[j] = main_array[j-1] + main_array[j];
                    }
                }
                // temp array is copied to main array, to compute new line values from this main array.
                // The values in new line is stored in temp and is then copied to main array everytime until k is reached.
                temp.CopyTo(main_array, 0);
            }
            //printing values of kth line
            for (int i = 0; i < main_array.Length; i++) {
                Console.Write(" " + main_array[i]);
            }
        
        
        }
    }
}
