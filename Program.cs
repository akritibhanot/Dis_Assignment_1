using System;
using System.Collections.Generic;

namespace Dis_Assignment_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the triangle:");
            int n = Convert.ToInt32(Console.ReadLine());
            PrintTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            PrintPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if SquareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = SquareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = DiffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email+bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        private static void PrintTriangle(int n)
        {
            try
            {
                if (n <= 0)
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                { 
                    for (int i = 1; i <= n; i++)   // Total number of Layers in the Pyramid
                    {
                        for (int j = 1; j <= (n - i); j++)
                            Console.Write(" ");    //  Loop for printing the spaces
                        for (int k = 1; k <= i; k++)
                            Console.Write('*');    //  Loop for the first half of the pyramid 
                        for (int k = (i - 1); k >= 1; k--)
                            Console.Write('*');   //   Loop for the second half of the pyramid 
                        Console.WriteLine();
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }

        }
        // Self-reflection (time taken, learning, and recommendations)
        // Timetaken
        // 1.Solving this question took me close to 2 hours.
        // Learning
        // 2.The question was very well structured that helped me learn and apply new concepts.Especially
        // loop.Also the examples given for this question helped me in understanding and 
        // implementing the code.
        // Recommendations
        // 3.A very well organized pattern printing question to help us learn various concepts.
        private static void PrintPellSeries(int n)
        {
            try
            {
                if (n <= 0)
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                {
                    int a = 0, b = 1, prev;
                    if (n == 1)
                    {
                        Console.Write(a);
                    }
                    else
                    {
                        Console.Write(a + ",");//prints the first number in the series
                        for (int i = 0; i < (n - 1); i++)//since the first number is printed the loop only has to run from 0 to n-1
                        {
                            if (i == n - 2)// this removes the last ','
                                Console.Write(b);
                            else
                                Console.Write(b + ",");
                            prev = b;// prev is a temporary variable 
                            b = (b * 2) + a;//the next number is calculated 
                            a = prev;//a gets the value of the temporary variable
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Self-reflection (time taken, learning, and recommendations)
        // Timetaken
        // 1.Solving this question took me close to 2 hours.
        // Learning
        // 2.The pell series question is very well structured that helped me learn and apply new concepts.Especially
        // loop and creating a temporary variable and assigning the value .Also the examples given for this question helped me in understanding and 
        // implementing the pell series code.
        // Recommendations
        // 3.A very well organized series printing question to help us learn various concepts.
        private static bool SquareSums(int c)
        {
            try
            {
                int flag = 1;
                for (int i = 0; i < c; i++) 
                {
                    for (int j = 0; j < c; j++)
                    {
                        if ((i * i) + (j * j) == c) //checks if i^2 + j^2 is equal to the input. Checks every possible combination till it finds a match.
                            flag = 0;
                    }
                }
                if (flag == 0) //if a match is found, it'll return true, else will return false.
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Self-reflection (time taken, learning, and recommendations)
        // Timetaken
        // 1.Solving this question took me close to 2 hours.
        // Learning
        // 2.The SquareSums question is very well structured that helped me learn and apply new concepts.Especially
        // nested loop and conditional statment .Also the examples given for this question helped me in understanding and 
        // implementing the sumsquares code.
        // Recommendations
        // 3.A very well organized sumsquares code to help us learn various concepts.
        private static int DiffPairs(int[] nums, int n)
        {
            try
            {
                List<int> pairs = new List<int>();//will contain all the elements that have been read in the loop
                int count = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    int flag = 0;
                    for (int k = 0; k < pairs.Count; k++)//if an element is repeated, will break out of the loop and move to the next element in the array
                    {
                        if (pairs[k] == nums[i])
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        for (int j = 0; j < nums.Length; j++)//inner loop
                        {
                            if (i != j)
                            {
                                if (Math.Abs(nums[i] - nums[j]) == n)//checks for the absolue difference between elements of the array and increments count if conditions are met.
                                {
                                    count++;
                                    pairs.Add(nums[j]);//if conditions are met, nums[j] is added to the list 
                                    break;
                                }
                            }
                        }
                    }
                    pairs.Add(nums[i]);//i nums[i] is added to the list after each itteration.
                }
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }

        // Self-reflection (time taken, learning, and recommendations)
        // Timetaken
        // 1.Solving this question took me close to 5 hours.
        // Learning
        // 2.The DiffPairs question is very well structured that helped me learn and apply new concepts.Especially
        //  list,loop and conditional statment .Also the examples given for this question helped me in understanding and 
        // implementing the DiffPairs code.
        // Recommendations
        // 3.A very well organized DiffPairs code to help us learn various concepts.
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                List<string> n = new List<string>();
                int count = 1;
                foreach (string email in emails)
                {
                    string[] e = email.Split('@');// remove all characters folloing the '@' along with '@'
                    string[] name = e[0].Split('+');// remove all characters following the '+' along with '+' 
                    string names = name[0];
                    List<char> charsToRemove = new List<char>();
                    charsToRemove.Add('.');
                    charsToRemove.ForEach(c => names = names.Replace(c.ToString(), String.Empty)); // removes only all of the '.'
                    n.Add(names + e[1]);//this list contains the local name and domain names after removing the necessary characters from local name
                }

                
                for (int i = 1; i < n.Count; i++)// searches for the number of unique names
                {
                    int j = 0;
                    for (j = 0; j < i; j++)
                        if (n[i] == n[j])
                            break;
                    if (i == j)
                        count++;
                }
                return count;// returns the number of unique names
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        // Self-reflection (time taken, learning, and recommendations)
        // Timetaken
        // 1.Solving this question took me close to 6 hours.
        // Learning
        // 2.The Unique Email question is very well structured that helped me learn and apply new concepts.Especially
        //  list,String function,loop and conditional statment .Also the examples given for this question helped me in understanding and 
        // implementing the Unique Email code.
        // Recommendations
        // 3.A very well organized Unique Emails code to help us learn various concepts.
        private static string DestCity(string[,] paths)
        {
            try
            {
                string destination = "";
                List<string> destcity = new List<string>();
                List<string> path = new List<string>();
                int count = 1;
                foreach (string p in paths)
                {
                    string cities;
                    cities = p;
                    if (count % 2 == 0)
                        cities += "-d"; //this differentiates the elements in the 0th and 1st position in the inner array.
                    path.Add(cities);
                    count++;
                }
                for (int i = 0; i < path.Count; i++)
                {
                    int flag = 0;
                    for (int j = 0; j < path.Count; j++)
                    {
                        if (path[i] == path[j] + "-d" || path[i] + "-d" == path[j]) //check if the element exists in the 0th and 1st position in the array and excludes them from the new list
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                        destcity.Add(path[i]);
                }
                foreach (string city in destcity) //this list will only contain the unique elements in the array 
                {
                    if (city.Contains("-d".ToString())) // this looks for the unique elements with the '-d' characters we added earlier to all elements of the 1st position in the inner array. 
                    {
                        string[] c = city.Split('-');
                        destination = c[0];
                    }
                }
                return destination;// returns destination city
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

// Self-reflection (time taken, learning, and recommendations)
// Timetaken
// 1.Solving this question took me close to 10 hours.
// Learning
// 2.The destination city question is very well structured that helped me learn and apply new concepts.Especially
// list, loop and string functions.Also the examples given for each question helped in understanding and 
// implementing the code.Each question had multiple inputs and expected outputs that made testing the code a lot easier.
// Recommendations
// 3.A very well organized destination city Question with the right mix of topics to help us learn various concepts.