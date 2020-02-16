using System;
using System.Collections.Generic;
using System.Text;

namespace LearnC4
{
    //以下のように書くことでジェネリックなクラスを作れる。
    //where句により、T,Yに制約を付けられる。この場合、Tはstruct(値)である必要がある
    class Generic2<T,Y> where T : struct {
        private T _tvalue;
        private Y _yvalue;
        
        public Generic2(T tvalue , Y yvalue)
        {
            this._tvalue = tvalue;
            this._yvalue = yvalue;
            Console.WriteLine(_tvalue + " " + _yvalue);
        }


    }
}
