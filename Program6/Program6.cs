using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Program6
{

    public class stringSplit
    {
        
        public static void split(string original, string toSplit)
        {
            if (original != "")
                Console.WriteLine(original + ":" + toSplit);
            for (int loop = 1; loop < toSplit.Length; loop++)
            {
                string tempOriginal = "";
                if (original != "")
                    tempOriginal = original + ":" + toSplit.Substring(0, loop);
                else
                    tempOriginal = toSplit.Substring(0, loop);
                split(tempOriginal, toSplit.Substring(loop, toSplit.Length - loop));
            }
        }
    }
    class Program6
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
                stringSplit.split("", parsedString[0]);
            }
        }
    }
}
