namespace LearnC3
{
    class ClassSample
    {
        static void Main(string[] args)
        {
            //Sample1クラスを利用する
            Sample1 sample1 = new Sample1();
            sample1.sumFunctiom();
            sample1.sumFunctiom(100);
            
            //Person.csで記載したもので、ホリゾンとウンチャマを呼んでみる
            Person eternalhorizon = new Person("EternalHorizon", "男", 19);
            Person unchama = new Person("Unchama", "女", 4);

            eternalhorizon.GetName();
            unchama.GetName();
        }
    }
}
