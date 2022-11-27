using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Typing_Speed
{
    class Program
    {
        static void Main(string[] args)
        {

            var wordList = GetWordList();

            var stopwatch = new Stopwatch();
            var correctWordsCount = 0;
            var totalWords = 0.0;
            var random = new Random();


            Console.WriteLine("Нажмите enter, когда будете готовы!");
            Console.ReadKey();
            Console.WriteLine("Секундомер запущен! У вас есть 30 секунд! \n");


            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(30))
            {
                var index = random.Next(0, wordList.Count);

                Console.ForegroundColor = ConsoleColor.Yellow; 
                Console.WriteLine($"{wordList[index]}:");
                Console.ForegroundColor = ConsoleColor.White;

                var word = Console.ReadLine();

                if (wordList[index] == word)
                {
                    correctWordsCount++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Четко! \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неправильно! Было написано '{word}' вместо '{wordList[index]}' \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                totalWords++;
            }

            stopwatch.Stop();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Время истекло!!!");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Правильно написанные: {correctWordsCount}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Процент правильности: {(correctWordsCount / totalWords * 100).ToString("#.##")}%");
            Console.ForegroundColor = ConsoleColor.White;

            Thread.Sleep(2000);
        }

        public static List<string> GetWordList()
        {
            var dummyText = "When the neighbor's cat found out that the red kitten's name was Woof, he scratched his back against the chimney of the neighbor's house and said. I would not advise a kitten with that name to go down into the yard. In the yard, a kitten with that name is waiting for some trouble.The kitten heard Woof and thought: \"What kind of trouble is this and why are they waiting for me?\". Woof immediately went down to the yard and carefully examined all the nooks and crannies — there was no trouble anywhere. At this time, a large dog came out into the yard. She saw Woof and thought: Here comes the red kitten. I hadnt noticed him before. Hey, red, the dog called, \"what's your name?\" Woof! said the kitten. Whoooo?! the dog was surprised. Woof! Oh, you're still teasing, the dog screamed and chased the kitten so fast that she almost caught him. When the kitten Woof rushed to his attic, the neighbor's cat asked him Well, did you make sure that trouble was waiting for you in the yard? No,said the kitten,I was not convinced. I was looking for them, looking for them, and I almost found them, but the dog drove me away.".ToLower();

            dummyText = Regex.Replace(dummyText, "[^a-z0-9 _]+", " ");

            var wordList = new List<string>();

            wordList = dummyText.Split(' ').ToList();

            wordList.RemoveAll(word => word.Length < 3);


            wordList = wordList.Distinct().ToList();

            return wordList;
        }
    }
}
