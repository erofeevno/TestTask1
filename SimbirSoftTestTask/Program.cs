using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.IO;

namespace SimbirSoftTestTask {
    class Program {
        static void Main(string[] args) {

            Console.Write("Введите путь к файлу словаря: ");
            string str = Console.ReadLine();

            WordList wl = new WordList(str);
            if (!wl.IsOk) {
                Console.Write("Не удалось открыть фаил словоря.");
                return;
            }

            Console.Write("Введите путь к файлу с текстом: ");
            str = Console.ReadLine();
            TextReader tr = new TextReader(str);
            if (!tr.IsOk) {
                Console.Write("Не удалось открыть фаил c текстом.");
                return;
            }

            Console.Write("Введите максимальное количество строк в выходном файле: ");
            string count = Console.ReadLine();
            
            HtmlFile html = new HtmlFile(uint.Parse(count));
            if (!html.IsOk) {
                Console.WriteLine("Не удалось создать html фаил.");
                return;
            }

            SearchAndProcessing.Go(wl, tr, html);

            html.Close();
        }
    }
}
