using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTreeContainer{
    class TreeElement{

        List<TreeElement> _list;
        public Char symbol;
        public bool _canBeEnd;

        public TreeElement(string word){
            _list = new List<TreeElement>();
            if (word.Length > 1){
                symbol = word[0];
                word = word.Substring(1);
                _list.Add(new TreeElement(word));
            }else {
                symbol = word[0];
                _canBeEnd = true;
            }
        }

        public void Add(string word) {

            if (word == "") {
                _canBeEnd = true;
                return;
            }

            TreeElement t = _list.Find(
                    (TreeElement element) => {
                        return element.symbol == word[0];
                    }
            );

            if (t != null){
                if (word.Length == 1) {
                    t._canBeEnd = true;
                    return;
                }
                word = word.Substring(1);
                t.Add(word);
            }
            else {
                _list.Add(new TreeElement(word));
            }

        }

        public bool Search(string word) {

            if (word == "")
                return false;

            TreeElement nextSymbol = _list.Find((TreeElement item) => {
                return item.symbol == word[0];
            });

            if (nextSymbol == null) {
                return false;
            } else {
                word = word.Substring(1);
                if (word.Length == 0 && nextSymbol._canBeEnd) {
                    return true;
                }

                if (word.Length == 0)
                    return false;

                return nextSymbol.Search(word);
            }
        }
    }
}
