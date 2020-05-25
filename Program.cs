using System;
using System.Linq;
using System.Text;

namespace RomanNumeralConverter
{
    public class Converter
    {
        public string IntToRoman(int number)
        {
            StringBuilder returnString = new StringBuilder();
            string test = "";
            string[] romanVals = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            int[] digits = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 }; //values of all possible outcomes including 6 subtraction values are stored in array
            while (number > 0) //if number is 0 then you are done and can return final string
            {
                for (int i = digits.Count() - 1; i >= 0; i--)//start at the end of the digits array and descend to first entry
                {
                    if (number / digits[i] >= 1)//check to see if number will be smaller than value at digits[i] 
                    {
                        //if it is then subtract you can subtract value at digits[i] from number 
                        number -= digits[i];
                        test = test + romanVals[i];
                        //add string to final string
                        break;
                    }
                }
            }
            return test;
        }
    }
    class Program
    {
        //calls IntToRoman and asks user to give input
        static void Main(string[] args)
        {
            string value = "";
            string leave = "";
            Converter Roman = new Converter();
            while (leave != "y")
            {
                Console.WriteLine("Please enter a numerical Value: ");
                value = Console.ReadLine();

                string test = Roman.IntToRoman(int.Parse(value));

                Console.WriteLine("This is the equivalent of {0} in Roman Numerals: {1}", value, test);
                Console.WriteLine("Do you wish to exit?(y/n): ");
                leave = Console.ReadLine();
            }
        }
    }
}
