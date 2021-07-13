using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RSA_Project_final;
using System.Diagnostics;

namespace RSA_Project_final
{
    class Program
    {
        public static void phase_one()
        {

            while (true)
            {

                RSA_Project_final.BigInteger x = new RSA_Project_final.BigInteger();
                string Mul, Sub, Add;
                List<string> ans = new List<string>();
                Console.WriteLine("********************RSA Project********************");
                string choose;
                Console.WriteLine("[1]-Adding Function:");
                Console.WriteLine("[2]-Subtract Function:");
                Console.WriteLine("[3]-Multiply Function:");
                Console.WriteLine("any other key to close");
                Console.Write("Enter your choose :");
                choose = Console.ReadLine();
                if (choose == "1")
                {
                    string filepath = "AddTestCases.txt";
                    List<string> lines = File.ReadAllLines(filepath).ToList();
                    List<string> fileinput = new List<string>();
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                            fileinput.Add(line);
                    }
                    Add = "Add_output.txt";


                    /////////////////////////////////////////
                    Stopwatch cas = Stopwatch.StartNew();
                    cas.Start();
                    for (int i = 1; i < fileinput.Count; i += 2)
                    {
                        // sw.Start();

                        ans.Add(x.Add(fileinput[i], fileinput[i + 1]));
                        if (i + 2 < fileinput.Count)
                            ans.Add("");
                    }

                    cas.Stop();
                    Console.WriteLine("test case time  " + " is " + cas.Elapsed);

                    File.WriteAllLines(Add, ans);
                }
                else if (choose == "2")
                {
                    string filepath = "SubtractTestCases.txt";
                    List<string> lines = File.ReadAllLines(filepath).ToList();
                    List<string> fileinput = new List<string>();
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                            fileinput.Add(line);
                    }
                    Sub = "Sub_output.txt";
                    Stopwatch cas = Stopwatch.StartNew();
                    cas.Start();
                    for (int i = 1; i < fileinput.Count; i += 2)
                    {
                        ans.Add(x.subtract(fileinput[i], fileinput[i + 1]));
                        if (i + 2 < fileinput.Count)
                            ans.Add("");
                    }
                    cas.Stop();
                    Console.WriteLine("test case time " + " is " + cas.Elapsed);
                    File.WriteAllLines(Sub, ans);
                }
                else if (choose == "3")
                {
                    string filepath = "MultiplyTestCases.txt";
                    List<string> lines = File.ReadAllLines(filepath).ToList();
                    List<string> fileinput = new List<string>();
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                            fileinput.Add(line);
                    }
                    Mul = "Mul_output.txt";
                    Stopwatch cas = Stopwatch.StartNew();
                    cas.Start();
                    for (int i = 1; i < fileinput.Count; i += 2)
                    {
                        ans.Add(x.Mul(fileinput[i], fileinput[i + 1]));
                        if (i + 2 < fileinput.Count)
                            ans.Add("");
                    }
                    cas.Stop();
                    Console.WriteLine("test case time " + " is " + cas.Elapsed);
                    File.WriteAllLines(Mul, ans);
                }
                else break;

            }
        }
        public static void Final_project()
        {
            while (true)
            {
                RSA_Project_final.BigInteger x = new RSA_Project_final.BigInteger();
                List<string> ans = new List<string>();
                string choose;
                Console.WriteLine("[1]-Sample   test:");
                Console.WriteLine("[2]-Complete test:");
                Console.Write("Enter your choose    : ");
                string sample = "Sample_output.txt", complete = "Compelete_output.txt";
                choose = Console.ReadLine();
                if (choose == "1")
                {
                    string filepath = "SampleRSA.txt";
                    List<string> lines = File.ReadAllLines(filepath).ToList();
                    string a, b, c, ch;

                    for (int i = 1, j = 1; i < lines.Count; i += 4, j++)
                    {

                        a = lines[i];
                        b = lines[i + 1];
                        c = lines[i + 2];
                        ch = lines[i + 3];

                        if (ch == "0")
                        {
                            string final_answer;
                            Stopwatch cas = Stopwatch.StartNew();
                            cas.Start();
                            final_answer = x.Encrypt(c, b, a);
                            cas.Stop();
                            //Console.WriteLine(final_answer);                           
                            Console.WriteLine("test case time " + j + " is " + cas.Elapsed);
                            ans.Add(final_answer);

                        }
                        else
                        {
                            string final_answer;
                            Stopwatch cas = Stopwatch.StartNew();
                            cas.Start();
                            final_answer = x.Decrypt(c, b, a);
                            cas.Stop();
                            //Console.WriteLine(final_answer);                           
                            Console.WriteLine("test case time " + j + " is " + cas.Elapsed);
                            ans.Add(final_answer);
                        }
                        File.WriteAllLines(sample, ans);

                    }

                }
                else if (choose == "2")
                {
                    string filepath = "TestRSA.txt";
                    List<string> lines = File.ReadAllLines(filepath).ToList();
                    string a, b, c, ch;
                    for (int i = 1, j = 1; i < lines.Count; i += 4, j++)
                    {

                        a = lines[i];
                        b = lines[i + 1];
                        c = lines[i + 2];
                        ch = lines[i + 3];
                        if (ch == "0")
                        {
                            string final_answer;
                            Stopwatch cas = Stopwatch.StartNew();
                            cas.Start();
                            final_answer = x.Encrypt(c, b, a);
                            //Console.WriteLine(final_answer);
                            cas.Stop();
                            Console.WriteLine("test case time " + j + " is " + cas.Elapsed);
                            ans.Add(final_answer);
                        }
                        else
                        {
                            string final_answer;
                            Stopwatch cas = Stopwatch.StartNew();
                            cas.Start();
                            final_answer = x.Decrypt(c, b, a);
                            //Console.WriteLine(final_answer);
                            cas.Stop();
                            Console.WriteLine("test case time " + j + " is " + cas.Elapsed);
                            ans.Add(final_answer);
                        }

                    }
                    File.WriteAllLines(complete, ans);
                }
                else
                    Console.WriteLine("Wrong Choose");
                ans.Clear();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("[1] For Phase 1:");
            Console.WriteLine("[2] For Final  :");
            string ch = Console.ReadLine();
            if (ch == "1")
                phase_one();
            else if (ch == "2")
                Final_project();
        }
    }
}
