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
     * Complete the 'frequency' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING s as parameter.
     */

    public static List<int> frequency(string s)
    {

        List<int> res = new List<int>();
        for (int e = 0; e < 26; e++)
        {
            res.Add(0);
        }
        int len = s.Length;

        int i = 0;
        while (i < len)
        {
            int val = 0;

            if (i + 2 >= len || s[i + 2] != '#')
            {
                val = s[i] - '0';
                res[val - 1]++;
                i++;
            }
            else if (s[i + 2] == '#')
            {
                val = (s[i] - '0') * 10 + (s[i + 1] - '0');
                res[val - 1]++;
                i = i + 3;
            }


            if (i < len)
            {
                if (s[i] == '(')
                {
                    int freq = 0;
                    i++;
                    while (s[i] != ')')
                    {
                        freq = freq * 10 + (s[i] - '0');
                        i++;
                    }

                    res[val - 1] += freq - 1;
                    i++;
                }
            }
        }

        return res;

    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        List<int> result = Result.frequency(s);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
