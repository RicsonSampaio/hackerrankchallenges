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
     * Complete the 'findSubstring' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */


    public static string findSubstring(string stringDadaParaSerFiltrada, int numeroDeVogaisDaStringRequerida)
    {
        // Store the length of the string
        int tamanhoDaString = stringDadaParaSerFiltrada.Length;

        // Initialize a prefix sum array
        int[] arrayContadorVogais = new int[tamanhoDaString];

        // Loop through the string to
        // create the prefix sum array
        for (int i = 0; i < tamanhoDaString; i++)
        {

            // Store 1 at the index if it is a vowel
            if (stringDadaParaSerFiltrada[i] == 'a' ||
                stringDadaParaSerFiltrada[i] == 'e' ||
                stringDadaParaSerFiltrada[i] == 'i' ||
                stringDadaParaSerFiltrada[i] == 'o' ||
                stringDadaParaSerFiltrada[i] == 'u')
                arrayContadorVogais[i] = 1;

            // Otherwise, store 0
            else
                arrayContadorVogais[i] = 0;

            // Process the prefix array
            if (i != 0)
                arrayContadorVogais[i] += arrayContadorVogais[i - 1];
        }

        // Initialize the variable to store
        // maximum count of vowels
        int numeroMaxDeVogaisRequerido = arrayContadorVogais[numeroDeVogaisDaStringRequerida - 1];

        // Initialize the variable
        // to store substring
        // with maximum count of vowels
        string res = stringDadaParaSerFiltrada.Substring(0, numeroDeVogaisDaStringRequerida);

        // Loop through the prefix array
        for (int i = numeroDeVogaisDaStringRequerida; i < tamanhoDaString; i++)
        {

            // Store the current
            // count of vowels
            int numeroDeVogaisQueExistemNaString = arrayContadorVogais[i] - arrayContadorVogais[i - numeroDeVogaisDaStringRequerida];

            if (numeroDeVogaisQueExistemNaString == 0)
            {
                return "Not found!";
            }

            // Update the result if current count is greater than maximum count
            if (numeroDeVogaisQueExistemNaString > numeroMaxDeVogaisRequerido)
            {
                numeroMaxDeVogaisRequerido = numeroDeVogaisQueExistemNaString;
                res = stringDadaParaSerFiltrada.Substring(i - numeroDeVogaisDaStringRequerida + 1, numeroDeVogaisDaStringRequerida);
            }

            //// Update lexicographically smallest
            //// substring if the current count
            //// is equal to the maximum count
            //else if (numeroDeVogaisQueExistemNaString == numeroMaxDeVogaisRequerido)
            //{
            //    string temp = str.Substring(i - K + 1, K);

            //    if (string.Compare(temp, res) == -1)
            //        res = temp;
            //}
        }

        // Return the result
        return res;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.findSubstring(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
