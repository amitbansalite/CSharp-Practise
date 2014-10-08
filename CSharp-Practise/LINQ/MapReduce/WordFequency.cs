using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1.LINQ.MapReduce
{
    public class WordFequency
    {
        public void Test(string sourceDirPath)
        {
            var delimiters = Enumerable.Range(0, 256).Select(i => (char)i)
                                .Where(c => Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
                                .ToArray();
            IEnumerable<string> files = null;
            try
            {
                files = Directory.EnumerateFiles(sourceDirPath, "*.*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException u)
            {
                Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                return;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The specified directory {0} was not found.", sourceDirPath);
            }

            var filterFiles = from file in files.AsParallel()
                              let ext = Path.GetExtension(file)
                              where ext == ".txt" || ext == ".java"
                              select file;
            
            var result = CountWordFrequencyAsParallel(filterFiles, delimiters);
            //var result = CountWordFrequencyAsSequential(files, delimiters);

            try
            {
                foreach (var keyValuePair in result)
                {
                    Console.WriteLine(keyValuePair.Key + " : " + keyValuePair.Value);
                }
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            Console.ReadLine();
        }

        private static IEnumerable<KeyValuePair<string, int>> CountWordFrequencyAsSequential(IEnumerable<string> files, char[] delimiters)
        {
            // using LINQ
            var x = files.SelectMany(path => File.ReadLines(path).SelectMany(line => line.Split(delimiters)))
                            .GroupBy(word => word)
                            .SelectMany(group => new[] { new KeyValuePair<string, int>(group.Key, group.Count()) } );

            // using LINQ extension method
            return files.MapReduce(
                                       path => File.ReadLines(path).SelectMany(line => line.Split(delimiters)),
                                       word => word,
                                       group => new[] { new KeyValuePair<string, int>(group.Key, group.Count()) }
                                   );
        }

        private static IEnumerable<KeyValuePair<string, int>> CountWordFrequencyAsParallel(IEnumerable<string> files, char[] delimiters)
        {
            return files.AsParallel().MapReduce(
                                       path => File.ReadLines(path).SelectMany(line => line.Split(delimiters)),
                                       word => word,
                                       group => new[] { new KeyValuePair<string, int>(group.Key, group.Count()) }
                                   );
        }
    }
}
