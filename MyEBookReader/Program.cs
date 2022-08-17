using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Text;

namespace MyEBookReader
{
    class Program
    {
        private static string theEBook;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
             {
                 theEBook = eArgs.Result;
                 Console.WriteLine("Download complete.");
                 GetStats();
             };
            // Загрузить электронную книгу Чарльза Диккенса "A RTale of Two Cities".
            // Может понадобиться двукратное выполнение этого кода, если ранее вы
            // не посещали данный сайт, поскольку при первом его посещении появляется
            // окно с сообщением, предотвращающее нормальное выполнение кода.
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }
        static void GetStats()
        {
            // Получить слова из электронной книги.
            string[] words = theEBook.Split(new char[]
            { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
            StringSplitOptions.RemoveEmptyEntries);
            // Найти 10 наиболее часто встречающихся слов.
            string[] tenMostCommon = FindTenMostCommon(words);
            // Получить самое длинное слово.
            string longestWord = FindLongestWord(words);
            // Когджа все задачи завершены, построить строку,
            // показывающую всю статистику в окне сообщений.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.Append(s);
            }
            // Самое длинное слово.
            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();
            // Информация о книге.
            Console.WriteLine(bookStats.ToString(),"Book info");
        }
    }
}
