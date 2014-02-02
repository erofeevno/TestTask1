using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StringTreeContainer;
using System.Text.RegularExpressions;

namespace SimbirSoftTestTask {

    public sealed class WordList: IDisposable {

        private string _filePath;
        private StreamReader _stream;
        public bool IsOk { get; private set; }

        TreeContainer _list = null;

        public WordList(string filePath) {

            _filePath = filePath;

            if (!File.Exists(_filePath)) {
                Console.WriteLine("File not found");
                IsOk = false;
                return;
            } 
            else {
                try{
                    _stream = new StreamReader(_filePath);
                    _list = new TreeContainer();
                    ReadDictionary();
                    IsOk = true;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    IsOk = false;
                }
            }
        }

        private void ReadDictionary() {
            while (!_stream.EndOfStream) {
                string str = _stream.ReadLine();
                if (Regex.IsMatch(str, @"^\w{1,}[-]?\w*$"))
                {
                    _list.AddWord(str.ToLower());
                }
                else {
                    Console.WriteLine("WARNING: " + str + " неправильная строка. В поиске использоваться не будет.");
                }
            }
        }

        public bool Search(string word) {
            return _list.Search(word);
        }

        public void Dispose()
        {
            if (_stream != null)
                _stream.Close();
        }
    }
}
