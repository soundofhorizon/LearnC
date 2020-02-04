using System;
using System.Linq;
using System.Text;

namespace LearnC2
{
    class UseSampleString
    {
        static void Main(string[] args)
        {
            String pass = "horizon";
            //ReadLineで入力を読む Trim[トリム]で半角スペースが途中にあっても抜くことが可能
            String input = Console.ReadLine().Trim();

            if(pass == input)
            {
                Console.WriteLine(input);
                Console.WriteLine("正しい入力だ");
            }
            //Spritで配列として分割する。csv読み込みで使うだろう
            String[] input2 = Console.ReadLine().Split(",");

            for (int j = 0; j < input2.Length; j++)
            {
                Console.WriteLine(input2[j]);
            }

            //上記for文は以下のように実装可能
            foreach(String x in input2)
            {
                Console.WriteLine(x);
            }

            var array = new[] { 1, 2, 3, 4, 5 };
            //もう少し頑張るとこうなる(index番号が偶数の時、表示する,Arrayである必要あり),using Lineq
            var showArray = array
                               .Where(x => x % 2 == 0);
            foreach (int x in showArray)
            {
                Console.WriteLine(x);
            }

            //文字列を頻繁に連結、置換する際は負荷の関係上これを使用せよ
            StringBuilder sb = new StringBuilder("元の文字列");
            for(int i = 0; i < 100; i++)
            {
                //Appendでただの追加、AppendLineで改行する。
                sb.Append(i);
                sb.AppendLine(" " + i);
            }
            Console.WriteLine(sb);
        }
    }
}
