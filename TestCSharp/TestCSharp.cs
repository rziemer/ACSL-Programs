using System;
using System.IO;
using System.Collections.Generic;

namespace TestCSharp
{

    public class Wages
    {
        private static double BaseRate = 10.0;
        private static double Excess8 = 1.5;
        private static double Excess40 = 2.5;
        private static double Saturday = 2.25;
        private static double Sunday = 1.50;

        public static double CalcPay(int[] weekHours)
        {
            double retVal = 0.0;
            int weekdayTotalHours = 0;
            for (int loop = 0; loop < 7; loop++)
            {
                double dailyEarnings = BaseRate * weekHours[loop];
                if (weekHours[loop] > 8)
                    dailyEarnings += (weekHours[loop] - 8) * Excess8;               
                if (loop == 0)
                    dailyEarnings *= Sunday;
                if (loop == 6)
                    dailyEarnings *= Saturday;
                weekdayTotalHours += weekHours[loop];
                retVal += dailyEarnings;
            }
            if (weekdayTotalHours > 40)
                retVal += (weekdayTotalHours - 40) * Excess40;
            return retVal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> fileList = new List<string>();   
            string fileLine = "";
            StreamReader sr = new StreamReader(args[0]);
            while ((fileLine = sr.ReadLine()) != null)
                fileList.Add(fileLine);
            string[] fileString = fileList.ToArray();

            for (int loop = 0; loop < fileString.Length; loop++)
            {
                string[] lineVals = fileString[loop].Split(',');
                int[] lineInts = new int[lineVals.Length];
                for (int loop2 = 0; loop2 < lineInts.Length; loop2++)
                    lineInts[loop2] = int.Parse(lineVals[loop2]);
                Console.WriteLine("$" + string.Format("{0:0,0.00}", Wages.CalcPay(lineInts)));
            }
        }
    }
}
