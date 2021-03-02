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
     * Complete the 'getMinCost' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY crew_id
     *  2. INTEGER_ARRAY job_id
     */

    public static long getMinCost(List<int> crew_id, List<int> job_id)
    {
        long cost = 0;

        //Collections.sort(crew_id);

        //Collections.sort(job_id);

        int len1 = crew_id.Count();

        int len2 = job_id.Count();

        if (len1 == len2)

        {


            for (int i = 0; i < len1; i++)

            {

                if (job_id.ElementAt(i) >= crew_id.ElementAt(i))

                {

                    cost = cost + (job_id.ElementAt(i) - crew_id.ElementAt(i));

                }

                else if (job_id.ElementAt(i) < crew_id.ElementAt(i))

                {

                    cost = cost + (crew_id.ElementAt(i) - job_id.ElementAt(i));

                }

            }

        }

        return cost;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int crew_idCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> crew_id = new List<int>();

        for (int i = 0; i < crew_idCount; i++)
        {
            int crew_idItem = Convert.ToInt32(Console.ReadLine().Trim());
            crew_id.Add(crew_idItem);
        }

        int job_idCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> job_id = new List<int>();

        for (int i = 0; i < job_idCount; i++)
        {
            int job_idItem = Convert.ToInt32(Console.ReadLine().Trim());
            job_id.Add(job_idItem);
        }

        long result = Result.getMinCost(crew_id, job_id);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
