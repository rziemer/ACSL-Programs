using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Program4
{
    public class acslURL
    {
        private static string defaultPage = "default.htm";
        private string protocol = "";
        private bool hasProtocol = false;
        private string host = "";
        private bool hasHost = false;
        private string[] directories = null;
        
        public acslURL(string inputURL)
        {
            string workingURL = inputURL;
            hasProtocol = workingURL.Contains("://");
            if (hasProtocol)
            {
                protocol = workingURL.Split("://")[0];
                workingURL = workingURL.Substring(protocol.Length + 3, workingURL.Length - protocol.Length - 3);
            }

            int firstLoc = workingURL.IndexOf('/');
            Regex rx = new Regex(@"[a-z, A-Z][.][a-z, A-Z]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(workingURL);
            hasHost = false;
            if (matches.Count > 0)
                hasHost = (matches[0].Index < firstLoc);
            if (hasHost)
            {
                host = workingURL.Substring(0, firstLoc);
                workingURL = workingURL.Substring(firstLoc + 1, workingURL.Length - firstLoc - 1);
            }
            directories = workingURL.Split("/");
            if (directories[directories.Length - 1] == "")
                directories[directories.Length - 1] = defaultPage;
        }

        public override string ToString()
        {
            string retVal = "";
            if (hasProtocol)
                retVal += protocol + "://";
            if (hasHost)
                retVal += host + "/";
            for (int loop = 0; loop < directories.Length; loop++)
            {
                retVal += directories[loop];
                if (loop < directories.Length - 1)
                    retVal += "/";
            }
            return retVal;
        }

        public acslURL mergeURL(acslURL destinationURL)
        {
            acslURL returnURL = new acslURL(this.ToString());
            return returnURL;
        }
    }
    class Program4
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
            }
        }
    }
}
