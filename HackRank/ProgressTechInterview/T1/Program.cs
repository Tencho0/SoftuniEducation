using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result
{

    /*
     * Complete the 'ValidatePassSentences' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY input as parameter.
     */

    public static int ValidatePassSentences(List<string> input)
    {
        int count = 0;
        foreach (string passSentence in input)
        {
            string[] words = passSentence.Split(' ');
            HashSet<string> uniqueWords = new HashSet<string>(words);
            if (words.Length == uniqueWords.Count)
            {
                count++;
            }
        }

        return count;


        //     int count;
        //     var dict = new List<string>();
        // foreach (string sentence in input)
        // {
        //     bool isValid = true;
        //     foreach(string word in sentence.Split(' '))
        //     {
        //         if(dict.ContainsKey(word))      
        //         {
        //             isValid=false;
        //             break;
        //         }    
        //         else
        //         {
        //             dict.Add(word);
        //         }
        //     }
        //     if(isValid)
        //     {
        //         count++;
        //     }

        //     dict =  new List<string>();
        // }  
        // return count;
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int inputCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> input = new List<string>();

            for (int i = 0; i < inputCount; i++)
            {
                string inputItem = Console.ReadLine();
                input.Add(inputItem);
            }

            int result = Result.ValidatePassSentences(input);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}