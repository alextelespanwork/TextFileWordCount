using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileWordCount
{
    class Program
    {        
        static void Main(string[] args)
        {            
            Console.WriteLine("Please insert the path of the file");
            string path = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(path))
            {                
                path = @"C:\Users\atelespan\Documents\Visual Studio 2015\Projects\TextFileWordCount\TextFileWordCount\text.txt";
                Console.WriteLine("The following default path has been selected: " + path);
                Console.WriteLine();
            }

            WordCounts wc = new WordCounts(path);
            Dictionary<String, int> occurences = wc.getDictionary();

            if (occurences != null)
            {
                foreach (var o in occurences)
                {
                    Console.WriteLine(o.Value + " : " + o.Key);
                }
            }

            Console.ReadLine();
            
        }                                     
    }
}
