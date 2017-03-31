using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileWordCount
{
    public class WordCounts
    {
        private string path;

        private string S;

        private Dictionary<String, int> occurences;

        public WordCounts(string path)
        {
            if (path != null && path.IndexOfAny(Path.GetInvalidPathChars()) == -1 && Path.HasExtension(path))
            {
                setPath(path);
                setS();
                setDictionary();
            }
        }

        private void setPath(string path)
        {
            this.path = path;
        }

        private void setS(string S)
        {
            this.S = S;
        }
        private void setS()
        {
            if (path != null && File.Exists(path))
            {
                S = File.ReadAllText(path);
            }
            else
            {
                Console.WriteLine("The file {0} does not exist!", path);
            }
        }

        public Dictionary<string, int> getDictionary()
        {
            return occurences;
        }

        private void setDictionary()
        {
            if (S != null)
            {
                occurences = new Dictionary<string, int>();

                var punctuation = S.Where(Char.IsPunctuation).Distinct().ToArray();
                var words = S.Split().Select(x => x.Trim(punctuation).ToLower()).Where(y => !y.Equals(""));
                var distinctWords = words.Distinct();

                foreach (var w in words)
                {
                    if (occurences.ContainsKey(w))
                    {
                        occurences[w]++;
                    }
                    else
                    {
                        occurences.Add(w, 1);
                    }
                }
            }            
        }        
    }
}
