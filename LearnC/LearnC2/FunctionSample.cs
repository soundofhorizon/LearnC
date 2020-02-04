using System;

namespace LearnC2
{
    class FunctionSample
    {
        static void Main(string[] args)
        {
            //とりあえずオーバーロード型を実装(少数ならintキャストするやつ)
            Console.WriteLine(sum(5));
            Console.WriteLine(sum(5.6));

            //関数に渡した変数を変更する場合、[ref 変数]を書くことで明示的にすると可読性が上がる^^
            String beforeText = "元の文章";
            Console.WriteLine(changeText(ref beforeText));

            //outを用いると変数の初期化をしなくても[渡した関数内で初期化される]ことを示す。
            //outの関数内で初期化した内容は単純に代入される
            //varは可変変数と呼ばれる。乱用すると変数の型が分からなくなり可読性下がる・。・(今回ならoutSample(int , String)の所をvarで示してる)
            Console.WriteLine(outSample(out var intValue, out var myBirth));
            Console.WriteLine(intValue);
            Console.WriteLine(myBirth);
        }


        public static int sum(int a)
        {
            //これはどの言語でも同じだが、条件分岐したならどの場合でも値は返しましょう。(エラーはいた時の例外処理で忘れがち)
            if (a % 2 == 0) 
            {
                return a + a;
            }
            else
            {
                a += 1;
                return a + a;
            }
        }

        public static int sum(double a)
        {
            int b = (int)a;
            return b + b;
        }

        public static String changeText(ref String a)
        {
            return a + " 変更しました。";
        }

        public static String outSample(out int a , out String b)
        {
            //out使ってるなら初期化してどうぞ
            a = 100;
            b = "2000/1/1";
            return (a + "は" + b + "に生誕されている");
        }
    }
}
