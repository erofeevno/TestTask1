using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimbirSoftTestTask {
    class TextReader {
        private StreamReader _stream;
        private string _filePath;
        public bool IsOk { get; private set; }

        public TextReader(string filePath) {
            _filePath = filePath;

            if (!File.Exists(_filePath)) {
                Console.WriteLine("File not found");
                IsOk = false;
                return;
            } else {
                try {
                    _stream = new StreamReader(_filePath);
                }
                catch (Exception e) {
                    Console.WriteLine("Не удалось открыть фаил с тектом:" + e.Message);
                    return;
                }
                IsOk = true;
            }
        }

        public string GetNextString() {
            if (_stream != null) {

                string st;

                try{
                    st = _stream.ReadLine();
                }
                catch (Exception e) {
                    Console.WriteLine("Ошибка при чтение стоки из файла:" + e.Message);
                    IsOk = false;
                    return null;
                }
                return st;
            } else
                return null;
        }

        public bool Eof {
            get { return _stream.EndOfStream; }
        }
    }
}
