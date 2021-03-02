//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
//using System.Diagnostics.CodeAnalysis;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.Serialization;
//using System.Text.RegularExpressions;
//using System.Text;
//using System;



//class Result
//{

//    /*
//     * Complete the 'stringAnagram' function below.
//     *
//     * The function is expected to return an INTEGER_ARRAY.
//     * The function accepts following parameters:
//     *  1. STRING_ARRAY dictionary
//     *  2. STRING_ARRAY query
//     */

//    public static List<int> stringAnagram(List<string> dictionary, List<string> query)
//    {

//    }

//    public static bool AreStringsAnagrams(string a, string b)
//    {
//        if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b) || a.Length != b.Length)
//        {
//            return false;
//        }

//        a = a.ToLower();
//        b = b.ToLower();

//        if (a.Equals(b))
//            return false;

//        char[] ac = a.ToCharArray();
//        char[] bc = b.ToCharArray();
//        Array.Sort(ac);
//        Array.Sort(bc);
//        for (int i = 0; i < ac.Length; i++)
//        {
//            if (ac[i] != bc[i])
//            {
//                return false;
//            }
//        }

//        return true;
//    }

//}

//class Solution
//{
//    public static void Main(string[] args)
//    {
//        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//        int dictionaryCount = Convert.ToInt32(Console.ReadLine().Trim());

//        List<string> dictionary = new List<string>();

//        for (int i = 0; i < dictionaryCount; i++)
//        {
//            string dictionaryItem = Console.ReadLine();
//            dictionary.Add(dictionaryItem);
//        }

//        int queryCount = Convert.ToInt32(Console.ReadLine().Trim());

//        List<string> query = new List<string>();

//        for (int i = 0; i < queryCount; i++)
//        {
//            string queryItem = Console.ReadLine();
//            query.Add(queryItem);
//        }

//        List<int> result = Result.stringAnagram(dictionary, query);

//        textWriter.WriteLine(String.Join("\n", result));

//        textWriter.Flush();
//        textWriter.Close();
//    }
//}
