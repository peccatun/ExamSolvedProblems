using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsAndDefinitions = Console.ReadLine().Split(" | ");
            Dictionary<string, List<string>> collectionWithWords = new Dictionary<string, List<string>>();
            for (int i = 0; i < wordsAndDefinitions.Length; i++)
            {
                string[] wordAndDefinition = wordsAndDefinitions[i].Split(": ");
                if (collectionWithWords.ContainsKey(wordAndDefinition[0]))
                {
                    if (!collectionWithWords[wordAndDefinition[0]].Contains(wordAndDefinition[1]))
                    {
                        collectionWithWords[wordAndDefinition[0]].Add(wordAndDefinition[1]);
                    }
                }
                else
                {
                    collectionWithWords.Add(wordAndDefinition[0], new List<string>());
                    collectionWithWords[wordAndDefinition[0]].Add(wordAndDefinition[1]);
                }
            }
            string[] word = Console.ReadLine().Split(" | ");
            for (int i = 0; i < word.Length; i++)
            {
                if (collectionWithWords.ContainsKey(word[i]))
                {
                    Console.WriteLine(word[i]);
                    collectionWithWords[word[i]] = collectionWithWords[word[i]].OrderByDescending(x => x.Length).ToList();
                    foreach (var definition in collectionWithWords[word[i]])
                    {
                        Console.WriteLine($"-{definition}");
                    }
                }
            }
            string command = Console.ReadLine();
            if (command == "End")
            {
                return;
            }
            if (command == "List")
            {
                List<string> keyWords = collectionWithWords.OrderBy(x => x.Key).Select(k => k.Key).ToList();
                Console.WriteLine(string.Join(" ",keyWords));
            }
        }
    }
}
