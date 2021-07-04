using System;
using System.Linq;

namespace WordCount {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please provide the path of the file.");
            string text = System.IO.File.ReadAllText(Console.ReadLine());

            int totalWords = 0;
            int totalChars = text.Replace(" ", "").Length;

            foreach (string word in text.Split(" ")) {
                totalWords++;
            }

            Console.WriteLine("================================================================================");
            Console.WriteLine("Final Results");
            Console.WriteLine("================================================================================");
            Console.WriteLine("There is " + totalWords + " words in this text file.");
            Console.WriteLine("There is " + totalChars + " characters in this text file.");
            Console.WriteLine("================================================================================");
            Console.WriteLine("Most Common Words");
            int pos = 1;
            foreach (var result in text
                .Split(" ")
                .GroupBy(x => x)
                .Select(x => new {
                    KeyField = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(10)) {
                Console.WriteLine(pos++  + " " + result.KeyField + " " + "[" + result.Count + "]");
            }
            
            Console.WriteLine("================================================================================");
            Console.WriteLine("Least Common Words");
            pos = 1;
            foreach (var result in text
                .Split(" ")
                .GroupBy(x => x)
                .Select(x => new {
                    KeyField = x.Key,
                    Count = x.Count()
                })
                .OrderBy(x => x.Count)
                .Take(10)) {
                Console.WriteLine(pos++ + " " + result.KeyField + " " + "[" + result.Count + "]");
            }
            Console.WriteLine("================================================================================");
        }
    }
}
