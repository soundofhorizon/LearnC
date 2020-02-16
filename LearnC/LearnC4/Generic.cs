using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LearnC4
{
    class Generic
    {
        static void Main(string[] args)
        {
            /* C#は動的なプログラムは望ましくない。
             * そのため、以下に挙げる非ジェネリックな関数は
             * その下にあるジェネリックな関数にするとよい
             */

            /* 非ジェネリックな関数は以下のものがある。
             * ArrayList
             */
            ArrayList list = new ArrayList();
            list.Add("文字列！！！");//String!
            list.Add(4);//int!

            /* 配列にすべてアクセスする方法の1つはforeachであった
             * この場合、listに"何の型が入ってるかわからない(object型が飛んでくる)という問題が出る
             * 
             * このようなlistを扱う際はStringか？intか？をキャストして使う必要がある。
             * 静的な言語であるC#では可能な限りキャストするのは控えるべき。
             */

            foreach (var i in list) {
                Console.WriteLine(i);
            }

            //以下がジェネリックな関数の例。基本、何か<T>の形を持つ。以下より、T -> Type(型)を指す

            //List : 基本的

            List<String> stringList = new List<String>();
            stringList.Add("文字列です");

            // stringList.Add(3); これはエラーとなります
            // stringList.Add('a'); charとStringは根本的に違いました。

            stringList.Add("なにか");

            //安心してStringで受け取れる
            foreach (string a in stringList)
            {
                Console.WriteLine(a);
            }

            /* Dictionary : Pythonの辞書型のような振る舞いをする(というかそのままでは)。
             *              第1引数をkey(ほかの要素と識別できる唯一無二のもの)、それに紐づける
             *              情報…という形で突っ込む
             */
            Dictionary<String, String> studentClass = new Dictionary<string, string>();

            //実際の場では名前は被ることが多いためkeyとしては望ましくないが、まぁね？
            studentClass.Add("立花", "1-1");
            studentClass.Add("野獣先輩", "1-114514");
            studentClass.Add("ホリゾン", "6-1");

            if (studentClass.ContainsKey("ホリゾン"))
            {
                Console.WriteLine(studentClass["ホリゾン"]);
            }
            int count = 0;
            foreach(var i in studentClass)
            {
                count++;
                Console.WriteLine(count + " : " + i.Key + " -> " + i.Value);
            }

            /* SortedList , SortedDictionary : 上記の上位互換、突っ込んだ内容をソートしてくれる
             *                                 実質PythonのRadisにあったsaddみたいなものである。
             *                                 List　<　Dictionaryのパフォーマンスをもち、メモリは
             *                                 List　<　Dictionaryで容量を食う。
             *                                 SortedDictionary<T,T> list = new SortedDictionary<T,T>();
             *                                 で取り扱える。内容はList、Dictionaryと同じ。処理順番がソートされる。
             */

            /* Queue , Stack : 先から見るか後から見るか。追加した順番通りに考えるもの。
             *                「もうこの配列は最初からしか取り出すことない～」って場合はQueueを利用する。
             *                 最後から取り出す場合はStack。
             *                 双方(FIFO(first in first out)、LIFO(last in first out))と呼ばれる。
             */
            Stack<int> stackExample = new Stack<int>();
            stackExample.Push(1);
            stackExample.Push(2);
            stackExample.Push(3);
            stackExample.Push(4);

            foreach(int m in stackExample)
            {
                Console.WriteLine(m);
            }

            //ジェネリックなクラスを呼び出す
            Generic2<int, String> generic2 = new Generic2<int, string>(4,"文字列");

            int[] Array = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine("\n１～５から２で割った余りが0になる場合を出力します\n");
            foreach (int i in Array.Where(i => i % 2 == 0))
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n１～５から２で割った余りが0になる場合の数字を２倍した結果を出力します\n");
            foreach (int j in Array.Where(i => i % 2 == 0).Select(i => i * 2))
            {
                Console.WriteLine(j);
            }

            //こいつはな！SQLみたいな文章を書いて配列の取り出しができるんだ！

            IEnumerable<int> linqList = from i in Array where i % 3 == 1 select i;

            Console.WriteLine("\n１～４、10000のなかから３で割った余りが1になる数を出力します");

            /* ここで重要なのは、実際に配列から取り出す操作(今回ならforeach)が行われるまでは
             * LinQによる評価は行われない点である。
             */
            Array[4] = 10000; //ここでは評価されない

            foreach (int i in linqList)
            {
                Console.WriteLine(i);//ここで評価される
            }
        }
    }
}
