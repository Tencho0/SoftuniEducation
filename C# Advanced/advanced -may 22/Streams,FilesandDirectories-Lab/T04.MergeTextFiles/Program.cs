﻿namespace MergeTextFiles
{
    using System;
    using System.IO;

    public class Program
    {
        static void Main(string[] args)
        {
            string firstInputFilePath = @"../../../input1.txt";
            string secondInputFilePath = @"../../../input2.txt";
            string outputFilePath = @"../../../output.txt";
            MergeFiles.MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }
    }
    public class MergeFiles
    {
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstInputFile = new StreamReader(firstInputFilePath);
            StreamReader secondInputFile = new StreamReader(secondInputFilePath);

        }
    }

}
