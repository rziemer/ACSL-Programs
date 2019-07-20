using System;
using System.Collections.Generic;
using System.IO;

namespace Program3
{
    public class Calculator 
    {
        private static int PrimeMin = 10000;
        private static int PrimeMax = 99999;
        public static int Exp(int a, int b)
        {
            int retval = 1;
            for (int loop = 0; loop < b; loop++)
                retval *= a;
            return retval;
        }

        public static int[] PrimeCalc(int a, int b)
        {
            int[] retval = null;

            List<int> myNumbers = new List<int>();

            int x = 0;
            int y = 0;

            bool done = false;
            while (!(done))
            {
                int testVal = Calculator.Exp(a, x)*Calculator.Exp(b, y);
                if ((testVal >= PrimeMin)&&(testVal <= PrimeMax))
                    myNumbers.Add(testVal);
                if ((!(done))&&(testVal <= PrimeMax))
                    x++;
                else
                    if (x > 0)
                    {
                        x = 0;
                        y++;
                    }
                    else
                        done = true;
            }
            retval = myNumbers.ToArray();
            return retval;
        }
    }
    class Program3
    {
        static void Main(string[] args)
        {
            List<string> fileList = new List<string>();   
            string fileLine = "";
            StreamReader sr = new StreamReader(args[0]);
            while ((fileLine = sr.ReadLine()) != null)
                fileList.Add(fileLine);
            string[] fileString = fileList.ToArray();

            for (int fileloop = 0; fileloop < fileString.Length; fileloop++)
            {
                char[] delimiters = {','};
                string[] parsedString = fileString[fileloop].Split(delimiters);

                string toSearch = "";
                int num1 = int.Parse(parsedString[0]);
                int num2 = int.Parse(parsedString[1]);
                char char3 = parsedString[2].Trim().ToCharArray()[0];
                int[] myList = Calculator.PrimeCalc(num1, num2);
                for (int loop = 0; loop < myList.Length; loop++)
                {
                    toSearch += myList[loop].ToString();
                }
                int count = 0;
                for (int loop = 0; loop < toSearch.Length; loop++)
                {

                    if (toSearch[loop] == char3)
                        count++;
                }
                Console.WriteLine(count);
            }
        }
    }
}
