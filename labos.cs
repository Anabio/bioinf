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
            var stopWatch = new Stopwatch();
            stopWatch.Start();	//pocetak mjerenja vremena
            string fileName = "Datoteka.txt";
            string genome = string.Empty;

            int w;
            int k;
            int l;
        
            List<string> vecBili = new List<string>();
            List<string> vecBili2 = new List<string>();
            List<string> vecBili3 = new List<string>();

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

             l = w + k - 1;    //duljina prozora je jednaka zbroju sirine prozora i duljine minimazera -1

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
           string genome1 = genome.Replace("\n","");    //micemo razmake, tabove i novi red
           string genome3 = genome1.Replace("\r","");
         string genome2=genome3.Replace(" ","");
        
        
            var pomak = genome2.Length - l;
            int pom = genome2.Length;

            for(int i = 0; i<pomak+1; ++i)                   //trazimo interne minimazere
            {
                var g = FindSmallest(genome2.Substring(i, l), k);
                if (!vecBili.Contains(g))
                {
                    Console.WriteLine(g + "\n");
                    vecBili.Add(g);
                }
                
            }
       
            
            Console.WriteLine("________________"+ "\n");        //trazimo desne rubne minimazere
                for (int p=k; p < l; ++p)
            {
                var h = FindSmallest(genome2.Substring(0, p), k);
                if (!vecBili2.Contains(h))
                {
                    Console.WriteLine(h + "\n");
                    vecBili2.Add(h);
                }

            }

         
            Console.WriteLine("________________" + "\n");      //trazimo lijeve rubne minimazere
            for (int p = pom+1-k; p > (pom+1-l) ; --p)
            {
                int wsize = pom + 1 - p;
                var u = FindSmallest(genome2.Substring(p-1, wsize), k);
                if (!vecBili3.Contains(u))
                {
                    Console.WriteLine(u + "\n");
                    vecBili3.Add(u);
                }

            }
            stopWatch.Stop();                              //prestajemo mjeriti vrijeme, ispisujemo vrijeme i memoriju
            var vrijeme = stopWatch.Elapsed;
            long after = GC.GetTotalMemory(false);
            Console.WriteLine(after + " memorija");
            Console.WriteLine(vrijeme + "vrijeme");

           
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
