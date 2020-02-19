using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        interface IButtonAction
        {
            //decimal型を利用して大きな型を利用可能にする
            decimal Click(decimal currentValue, Label display, IButtonAction previousAction);
        }
        class NumberButtonAction : IButtonAction
        {
            //変化することのない変数のためreadonly
            readonly int displayNumber;

            internal NumberButtonAction(int number)
            {
                displayNumber = number;
            }
            public decimal Click(decimal currentValue, Label display, IButtonAction previousAction)
            {
                if (display.Text == "0" || previousAction is Operator)
                {
                    display.Text = displayNumber.ToString();
                }
                else
                {
                    if (IsOverFlow(display.Text))
                    {
                        MessageBox.Show("これ以上入力できません");
                    }
                    else
                    {
                        display.Text += displayNumber;
                        //文字列+ほかの型を実行すると自動的にほかの型はToString()される
                    }
                }
                return currentValue;
            }
            bool IsOverFlow(string current)
            {
                decimal n = decimal.Parse(current);

                //decimal型の1/10より大きいかどうかで判断する
                return decimal.MaxValue / 10 <= n;
            }
        }

        class Operator : IButtonAction
        {
            static Func<decimal, decimal, decimal> previousCalculate = (lastValue, newValue) => newValue;
            //Func<in,in,out>で型を設定する。
            readonly Func<decimal, decimal, decimal> calculate;
            internal Operator(Func<decimal, decimal, decimal> calc)
            {
                calculate = calc;
            }
            public decimal Click(decimal currentValue, Label display, IButtonAction previousAction)
            {
                try
                {
                    decimal nextVal = previousCalculate(currentValue, decimal.Parse(display.Text));

                    previousCalculate = calculate;
                    display.Text = nextVal.ToString();

                    return nextVal;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("オーバーフロー！");
                    return currentValue;//計算しなかったことにする
                }
            }
            internal static void ResetOperetion()
            {
                //ここはACボタンを押したときに反応する
                previousCalculate = (lastValue, newValue) => newValue;
            }
        }
        class ClearEntryButton : IButtonAction
        {
            //Clickメソッドをオーバーライドできるようにする
            public virtual decimal Click(decimal currentValue, Label display, IButtonAction previousAction)
            {
                //CEを押した際に反応する
                display.Text = "0";
                return currentValue;
            }
        }
        class AllClearButton : ClearEntryButton
        {
            public override decimal Click(decimal currentValue, Label display, IButtonAction previousAction)
            {
                //演算キーを押してない状態にする
                Operator.ResetOperetion();
                //baseを指定すると、スーパークラスのメソッドを呼び出せる。
                //これにより、ClearEntryButtonを実行する
                return base.Click(currentValue, display, previousAction);
            }
        }
        //=を打つまえなので0で初期化される。
        decimal currentValue;
        IButtonAction previousAction;
        public Form1()
        {
            InitializeComponent();
            previousAction = new NumberButtonAction(0);
            buttonNum0.Tag = previousAction;
            buttonNum1.Tag = new NumberButtonAction(1);
            buttonNum2.Tag = new NumberButtonAction(2);
            buttonNum3.Tag = new NumberButtonAction(3);
            buttonNum4.Tag = new NumberButtonAction(4);
            buttonNum5.Tag = new NumberButtonAction(5);
            buttonNum6.Tag = new NumberButtonAction(6);
            buttonNum7.Tag = new NumberButtonAction(7);
            buttonNum8.Tag = new NumberButtonAction(8);
            buttonNum9.Tag = new NumberButtonAction(9);
            buttonAC.Tag = new AllClearButton();
            buttonCE.Tag = new ClearEntryButton();
            buttonSlash.Tag = new Operator((left, right) =>
            {
                if (right == 0)
                {
                    MessageBox.Show("0除算は禁止事項です");
                    return 0;
                }
                else
                {
                    return left / right;
                }
            });
            buttonAsterisk.Tag = new Operator((left, right) => left * right);
            buttonPlus.Tag = new Operator((left, right) => left + right);
            buttonMinus.Tag = new Operator((left, right) => left - right);
            buttonEqual.Tag = new Operator((left, right) => right);
            foreach (var button in panel1.Controls.OfType<Button>())
            {
                if (button.Text != ".")
                {
                    button.Click += ButtonClick;
                }
            }
            void ButtonClick(object sender, EventArgs e)
            {
                var button = sender as Button;
                currentValue = (button.Tag as IButtonAction).Click(currentValue, label1, previousAction);

                previousAction = button.Tag as IButtonAction;
            }
        }
    }
}