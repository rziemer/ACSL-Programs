using System;
using System.IO;
using System.Collections.Generic;

namespace Program2
{
    public class Conversion
    {
        public static int BotChagaLoop(int toModify)
        {
            int retVal = toModify;
            bool sorted = false;
            for (int loop = 0; ((loop < 5)&&(!(sorted))); loop++)
            {
                retVal = Conversion.SortSubtract(retVal);
                sorted = Conversion.IsSorted(retVal);
            }
            return retVal;
        }

        public static int SortSubtract(int toSubtract)
        {
            int retVal = 0;
            retVal = toSubtract - Conversion.OctalToDecimal(Conversion.SortOctal(Conversion.DecimalToOctal(toSubtract)));
            return retVal;
        }

        public static bool IsSorted(int toCheck)
        {
            bool retVal = true;
            int[] octalNum = Conversion.DecimalToOctal(toCheck);
            for (int loop = 0; loop < octalNum.Length - 1; loop++)
                if (octalNum[loop] < octalNum[loop + 1])
                    retVal = false;
            return retVal;
        }

        public static bool[] DecimalToBinary(int toConvert)
        {
            bool[] retVal = new bool[32];
            int testVal = 1;
            for (int loop = 0; loop < 32; loop++)
            {
                retVal[loop] = ((toConvert & testVal) > 0);
                testVal = testVal << 1;
            }
            return retVal;
        }

        public static int BinaryToDecimal(bool[] toConvert)
        {
            int retVal = 0;
            int testVal = 1;
            for (int loop = 0; loop < toConvert.Length; loop++)
            {
                if (toConvert[loop])
                    retVal += testVal;
                testVal = testVal << 1;
            }
            return retVal;
        }

        public static int[] BinaryToOctal(bool[] toConvert)
        {
            int[] retVal = new int[11];
            int retValPos = 0;
            for(int loop = 0; loop < toConvert.Length; loop += 3)
            {
                int testVal = 1;
                for (int loop2 = 0; loop2 < 3; loop2++)
                {
                    if ((loop + loop2) < toConvert.Length)
                        if (toConvert[loop + loop2])
                            retVal[retValPos] += testVal;
                    testVal = testVal << 1;
                }
                retValPos++;
            }
            return retVal;
        }

        public static bool[] OctalToBinary(int[] toConvert)
        {
            bool[] retVal = new bool[32];
            for (int loop = 0; loop < toConvert.Length; loop++)
            {
                int testVal = 1;
                for (int loop2 = 0; loop2 < 3; loop2++)
                {
                    if (((loop * 3) + loop2) < 32)
                        retVal[((loop * 3) + loop2)] = ((toConvert[loop] & testVal) > 0);
                    testVal = testVal << 1;
                }
            }
            return retVal;
        }

        public static int[] SortOctal(int[] toSort)
        {
            int[] retVal = new int[toSort.Length];
            for (int loop = 0; loop < toSort.Length; loop++)
                retVal[loop] = toSort[loop];
            for (int loop = 0; loop < toSort.Length - 1; loop++)
                for (int loop2 = loop + 1; loop2 < toSort.Length; loop2++)
                    if (retVal[loop] < retVal[loop2])
                    {
                        int swapVal = retVal[loop];
                        retVal[loop] = retVal[loop2];
                        retVal[loop2] = swapVal;
                    }
            return retVal;
        }

        public static int[] DecimalToOctal(int toConvert)
        {
            return Conversion.BinaryToOctal(Conversion.DecimalToBinary(toConvert));
        }

        public static int OctalToDecimal(int[] toConvert)
        {
            return Conversion.BinaryToDecimal(Conversion.OctalToBinary(toConvert));
        }

        public static void WriteBinary(bool[] toWrite)
        {
            Console.Write("| ");
            for(int loop = toWrite.Length - 1; loop >= 0; loop--)
            {
                if (toWrite[loop])
                    Console.Write("1");
                else
                    Console.Write("0");
                if ((loop % 4) == 0)
                    Console.Write(" ");
                if ((loop % 8) == 0)
                    Console.Write("| ");
            }
            Console.WriteLine("");
        }

        public static void WriteOctal(int[] toWrite)
        {
            for (int loop = toWrite.Length - 1; loop >= 0; loop--)
                Console.Write(toWrite[loop]);
            Console.WriteLine("");
        }
    }

    class Program2
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
                Console.WriteLine(Conversion.BotChagaLoop(int.Parse(fileString[loop])));
        }
    }
}
