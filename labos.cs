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

    

       }
    }
}
