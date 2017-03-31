using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextFileWordCount;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string S = "go do that thing that you do so well";
            string path = @"C:\Users\atelespan\Documents\Visual Studio 2015\Projects\TextFileWordCount\TextFileWordCount\unitTestText.txt";

            //building the expected
            List<String> expected = S.Split().OrderBy(x=>x).ToList();

            //building the actual list
            WordCounts wc = new WordCounts(path);            
            Dictionary<string,int> occurences = wc.getDictionary();
            List<String> actualList = new List<string>();
            foreach (var o in occurences)
            { 
                for (int i = o.Value; i > 0; i--)
                {
                    actualList.Add(o.Key);
                }
            }

            var actual = actualList.OrderBy(x => x).ToList();

            Assert.AreEqual(expected.Count, actual.Count);

            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
