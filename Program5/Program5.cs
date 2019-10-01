using System;
using System.Collections.Generic;
using System.IO;

namespace Program5
{
    class Program5
    {
        public class BinaryTree
        {
            private char value = (char)(0x00);
            private BinaryTree left = null;
            private BinaryTree right = null;

            public BinaryTree()
            {
            }

            private BinaryTree(char toInsert)
            {
                value = toInsert;
            }

            public char GetRoot()
            {
                return value;
            }

            private int privateInsertValue(char toInsert, bool actualInsert)
            {
                int retVal = 1;
                if ((toInsert <= 'Z')&&(toInsert >= 'A'))
                {
                    if (value == (char)(0x00))
                    {
                        if (actualInsert)
                            value = toInsert;
                    }
                    else
                        if (toInsert <= value)
                        {
                            if (left == null)
                            {
                                retVal++;
                                if (actualInsert)
                                    left = new BinaryTree(toInsert);
                            }
                            else
                                retVal += left.privateInsertValue(toInsert, actualInsert);
                        }
                        else
                        {
                            if (right == null)
                            {
                                retVal++;
                                if (actualInsert)
                                    right = new BinaryTree(toInsert);
                            }
                            else
                                retVal += right.privateInsertValue(toInsert, actualInsert);
                        }
                }
                return retVal;            
            }

            public int testInsertValue(char toInsert)
            {
                return privateInsertValue(toInsert, false);
            }

            public void insertValue(char toInsert)
            {
                privateInsertValue(toInsert, true);
            }

            public int getDepth()
            {
                int retVal = 1;
                int leftDepth = 0;
                int rightDepth = 0;
                if (left != null)
                    leftDepth = left.getDepth();
                if (right != null)
                    rightDepth = right.getDepth();
                if (leftDepth > rightDepth)
                    retVal += leftDepth;
                else
                    retVal += rightDepth;
                return retVal;
            }


        }
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
                string treeString = "";
                for (int loop = 1; loop < parsedString.Length; loop++)
                    treeString += parsedString[loop].Trim().ToUpper();
                Stack<BinaryTree> treeStack = new Stack<BinaryTree>();
                for (int loop = 0; loop < treeString.Length; loop++)
                {
                    char charToInsert = treeString[loop];
                   
                    int stackLoop = 0;
                    bool done = false;
                    while(!done)
                    {
                        if (stackLoop < treeStack.Count)
                        {
                            int testDepth = treeStack.ToArray()[stackLoop].testInsertValue(charToInsert);
                            if (testDepth <= depth + 1)
                            {
                                treeStack.ToArray()[stackLoop].insertValue(charToInsert);
                                done = true;
                            }
                            else
                                stackLoop++;
                        }
                        else
                        {
                            BinaryTree tempTree = new BinaryTree();
                            tempTree.insertValue(charToInsert);
                            treeStack.Push(tempTree);
                            done = true;
                        }
                    }
                }
                for (int loop = 0; loop < treeStack.Count; loop++)
                    Console.Write(treeStack.ToArray()[loop].GetRoot());
                Console.WriteLine();
            }
        }
    }
}
