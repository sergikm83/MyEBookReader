using System;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace MyEBookReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
             {
                 var theEBook = eArgs.Result;
                 Console.WriteLine("Download complete.");
                 GetStats();
             };
            // Загрузить электронную книгу Чарльза Диккенса "A RTale of Two Cities".
            // Может понадобиться двукратное выполнение этого кода, если ранее вы
            // не посещали данный сайт, поскольку при первом его посещении появляется
            // окно с сообщением, предотвращающее нормальное выполнение кода.
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }
    }
}
