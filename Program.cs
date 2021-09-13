using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignmnet1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is", rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */
        private static bool HalvesAreAlike(string s)
        {
            try
            {
                // write your code here
                string input = s;
                int n = input.Length;
                //Taking input into character arrays
                char[] myCharArray = input.ToCharArray();
                char[] firstArray = new char[n / 2];
                char[] secondArray = new char[n / 2];
                //Splliting both arrays
                firstArray = myCharArray.Take(myCharArray.Length / 2).ToArray();
                secondArray = myCharArray.Skip(myCharArray.Length / 2).ToArray();
                int count1 = 0;
                int count2 = 0;
                //Checking for vowels in both split arrays
                for (int i = 0; i < n / 2; i++)

                {
                    if (firstArray[i] == 'a' || firstArray[i] == 'e' || firstArray[i] == 'i' || firstArray[i] == 'o' || firstArray[i] == 'u')
                    {
                        count1++;
                    }
                }


                for (int j = 0; j < n / 2; j++)
                {
                    if (secondArray[j] == 'a' || secondArray[j] == 'e' || secondArray[j] == 'i' || secondArray[j] == 'o' || secondArray[j] == 'u')
                    {
                        count2++;
                    }
                }
                if (count1 == count2)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception)
            {
                throw;
            }

        }
        //Self-reflection- The problem was good beginner exercise for character arrays. I got to learn about Skip and Take methods.

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
                // write your code here.


                string input = s;
                //Taking a string of the alphabets to compare it with
                string alphabets = "abcdefghijklmnopqrstuvwxyz";
                //Converting into respective character arrays
                char[] myCharArray = input.ToCharArray();
                char[] alphabet = alphabets.ToCharArray();
                //Intiating a loop to comapre two arrays
                for (int i = 0; i < 26; i++)

                {
                    bool contains = false;
                    for (int j = 0; j < myCharArray.Length; j++)
                    {
                        if (alphabet[i] == myCharArray[j])
                            contains = true;

                    }

                    if (contains == false)
                        return false;

                }

                return true;

            }
            catch (Exception) {
                throw;
            }

        }
        //Self-reflect : Another good problem on for loops using if condition.
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                // write your code here
                int maxwealth = 0;

                //Intializing loop through accounts
                for (int i = 0; i < accounts.Rank; i++)
                {
                    int j = accounts.GetLength(i);
                    int wealth = 0;
                    for (int index = 0; index < j; index++)
                    {
                        wealth = wealth + accounts[i, index];
                    }
                    //Comparing loop output with intialized maxwealth of 0;
                    if (wealth > maxwealth)
                    {
                        maxwealth = wealth;
                    }
                }


                return maxwealth;

            }
            catch (Exception)
            {
                throw;
            }
        }
        //Self-reflect : This problem got me to work on multi-dimensional arrays.
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                // write your code here.

                //Converting inputs to character arrays
                char[] stonesarray = stones.ToCharArray();
                char[] jewelsarray = jewels.ToCharArray();
                int count = 0;
                //Iterating through stones array to check for  jewels array
                for (int i = 0; i < stonesarray.Length; i++)
                {
                    if (Array.IndexOf(jewelsarray, stonesarray[i]) > -1)
                        count++;
                }
                return count;
        }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        //SR : I liked this problem,because I got to know about the Array.IndexOf method.It was cool.


        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                // write your code here.
                //Converting input to character arrays
                char[] stringarray = s.ToCharArray();
                //Intializing a new array the length of input array
                char[] rotatedarray = new char[stringarray.Length];
                //Iterating the elements of indices array into rotated array 
                for (int i = 0; i < indices.Length; i++)
                {
                    rotatedarray[indices[i]] = stringarray[i];
                }
                //Storing it in a string
                string charToString = new string(rotatedarray);
                Console.WriteLine(charToString);
                return charToString;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        //SR- This was a good problem in use of character arrays again.

        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {
                //Intializing a empty target array
                int[] target = new int[nums.Length];
                //
                for (int i = 0; i < index.Length; i++)
                {
                    if (target[index[i]] == 0)
                    {
                        target[index[i]] = nums[i];
                        
                    }
                    else
                    {
                        for (int j = target.Length - 1; j > index[i]; j--)
                        {
                            target[j] = target[j - 1];
                        }

                        target[index[i]] = nums[i];
                    }
                }
                return target;
               
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
