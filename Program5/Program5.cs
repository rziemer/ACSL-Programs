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

                int depth = int.Parse(parsedString[0].Trim());
                string treeString = parsedString[1].Trim();
                Console.WriteLine(depth.ToString() + " :: " + treeString);
            }
        }
    }
}
