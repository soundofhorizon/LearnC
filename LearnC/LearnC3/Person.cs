using System;
using System.Collections.Generic;
using System.Text;

namespace LearnC3
{
    class Person
    {
        //「人」に必要な最低限の要素としてとりあえず「名前、性別、年齢」が必要だとしよう。
        //ここでは人を紹介する基盤を記述する

        private String name,sex;
        private int year;
        public Person(String name , String sex , int year)
        {
            this.name = name;
            this.sex = sex;
            this.year = year;
        }

        public void GetName()
        {
            //\nは改行コードを示す
            Console.WriteLine("\n"+this.name + "は、" + sex + "で"+year+"歳です.");
        }
    }
}
