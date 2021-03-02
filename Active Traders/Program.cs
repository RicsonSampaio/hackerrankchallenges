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
     * Complete the 'mostActive' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY customers as parameter.
     */

    public static List<string> mostActive(List<string> customers)
    {
        // saber quais nomes tem na lista (pra testar quantas vezes eles se repetem)
        // saber quantos nomes exitem na lista (customers.Count())
        // Saber quantas vezes um nome se repete na lista
        // saber se o numero de vezes que o nome aparece representa ao menos 5%

        var customersDistinct = CustomersDistinct(customers);
        // primeiro valor é o nome do customer, segundo valor é o numero de vezes q ele aparece
        Dictionary<string, double> customersAparece = new Dictionary<string, double>();
        List<string> res = new List<string>();


        for (int j = 0; j < customersDistinct.Count(); j++)
        {
            customersAparece.Add(customersDistinct[j], CountOccurenceOfValue(customers,customersDistinct[j]));
        }

        for (int i = 0; i < customersAparece.Count(); i++)
        {
            
            if (customersAparece[customersDistinct[i]] / (double)customers.Count() * 100 >= 5)
            {
                res.Add(customersDistinct[i]);
            }          
        }

        res.Sort();
        return res; 
    }

    static int CountOccurenceOfValue(List<string> customers, string valueToFind)
    {
        int count = customers.Where(temp => temp.Equals(valueToFind))
                    .Select(temp => temp)
                    .Count();
        return count;
    }

    static List<string> CustomersDistinct(List<string> customers)
    {
        List<string> customersDistinct = customers.Distinct().ToList();
        return customersDistinct;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int customersCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> customers = new List<string>();

        for (int i = 0; i < customersCount; i++)
        {
            string customersItem = Console.ReadLine();
            customers.Add(customersItem);
        }

        List<string> result = Result.mostActive(customers);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
