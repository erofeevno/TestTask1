using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Tests{

    static public class Helpers{

        static private List<string> wordList;

        static public List<string> WordList {
            get {
                if (wordList == null)
                    InitializeWordList();
                return wordList; 
            }
        }

        static void InitializeWordList() {
            wordList = new List<string>();
            wordList.Add("test");
            wordList.Add("юникод");
            wordList.Add("http://xхx.xххх.xxxxx.хx/%D1%82%D1%83%D1%80%D1%8B/%D0%9F%D0%B5%D1%80%D1%83/97_%D0%A0%D0%B5%D0%BA%D0%BB%D0%B0%D0%BC%D0%BD%D1%8B%D0%B9_%D1%82%D1%83%D1%80_%D0%B2_%D0%9F%D0%B5%D1%80%D1%83");
            wordList.Add("a");
            wordList.Add("a"); 
        }
    }
}
