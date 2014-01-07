using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftTestTask{
    static class SearchAndProcessing{
        public static void Go(WordList wl, TextReader tx, HtmlFile html) {

            string primeString;
            char[] seporators = { '.', ',', ';', '?', '!', ':', '"', '*', '^', '#', '$', '%', '&', '/', ' ','\n','-','(',')' };

            while (!tx.Eof && wl.IsOk && tx.IsOk && html.IsOk) {
                primeString = tx.GetNextString();
                string[] arr;
                arr = primeString.Split(seporators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in arr) {
                    if (wl.Search(item.ToLower())) {
                        primeString = primeString.Replace(item, "<b><i>" + item + "</i></b>");
                    }
                }

                html.WriteString("<br>" + primeString);
            }
        }
    }
}
