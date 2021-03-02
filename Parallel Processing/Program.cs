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
     * Complete the 'minTime' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY files
     *  2. INTEGER numCores
     *  3. INTEGER limit
     
     If a file is executed by a single core, the execution time equals the number of lines of code in the file. 
     
     If the lines of code can be divided by the number of cores, another option is to execute the file in parallel using all the            cores, in which case the execution time is divided by the number of cores. 
     
     However, there is a limit as to how many files can be executed in parallel. 
     
     Given the lengths of the code files, the number of cores, and the limit, what is the minimum amount of time needed to execute          all the files?
     */

    public static long minTime(List<int> files, int numCores, int limit)
    {
        var numerosDeFiles = files.Count();
        bool usaraParalelismo = false;
        List<int> possicaoArrayAParalelizar = new List<int>();
        var minTime = 0;
        
        // se a divisao do numero de cores pelo numeros de linhas de algum documento for zero, significa que da pra
        // fazer em paralelo

        for (int i = 0; i < numerosDeFiles; i++)
        {
            if (files[i] % numCores == 0)
            {
                usaraParalelismo = true;
                possicaoArrayAParalelizar.Add(i);
            }
        }

        //// se nao for usar paralelismo é bem facil, basta somar todos os numeros
        //if (!usaraParalelismo)
        //{
        //    for (int i = 0; i < numerosDeFiles; i++)
        //    {
        //        minTime = minTime + files[i];
        //    }
        //} 
        //else 
        if(limit == 1)
        {
            // eu sei que tem coisas a serem paralelizadas, mas eu so posso paralelizar 1 por vez
            // como saber a forma mais eficiente? Descobrindo o maior valor.

            var maxValue = possicaoArrayAParalelizar.Max();
            int possicaoArrayAParalelizarMaisEficiente = possicaoArrayAParalelizar.ToList().IndexOf(maxValue);

            for (int i = 0; i < numerosDeFiles; i++)
            {
                if (i != possicaoArrayAParalelizarMaisEficiente)
                {
                    minTime = minTime + files[i];
                }              
            }

            minTime = minTime + (files[possicaoArrayAParalelizarMaisEficiente] / numCores);

        } 
        else
        {
            // nao sei qual o limite de parelização
            files.Sort();
            List<int> posicoesSemParalelizarASeremSomadas = new List<int>();
            List<int> posicoesPARALELIZADASSEREMSOMADAS = new List<int>();


            for (int i = 0; i < possicaoArrayAParalelizar.Count(); i++)
            {
                if (i != possicaoArrayAParalelizar[i])
                {
                    posicoesSemParalelizarASeremSomadas.Add(i);
                }
            }


            for (int i = 0; i < possicaoArrayAParalelizar.Count() - limit; i++)
            {
                posicoesPARALELIZADASSEREMSOMADAS.Add(i);            
            }

            for (int i = 0; i < posicoesSemParalelizarASeremSomadas.Count(); i++)
            {
                minTime = minTime + files[posicoesSemParalelizarASeremSomadas[i]];
            }

            for (int i = 0; i < posicoesPARALELIZADASSEREMSOMADAS.Count(); i++)
            {
                minTime = minTime + (files[posicoesPARALELIZADASSEREMSOMADAS[i]] / numCores);
            }

        }

        if (minTime == 0)
        {
            for (int i = 0; i < numerosDeFiles; i++)
            {
                minTime = minTime + files[i];
            }
        }

        return minTime;

    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int filesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> files = new List<int>();

        for (int i = 0; i < filesCount; i++)
        {
            int filesItem = Convert.ToInt32(Console.ReadLine().Trim());
            files.Add(filesItem);
        }

        int numCores = Convert.ToInt32(Console.ReadLine().Trim());

        int limit = Convert.ToInt32(Console.ReadLine().Trim());

        long result = Result.minTime(files, numCores, limit);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
