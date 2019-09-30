using System;
using System.Collections.Generic;
using System.IO;

namespace Program5
{
    class Program5
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

                acslURL sourceURL = new acslURL(parsedString[0].Trim());
                acslURL destinationURL = new acslURL(parsedString[1].Trim());
                Console.WriteLine(sourceURL.mergeURL(destinationURL).ToString());
            }
        }
    }
}
