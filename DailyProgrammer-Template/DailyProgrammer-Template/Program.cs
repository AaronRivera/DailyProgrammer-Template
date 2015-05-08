using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: 
///     Challenge Name: N/A
///     Challenge #: 22
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/qr0hg/3102012_challenge_22_easy/
///                    http://www.reddit.com/r/dailyprogrammer/comments/rzdwq/482012_challenge_37_easy/
///     program 1: Brief Description of Challenge: Write a program that will compare two lists, and append any elements in the second list that doesn't exist in the first.
///     Program 2: write a program that takes
///     input : a file as an argument
///     output: counts the total number of lines.
///     for bonus, also count the number of words in the file.
/// 
///
///     What was difficult about this challenge?
///     make the test class work
///
///     
///
///     What was easier than expected about this challenge?
///     not really the challenge was to use the test class
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.

namespace DailyProgrammer_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates 2 list with items
            List<string> list1 = new List<string>() { "B","N","C", "45", "1"};
            List<string> list2 = new List<string>() { "B", "N", "DEN", "45", "12" };
            //cerates a list to receive the new list
            List<string> newList = new List<string>();
            //calls the function Compare two lists and assigns it to newList
            newList=CompareTwoLists(list1,list2);
            //prints the elements from the new list
            foreach (string element in newList)
            {
                //print each element in the new list
                Console.WriteLine(element);
            }

            Console.WriteLine("");
            Console.WriteLine(AcronymExpander("lol"));



            Console.WriteLine("");
            Console.WriteLine(Rovarspraket("I'm speaking Robber's language!"));


            Console.ReadKey();
        }



        public static string Rovarspraket(string input)
        {
            string newstring="";

            for (int i = 0; i < input.Length;i++ )
            {
                if("bcdfghjklmnpqrstwxz".Contains(input[i]))
                {
                    newstring = newstring + input[i] + "o" + input[i];
                }
                else
                {
                    newstring = newstring + input[i]; 
                }
            }
                return newstring;
        }


        public static string AcronymExpander(string input)
        {
            List<string> acronymList = new List<string>(){"lol"};
            List<string> meaning = new List<string>(){"laughing out loud"};

            for (int i = 0; i < acronymList.Count();i++ )
            {
                if (input.ToLower().Contains(acronymList[i]))
                {
                    input = input.Replace(acronymList[i],meaning[i]);
                }
            }

            return input;
        }

        /// <summary>
        ///  Write a program that will compare two lists, and append any elements in the second list that doesn't exist in the first.
        /// </summary>
        /// <param name="list1">list 1</param>
        /// <param name="list2">list 2</param>
        /// <returns></returns>
        public static  List<string> CompareTwoLists(List<string> list1, List<string> list2)
        {
            //goes into each item to compare
            for (int i = 0; i < list2.Count(); i++)
            {
                //compares if element of list 2 is not in the list of elements of list 1
                if (!list1.Contains(list2[i]))
                {
                    //if so adds the element to list 1
                    list1.Add(list2[i]);
                }

            }
            //returns the new list
            return list1;
        }

       /// <summary>
       /// funtion that checks how many lines in a file
       /// </summary>
       /// <param name="filePath"></param>
       /// <returns></returns>
        public static int NumberOfLinesInAFile(string filePath)
        {
            //try to access the file
            try
            {

                List<string> fileLines = new List<string>();
                // load data
                using (StreamReader reader = new StreamReader(filePath))
                {
               
                    // Loop through the rest of the lines
                    while (!reader.EndOfStream)
                    {
                        fileLines.Add(reader.ReadLine());
                    }
                }

                return fileLines.Count();
            }
                //if it couldnt acces the file bc the file doesnt exist then it returns -1
            catch (IOException )
            {
                return -1;
            }
        }

    }


#region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidTestList()
        {
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            List<string> list1 = new List<string>() { "B", "N", "C", "45", "1" };
            List<string> list2 = new List<string>() { "B", "N", "DEN", "45", "12" };

            List<string> result = Program.CompareTwoLists(list1,list2);  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result.Count == 7, "Expecting 7 items");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTestList()
        {
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            List<string> list1 = new List<string>() { "B", "N", "C", "45", "1" };
            List<string> list2 = new List<string>() { "B", "N", "DEN", "45", "12" };
            List<string> result = Program.CompareTwoLists(list1,list2);
            Assert.IsFalse(result[result.Count()-1] == "1");
        }

        [Test]
        public void TextFilewith2Lines()
        {
            //checks the file and checks that it contains two lines
            int result = Program.NumberOfLinesInAFile("File.txt");  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result == 2, "Expecting 2 items");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void NonExistentFile()
        {
            //check that it handles non exiten files to avoid exeption 
            int result = Program.NumberOfLinesInAFile("NonExistentFile.txt");
            Assert.IsFalse(result != -1);
        }
    }
#endregion
}
