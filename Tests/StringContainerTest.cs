using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using StringTreeContainer;
using SimbirSoftTestTask;
using Tests;

namespace Tests{
    public class StringContainerTest{
        [Test]
        public void Test1() {
            
            TreeContainer con = new TreeContainer();
            
            foreach (string word in Helpers.WordList) {
                con.AddWord(word);
            }
            
            foreach (string word in Helpers.WordList) {
                Assert.AreEqual(true, con.Search(word),"Error in word: " + word);
            }
        }
    }
}
