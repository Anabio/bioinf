using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace labos
{
    class Program
    {

        static void Main(string[] args)
        {
     
            string fileName = "Datoteka.txt";
            string genome = string.Empty;

            int w;
            int k;
            int l;
        
            List<string> vecBili = new List<string>();
         

            if(args.Length != 2)
            {
                Console.WriteLine("There should be 2 arguments!!");
                return;
            }

             if(!int.TryParse(args[0], out w))
             {
                 Console.WriteLine("Cannot parse w!!");
                 return;
             }

             if (!int.TryParse(args[1], out k))
             {
                 Console.WriteLine("Cannot parse k!!");
                 return;
             }

             l = w + k - 1;

            if(!File.Exists(fileName))
            {
                Console.WriteLine("There is no file!!");
                return;
            }
            using (StreamReader sr = new StreamReader(fileName))
            {
               genome = sr.ReadToEnd();
            }
                 if(genome == string.Empty)
            {
                Console.WriteLine("File is empty!!");
                return;
            }
   
        
            
            var pomak = genome.Length - l;
            int pom = genome.Length;

            for(int i = 0; i<pomak+1; ++i)
            {
                var g = FindSmallest(genome.Substring(i, l), k);
                if (!vecBili.Contains(g))
                {
                    Console.WriteLine(g + "\n");
                    vecBili.Add(g);
                }
                
            }
     
        }

        static string FindSmallest(string s_in, int k)
        {
            if (s_in.Length < k) return "error";

            int index = 0;

            string smallest = s_in.Substring(index, k);

            for (int i = 1; i < (s_in.Length + 1 - k); ++i)
            {
                smallest = SmallestBetween2(smallest, s_in.Substring(i, k));
            }
           
            return smallest;
        }

        static string SmallestBetween2(string first, string second)
        {
            for(int i = 0; i<first.Length; ++i)
            {
                if((int)first[i] < (int)second[i])
                {
                    return first;
                }

                if((int)first[i] > (int)second[i])
                {
                    return second;
                }

            }

            return first;
           
        }
    }
  }
}

