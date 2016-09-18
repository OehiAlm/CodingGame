using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


class Solution
{
    static string output = "UNKNOWN";
    static string dot = ".";

    static void Set_output_true(string x)
    {
        output = x;
    }

    static void Set_output_false()
    {
        output = "UNKNOWN";
    }

    static void Main(string[] args)
    {
        Stopwatch initial_stopwatch = Stopwatch.StartNew();

        int N = int.Parse(Console.ReadLine());      // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine());      // Number Q of file names to be analyzed.
        string[,] ass_table = new string[N, 2];

        Console.Error.WriteLine("Table size: " + N);
        Console.Error.WriteLine("Files: " + Q);
        Console.Error.WriteLine();

        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            ass_table[i, 0] = "." + inputs[0];       // file extension
            ass_table[i, 1] = inputs[1];             // MIME type.

            //Console.Error.WriteLine("File extension: '" + ass_table[i,0] + "' and associated Mime Type: " + ass_table[i, 1]);
        }

        initial_stopwatch.Stop();
        Console.Error.WriteLine("Association Table setup = " + initial_stopwatch.ElapsedMilliseconds + "ms");
        Stopwatch all_cycles_stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine();      // One file name per line.

            if (FNAME.EndsWith(dot, true, culture: null))
            { Set_output_false(); Console.WriteLine(output); continue; }

            Console.Error.WriteLine("Input = " + FNAME);
            Stopwatch one_file_stopwatch = Stopwatch.StartNew();

            for (int j = 0; j < N; j++)
            {


                bool file_extension_found = FNAME.EndsWith(ass_table[j, 0], true, culture: null);
                //Console.Error.WriteLine("file_extension_found : " + file_extension_found);

                if (file_extension_found)
                {
                    Set_output_true(ass_table[j, 1]);
                    break;
                }
                else
                {
                    Set_output_false();
                }
            }

            one_file_stopwatch.Stop();
            Console.Error.WriteLine("One File " + one_file_stopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine(output);
        }

        all_cycles_stopwatch.Stop();
        Console.Error.WriteLine("All cycles = " + all_cycles_stopwatch.ElapsedMilliseconds + "ms");
    }
}