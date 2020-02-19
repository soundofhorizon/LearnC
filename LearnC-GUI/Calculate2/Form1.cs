using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        interface IOperator
        {
            //interface実装時には必ず説明を入れる

            ///<summary>
            ///与えられたパラメータに2項演算を適用し結果を返送する
            ///</summary>
            ///<param name="left">左項値</param>
            ///<param name="right">右項値</param>
            ///<returns>計算結果</returns>

            object Calculate(int left ,int right);
        }
        class Plus : IOperator
        {
            public object Calculate(int left, int right)
            {
                return left + right;
            }
            public override string ToString()
            {
                return "+";
            }
        }
        class Minus : IOperator
        {
            public object Calculate(int left ,int right)
            {
                return left - right;
            }
            public override string ToString()
            {
                return "-";
            }
        }
        class Asterrisk : IOperator
        {
            public object Calculate(int left, int right)
            {
                return left * right;
            }
            public override string ToString()
            {
                return "×";
            }
        }
        class Slash : IOperator
        {
            public object Calculate(int left, int right)
            {
                return left / right;
            }
            public override string ToString()
            {
                return "/";
            }
        }

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new Plus());
            comboBox1.Items.Add(new Minus());
            comboBox1.Items.Add(new Asterrisk());
            comboBox1.Items.Add(new Slash());
            //選択状態を配列１番目に
            comboBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Random a = new System.Random();
                var left = a.Next(100) * 100;
                label1.Text = left.ToString();
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        label3.Text = "足す数字";
                        button1.Text = "Add";
                        break;
                    case 1:
                        label3.Text = "引く数字";
                        button1.Text = "Substract";
                        break;
                    case 2:
                        label3.Text = "掛ける数字";
                        button1.Text = "Multiply";
                        break;
                    case 3:
                        label3.Text = "割る数字";
                        button1.Text = "Divide";
                        break;
                }
                var right = int.Parse(textBox1.Text);
                var operation = comboBox1.SelectedItem as IOperator;
                label5.Text = operation.Calculate(left, right).ToString();
            }
            catch(OverflowException)
            {
                MessageBox.Show("数値が大きすぎ(小さすぎ)なんだよなあ…");
            }
            catch(FormatException)
            {
                MessageBox.Show("それは数字なのか？？？？");
            }
            textBox1.Select();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
