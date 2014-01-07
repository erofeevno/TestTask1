using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.IO;

namespace SimbirSoftTestTask {
    class HtmlFile {
        private uint _linePerFile;
        private string _fileName;
        private uint _lineInCurrentFile = 0;
        private uint _currentFileIndex = 0;
        private StreamWriter _stream;
        private HtmlTextWriter _html;
        public bool IsOk { get; private set; }

        public HtmlFile(uint linePerFile, string fileName = "Page") {
            try{

                _linePerFile = linePerFile;
                _fileName = fileName;
                _stream = new StreamWriter(_fileName + ".html", false, Encoding.UTF8);
                InitHtml();
                IsOk = true;
            }
            catch (Exception e) {
                Console.WriteLine("Не удалось создать html фаил:" + e.Message);
                IsOk = false;
            }
        }
        
        public void Close(){
            _html.WriteEndTag("BODY");
            _html.WriteEndTag("html");
            _html.Close();
        }

        private void InitHtml() {
            _html = new HtmlTextWriter(_stream);
            _html.WriteFullBeginTag("!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\"");
            _html.WriteFullBeginTag("html");
            _html.WriteFullBeginTag("HEAD");
            _html.WriteEndTag("HEAD");
            _html.WriteFullBeginTag("BODY");
        }

        public void WriteString(string str) {
            try{
                _html.Write(str);
                _lineInCurrentFile++;

                if (_lineInCurrentFile >= _linePerFile){
                    _currentFileIndex++;
                    _lineInCurrentFile = 0;
                    _html.Write("<br><a href=\"" + _fileName + _currentFileIndex + ".html" + "\">Go to next</a>");
                    Close();
                    _stream.Close();
                    _stream = new StreamWriter(_fileName + _currentFileIndex + ".html", false, Encoding.UTF8);
                    InitHtml();
                }
            }
            catch (Exception e) {
                Console.WriteLine("Не удалось записать сторку в фаил" + e.Message);
                IsOk = false;
            }
        }
    }
}
