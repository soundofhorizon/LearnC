using System;
using System.Collections.Generic;
using System.Text;

namespace LearnC3
{
    class Sample1
    {
        //フィールドを用意する、これは外部から変更されたくないのでprivateにする
        private int IntValue;
        //ここでコンストラクタを用いてIntValueを定める。オーバーロードが可能
        public Sample1()
        {
            IntValue = 5;
        }

        public Sample1(int intArg)
        {
            IntValue = intArg;
        }

        ~Sample1()
        {
            Console.WriteLine(@"クラスが破棄されます。
                                このとき1度のみ呼ぶ処理をデストラクタといいます。
                                ~を付けます  
                                ついでに、文章が長文の時、@をつけることで改行可能。");
        }

        //この関数はClassSample.csで使いたいのでpublicにする。(正味、書かなくても自動でpublicなのだがわかりやすく…)
        public void sumFunctiom(int IntValue = 10)
        {
            //この関数の仮引数のIntValueとフィールドにあるIntValueをthisで区別する
            int result = IntValue + this.IntValue;
            Console.WriteLine("入力した数字("+IntValue+")に"+this.IntValue+"を足した結果は"+result+"である");
        }
    }
}
