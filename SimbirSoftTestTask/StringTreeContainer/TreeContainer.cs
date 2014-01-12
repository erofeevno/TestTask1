using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTreeContainer{
    public class TreeContainer{
        List<TreeElement> _startCharList;

        public TreeContainer() {
            _startCharList = new List<TreeElement>();
        }

        public void AddWord(string word){

            if (word == "" || word == null)
                return;

            TreeElement startElement = _startCharList.Find(
                (TreeElement item) => {
                    return item.symbol == word[0];
                });

            if (startElement != null) {
                word = word.Substring(1);
                startElement.Add(word);
            } 
            else {
                _startCharList.Add(new TreeElement(word));
            }            
        }

        public bool Search(string word) {

            TreeElement startElement = _startCharList.Find(
                (TreeElement item) => {
                    return item.symbol == word[0];
                });

            if (startElement == null) {
                return false;
            }

            else{
                if (word.Length == 1 || startElement._canBeEnd)
                    return true;
                word = word.Substring(1);
                return startElement.Search(word);
            }
        }
    }
}
