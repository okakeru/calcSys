using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace easyCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Width = 500;
            this.shownPeriodicTable.Visibility = Visibility.Visible;
            this.hidePeriodicTable.Visibility = Visibility.Hidden;

            // 背景色の色がxamlから設定できなかったため、ロード時に設定する
            //windowGrid.
        }

        /// <summary>
        /// 画面拡大ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPeriodicTable_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 1000;
            this.shownPeriodicTable.Visibility = Visibility.Hidden;
            this.hidePeriodicTable.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 画面縮小ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hidePeriodicTable_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 500;
            this.shownPeriodicTable.Visibility = Visibility.Visible;
            this.hidePeriodicTable.Visibility = Visibility.Hidden;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "0";
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "8";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "9";
        }

        private void period_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += ".";
        }

        private void exponential_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 全削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allClear_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text = "";
        }

        /// <summary>
        /// 一文字削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            // 今テキストボックスに入っている文字列を取得する
            var calcString = formulaText.Text;

            calcString = calcString.Substring(0, calcString.Length - 1);

            formulaText.Text = calcString;
        }

        private void multiplication_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "×";
        }

        private void division_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "÷";
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "+";
        }

        private void minas_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "-";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            // 計算式テキストボックスに×÷が入っているかを判断
            string formulaString = formulaText.Text;

            // 計算式に入っている掛け算割り算記号をC#で使用できるものに置換
            if (formulaString.Contains("×"))
            {
                formulaString = formulaString.Replace("×","*");
            }

            if (formulaString.Contains("÷"))
            {
                formulaString = formulaString.Replace("÷", "/");
            }

            // 掛け算割り算を置換した計算式を用いて値を計算する
            System.Data.DataTable dt = new System.Data.DataTable();
            double result = (double)dt.Compute(formulaString, "");

            resultText.Text = result.ToString();
        }

        /// <summary>
        /// 計算用数字キー、記号キー押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formulaText_KeyDown(object sender, KeyEventArgs e)
        {
            // 押下されたキーの文字を取得
            string pressKey = e.Key.ToString();

            // テンキー押下時処理追加
            // 文字の場合は無視
            if (pressKey == "D0" || pressKey == "NumPad0")
            {
                formulaText.Text += "0";
            }
            else if (pressKey == "D1" || pressKey == "NumPad1")
            {
                formulaText.Text += "1";
            }
            else if (pressKey == "D2" || pressKey == "NumPad2")
            {
                formulaText.Text += "2";
            }
            else if (pressKey == "D3" || pressKey == "NumPad3")
            {
                formulaText.Text += "3";
            }
            else if (pressKey == "D4" || pressKey == "NumPad4")
            {
                formulaText.Text += "4";
            }
            else if (pressKey == "D5" || pressKey == "NumPad5")
            {
                formulaText.Text += "5";
            }
            else if (pressKey == "D6" || pressKey == "NumPad6")
            {
                formulaText.Text += "6";
            }
            else if (pressKey == "D7" || pressKey == "NumPad7")
            {
                formulaText.Text += "7";
            }
            else if (pressKey == "D8" || pressKey == "NumPad8")
            {
                formulaText.Text += "8";
            }
            else if (pressKey == "D9" || pressKey == "NumPad9")
            {
                formulaText.Text += "9";
            }
            else if (pressKey == "Add")
            {
                formulaText.Text += "+";
            }
            else if (pressKey == "Subtract")
            {
                formulaText.Text += "-";
            }
            else if (pressKey == "Multiply")
            {
                formulaText.Text += "×";
            }
            else if (pressKey == "Divide")
            {
                formulaText.Text += "÷";
            }
            else if (pressKey == "Return")
            {
                // イベントを呼ぶ用のハンドラを作成する
                var hand = new RoutedEventArgs();
                var obj = new object();

                // イコールボタン押下時のイベントを呼ぶ
                equal_Click(obj, hand);
            }

            // テキストボックス内のカーソル位置を最後尾に設定
            formulaText.Select(formulaText.Text.Length, 0);

            // keyDownイベントを伝播せずテキスト入力を行う（キーボード入力時2重入力を防ぐ）
            e.Handled = true;
        }
    }
}
