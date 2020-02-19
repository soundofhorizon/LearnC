using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        class Opelator
        {
            readonly string displayString;
            readonly Func<int, int, object> calclateFunc;//ラムダ式を設定する。ここは一度設定したら変更してはならない

            //コンストラクタ内で、Funcの部分はラムダ式であることを伝える
            internal Opelator(string symbol, Func<int, int, object> calcFunc)
            {
                displayString = symbol;
                calclateFunc = calcFunc;
            }

            public override string ToString()
            {
                return displayString;
            }

            ///<summary>
            ///与えられたパラメータをint型にして所定の演算を実行する
            ///</summary>
            ///<param name="left">左項</param>
            ///<param name="right">右項</param>
            ///<returns>計算結果</returns>
            ///<exception cref="ArgmentException">パラメータ変換ができなかったときスローされます</exception>

            internal string Calcalate(string left, string right)
            {
                return calclateFunc(ToInt(left), ToInt(right)).ToString();
            }

            //ここではToIntを実装する。ここで引数が型異常の時エラーを出すようにする
            int ToInt(string value)
            {
                try
                {
                    return int.Parse(value);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(value + "は不正な値です", e);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new Opelator("+", (left, right) => { return left + right; }));
            comboBox1.Items.Add(new Opelator("-", (left, right) => { return left - right; }));
            comboBox1.Items.Add(new Opelator("×", (left, right) => { return left * right; }));
            comboBox1.Items.Add(new Opelator("÷", (left, right) => { return left / right; }));
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ドロップダウンリストで選択状態であるアイテム(+,-,×,÷)をOperetor型で検索する
            var calculator = comboBox1.SelectedItem as Opelator;
            try
            {
                label5.Text = calculator.Calcalate(textBox1.Text, textBox2.Text).ToString();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message);
            }
            textBox1.SelectAll();
            textBox1.Focus();
        }
    }
}
