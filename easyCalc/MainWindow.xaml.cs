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
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
using System.Data;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using easyCalc.language;
using System.ComponentModel;
using easyCalc.other;

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

            shownHistory.Visibility = Visibility.Visible;
            hideHistory.Visibility = Visibility.Hidden;

            ActinoidLabel.Visibility = Visibility.Hidden;
            LanthanoidLabel.Visibility = Visibility.Visible;

            // ランタノイド系のボタンを非活性にする（誤押下を防ぐため）
            btnLanthanoid.IsEnabled = false;
            btnActinoid.IsEnabled = true;

            // 周期表のアクチノイドとランタノイドの表示非表示を設定
            btnLanthanum.Visibility = Visibility.Visible;
            btnCerium.Visibility = Visibility.Visible;
            btnPraseodymium.Visibility = Visibility.Visible;
            btnNeodymium.Visibility = Visibility.Visible;
            btnPromethium.Visibility = Visibility.Visible;
            btnSamarium.Visibility = Visibility.Visible;
            btnEuropium.Visibility = Visibility.Visible;
            btnGadolinium.Visibility = Visibility.Visible;
            btnTerbium.Visibility = Visibility.Visible;
            btnDysprosium.Visibility = Visibility.Visible;
            btnHolmium.Visibility = Visibility.Visible;
            btnErbium.Visibility = Visibility.Visible;
            btnThulium.Visibility = Visibility.Visible;
            btnYtterbium.Visibility = Visibility.Visible;
            btnLutetium.Visibility = Visibility.Visible;

            btnActinium.Visibility = Visibility.Hidden;
            btnThorium.Visibility = Visibility.Hidden;
            btnProtactinium.Visibility = Visibility.Hidden;
            btnUranium.Visibility = Visibility.Hidden;
            btnNeptunium.Visibility = Visibility.Hidden;
            btnPlutonium.Visibility = Visibility.Hidden;
            btnAmericium.Visibility = Visibility.Hidden;
            btnCurium.Visibility = Visibility.Hidden;
            btnBerkelium.Visibility = Visibility.Hidden;
            btnCalifornium.Visibility = Visibility.Hidden;
            btnEinsteinium.Visibility = Visibility.Hidden;
            btnFermium.Visibility = Visibility.Hidden;
            btnMendelevium.Visibility = Visibility.Hidden;
            btnNobelium.Visibility = Visibility.Hidden;
            btnLawrencium.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// 画面拡大ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showPeriodicTable_Click(object sender, RoutedEventArgs e)
        {
            if(this.Width == 1150)
            {
                this.shownPeriodicTable.Visibility = Visibility.Hidden;
                this.hidePeriodicTable.Visibility = Visibility.Visible;
                PeriodicGrid.Visibility = Visibility.Visible;
                historyGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Width = 1150;
                this.shownPeriodicTable.Visibility = Visibility.Hidden;
                this.hidePeriodicTable.Visibility = Visibility.Visible;
                PeriodicGrid.Visibility = Visibility.Visible;
                historyGrid.Visibility = Visibility.Hidden;
            }

            // 周期表表示ボタンがクリックされた状態のままになってしまうため、クリックしていない状態のオレンジボタンにする
            if (this.hideHistory.Visibility == Visibility.Visible)
            {
                this.shownHistory.Visibility = Visibility.Visible;
                this.hideHistory.Visibility = Visibility.Hidden;
            }

        }

        /// <summary>
        /// 画面縮小ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hidePeriodicTable_Click(object sender, RoutedEventArgs e)
        {
            if (this.Width == 500)
            {
                this.shownPeriodicTable.Visibility = Visibility.Visible;
                this.hidePeriodicTable.Visibility = Visibility.Hidden;
                PeriodicGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Width = 500;
                this.shownPeriodicTable.Visibility = Visibility.Visible;
                this.hidePeriodicTable.Visibility = Visibility.Hidden;
                PeriodicGrid.Visibility = Visibility.Hidden;
            }

        }

        /// <summary>
        /// 計算履歴表示ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shownHistory_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 1150;
            this.shownHistory.Visibility = Visibility.Hidden;
            this.hideHistory.Visibility = Visibility.Visible;
            historyGrid.Visibility = Visibility.Visible;
            PeriodicGrid.Visibility = Visibility.Hidden;

            // 周期表表示ボタンがクリックされた状態のままになってしまうため、クリックしていない状態のオレンジボタンにする
            if (this.hidePeriodicTable.Visibility == Visibility.Visible)
            {
                this.shownPeriodicTable.Visibility = Visibility.Visible;
                this.hidePeriodicTable.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// 計算履歴非表示ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hideHistory_Click(object sender, RoutedEventArgs e)
        {
            this.Width = 500;
            this.shownHistory.Visibility = Visibility.Visible;
            this.hideHistory.Visibility = Visibility.Hidden;
            PeriodicGrid.Visibility = Visibility.Visible;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "0";
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "8";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += "9";
        }

        private void period_Click(object sender, RoutedEventArgs e)
        {
            // 解のテキストボックスにデータが入っている状態でクリックされたら、数式と解を削除する。
            if (resultText.Text != "")
            {
                newInput();
            }

            formulaText.Text += ".";
        }

        private void exponential_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// イコールクリック後に新しく数式を入力する
        /// </summary>
        private void newInput()
        {
            formulaText.Text = "";
            resultText.Text = "";
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

        /// <summary>
        /// =ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void equal_Click(object sender, RoutedEventArgs e)
        {
            // 画面上のdataGridを編集可能にする
            calculationHistoryGrid.IsReadOnly = false;

            // 計算式テキストボックスに×÷が入っているかを判断
            string formulaString = formulaText.Text;

            if (formulaString != "")
            {
                // 計算式に入っている掛け算割り算記号をC#で使用できるものに置換
                if (formulaString.Contains("×"))
                {
                    formulaString = formulaString.Replace("×", "*");
                }

                if (formulaString.Contains("÷"))
                {
                    formulaString = formulaString.Replace("÷", "/");
                }

                // 立方根以上の値をC#で使用できるものに置換
                if (formulaString.Contains("]√"))
                {
                    // 正規表現でキャッチしたい文字列パターン（被開平方数）
                    var pattern1 = @"√\((.*)?\)";

                    // 正規表現でキャッチしたい文字列パターン（指数）
                    var pattern2 = @"\[(.*)\]√";

                    // 立方根以上の部分を取得
                    var pattern3 = @"\[(.*?)\]√\((.*?)\)";

                    // 被開平方数をC#で扱えるものに置換して式に戻す
                    // まずは被開平方数を正規表現を使用して取得する
                    var redicandArray = Regex.Matches(formulaString, pattern3);
                    
                    // 複数マッチした場合
                    for (var i = 0; i <= redicandArray.Count - 1; i++)
                    {
                        // マッチしている立方根以上の値の被開平方数を取得（1行目の処理ではルートも含むすべてを取得）
                        var openSquareNumber = Regex.Match(redicandArray[i].Value, pattern1);
                        double openSquareNumberValue = double.Parse(Regex.Match(openSquareNumber.Value, "[0-9]+").Value);

                        // マッチしている立方根以上の値の指数を取得
                        var squareNumber = Regex.Match(redicandArray[i].Value, pattern2);
                        double squareNumberValue = double.Parse(Regex.Match(squareNumber.Value, "[0-9]+").Value);

                        // マッチしている立方根以上の値をC#で扱えるものに置換して計算する
                        double newSquareNumber = Math.Pow(openSquareNumberValue, 1/squareNumberValue);

                        formulaString = formulaString.Replace(redicandArray[i].Value, newSquareNumber.ToString());
                    }
                }

                // 常用対数の値をC#で使用できるものに置換
                if (formulaString.Contains("log10"))
                {
                    // 正規表現で常用対数の値を取得する
                    var pattern1 = @"log10\(.*\)";

                    var commonLogarithms = Regex.Matches(formulaString, pattern1);

                    for (var i = 0; i <= commonLogarithms.Count -1; i++)
                    {
                        string matchesString = commonLogarithms[i].Value;

                        // かっこの中の値を取得する
                        // 正規表現でかっこの中の値をマッチ
                        // まずはかっこの始端から終端までを取得
                        var parenthesesPattern = @"\(.*?\)";

                        // 正規表現を用いて、検索対象の文字列の真数を検索する
                        var trueNumber = Regex.Match(matchesString, parenthesesPattern);

                        // 上記処理で取得した真数をC#の常用対数関数に渡して計算を行う。
                        double newCommonLogarithm = Math.Log10(double.Parse(trueNumber.Value));

                    }
                }

                // 置換処理を経た計算式はすべて文字列となってしまうため、DataTable内で計算させて返す
                System.Data.DataTable dt = new System.Data.DataTable();
                string s = dt.Compute(formulaString, "").ToString();

                // 上記の置換処理を経た計算を実行する
                string result = s;

                resultText.Text = result;

                // dataGridに表示するDataTableを作成する
                DataTable newDataTable = new DataTable();

                // DataTableに列を追加
                newDataTable.Columns.Add("formula", typeof(string));
                newDataTable.Columns.Add("result", typeof(string));

                if (calculationHistoryGrid.Items.Count > 1)
                {
                    foreach (DataRowView item in calculationHistoryGrid.ItemsSource)
                    {
                        // 画面上のdataGridからデータを取得する
                        DataGridRow row = new DataGridRow();
                        row.DataContext = item;

                        newDataTable.Rows.Add(item.Row.ItemArray[0], item.Row.ItemArray[1]);
                    }
                }

                DataRow newData = newDataTable.NewRow();
                newData["formula"] = formulaText.Text;
                newData["result"] = result;

                newDataTable.Rows.Add(newData);

                // DataGridにバインドされているDataTableを再設定する
                calculationHistoryGrid.ItemsSource = newDataTable.DefaultView;

            }
            else
            {
                MessageBox.Show("計算式を入力してください。");
            }

            // 画面上のdataGridを編集不可にする
            calculationHistoryGrid.IsReadOnly = true;
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

            // カレットの位置を取得
            int selectPos = formulaText.SelectionStart;

            // 式のテキストボックスに入力されている文字列
            string formulaString = formulaText.Text;

            // テンキー押下時処理追加
            // 文字の場合は無視
            if (pressKey == "D0" || pressKey == "NumPad0")
            {
                formulaString = formulaString.Insert(selectPos, "0");
            }
            else if (pressKey == "D1" || pressKey == "NumPad1")
            {
                formulaString = formulaString.Insert(selectPos, "1");
            }
            else if (pressKey == "D2" || pressKey == "NumPad2")
            {
                formulaString = formulaString.Insert(selectPos, "2");
            }
            else if (pressKey == "D3" || pressKey == "NumPad3")
            {
                formulaString = formulaString.Insert(selectPos, "3");
            }
            else if (pressKey == "D4" || pressKey == "NumPad4")
            {
                formulaString = formulaString.Insert(selectPos, "4");
            }
            else if (pressKey == "D5" || pressKey == "NumPad5")
            {
                formulaString = formulaString.Insert(selectPos, "5");
            }
            else if (pressKey == "D6" || pressKey == "NumPad6")
            {
                formulaString = formulaString.Insert(selectPos, "6");
            }
            else if (pressKey == "D7" || pressKey == "NumPad7")
            {
                formulaString = formulaString.Insert(selectPos, "7");
            }
            else if (pressKey == "D8" || pressKey == "NumPad8")
            {
                formulaString = formulaString.Insert(selectPos, "8");
            }
            else if (pressKey == "D9" || pressKey == "NumPad9")
            {
                formulaString = formulaString.Insert(selectPos, "9");
            }
            else if (pressKey == "Add")
            {
                formulaString = formulaString.Insert(selectPos, "+");
            }
            else if (pressKey == "Subtract")
            {
                formulaString = formulaString.Insert(selectPos, "-");
            }
            else if (pressKey == "Multiply")
            {
                formulaString = formulaString.Insert(selectPos, "×");
            }
            else if (pressKey == "Divide")
            {
                formulaString = formulaString.Insert(selectPos, "÷");
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
            formulaText.Text = formulaString;

            // keyDownイベントを伝播せずテキスト入力を行う（キーボード入力時2重入力を防ぐ）
            e.Handled = true;
        }

        /// <summary>
        /// ランタノイド系表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLanthanoid_Click(object sender, RoutedEventArgs e)
        {
            ActinoidLabel.Visibility = Visibility.Hidden;
            LanthanoidLabel.Visibility = Visibility.Visible;

            // ランタノイド系のボタンを非活性にする（誤押下を防ぐため）
            btnLanthanoid.IsEnabled = false;
            btnActinoid.IsEnabled = true;

            btnLanthanum.Visibility = Visibility.Visible;
            btnCerium.Visibility = Visibility.Visible;
            btnPraseodymium.Visibility = Visibility.Visible;
            btnNeodymium.Visibility = Visibility.Visible;
            btnPromethium.Visibility = Visibility.Visible;
            btnSamarium.Visibility = Visibility.Visible;
            btnEuropium.Visibility = Visibility.Visible;
            btnGadolinium.Visibility = Visibility.Visible;
            btnTerbium.Visibility = Visibility.Visible;
            btnDysprosium.Visibility = Visibility.Visible;
            btnHolmium.Visibility = Visibility.Visible;
            btnErbium.Visibility = Visibility.Visible;
            btnThulium.Visibility = Visibility.Visible;
            btnYtterbium.Visibility = Visibility.Visible;
            btnLutetium.Visibility = Visibility.Visible;

            btnActinium.Visibility = Visibility.Hidden;
            btnThorium.Visibility = Visibility.Hidden;
            btnProtactinium.Visibility = Visibility.Hidden;
            btnUranium.Visibility = Visibility.Hidden;
            btnNeptunium.Visibility = Visibility.Hidden;
            btnPlutonium.Visibility = Visibility.Hidden;
            btnAmericium.Visibility = Visibility.Hidden;
            btnCurium.Visibility = Visibility.Hidden;
            btnBerkelium.Visibility = Visibility.Hidden;
            btnCalifornium.Visibility = Visibility.Hidden;
            btnEinsteinium.Visibility = Visibility.Hidden;
            btnFermium.Visibility = Visibility.Hidden;
            btnMendelevium.Visibility = Visibility.Hidden;
            btnNobelium.Visibility = Visibility.Hidden;
            btnLawrencium.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// アクチノイド系表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActinoid_Click(object sender, RoutedEventArgs e)
        {
            LanthanoidLabel.Visibility = Visibility.Hidden;
            ActinoidLabel.Visibility = Visibility.Visible;

            // アクチノイド系のボタンを非活性にする（誤押下を防ぐため）
            btnLanthanoid.IsEnabled = true;
            btnActinoid.IsEnabled = false;

            btnLanthanum.Visibility = Visibility.Hidden;
            btnCerium.Visibility = Visibility.Hidden;
            btnPraseodymium.Visibility = Visibility.Hidden;
            btnNeodymium.Visibility = Visibility.Hidden;
            btnPromethium.Visibility = Visibility.Hidden;
            btnSamarium.Visibility = Visibility.Hidden;
            btnEuropium.Visibility = Visibility.Hidden;
            btnGadolinium.Visibility = Visibility.Hidden;
            btnTerbium.Visibility = Visibility.Hidden;
            btnDysprosium.Visibility = Visibility.Hidden;
            btnHolmium.Visibility = Visibility.Hidden;
            btnErbium.Visibility = Visibility.Hidden;
            btnThulium.Visibility = Visibility.Hidden;
            btnYtterbium.Visibility = Visibility.Hidden;
            btnLutetium.Visibility = Visibility.Hidden;

            btnActinium.Visibility = Visibility.Visible;
            btnThorium.Visibility = Visibility.Visible;
            btnProtactinium.Visibility = Visibility.Visible;
            btnUranium.Visibility = Visibility.Visible;
            btnNeptunium.Visibility = Visibility.Visible;
            btnPlutonium.Visibility = Visibility.Visible;
            btnAmericium.Visibility = Visibility.Visible;
            btnCurium.Visibility = Visibility.Visible;
            btnBerkelium.Visibility = Visibility.Visible;
            btnCalifornium.Visibility = Visibility.Visible;
            btnEinsteinium.Visibility = Visibility.Visible;
            btnFermium.Visibility = Visibility.Visible;
            btnMendelevium.Visibility = Visibility.Visible;
            btnNobelium.Visibility = Visibility.Visible;
            btnLawrencium.Visibility = Visibility.Visible;
        }

        private void clickOfAtom(object sender, RoutedEventArgs e)
        {
            // どのボタンが押されたかを取得
            Button button = (Button)sender;

            // 現在クリックされたボタンがすでに押下されていないかを確認する
            string[] atoms = new string[9];

            // 現在すでにクリックされている原子の記号を取得
            if (nameInMoleculesAtom1.Content != null)
            {
                atoms[0] = nameInMoleculesAtom1.Content.ToString();

                if (nameInMoleculesAtom2.Content != null)
                {
                    atoms[1] = nameInMoleculesAtom2.Content.ToString();

                    if (nameInMoleculesAtom3.Content != null)
                    {
                        atoms[2] = nameInMoleculesAtom3.Content.ToString();

                        if (nameInMoleculesAtom4.Content != null)
                        {
                            atoms[3] = nameInMoleculesAtom4.Content.ToString();

                            if (nameInMoleculesAtom5.Content != null)
                            {
                                atoms[4] = nameInMoleculesAtom5.Content.ToString();

                                if (nameInMoleculesAtom6.Content != null)
                                {
                                    atoms[5] = nameInMoleculesAtom6.Content.ToString();

                                    if (nameInMoleculesAtom7.Content != null)
                                    {
                                        atoms[6] = nameInMoleculesAtom7.Content.ToString();

                                        if (nameInMoleculesAtom8.Content != null)
                                        {
                                            atoms[7] = nameInMoleculesAtom8.Content.ToString();

                                            if (nameInMoleculesAtom9.Content != null)
                                            {
                                                atoms[8] = nameInMoleculesAtom9.Content.ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // 検索したいボタンの文字列
            string buttonString = button.Content.ToString();

            // 配列に押したボタンのテキストが含まれているか確認
            int indexOfArray = Array.IndexOf(atoms, buttonString);

            if (indexOfArray >= 0)
            {
                if (indexOfArray == 0)
                {
                    int count = int.Parse(valueInMoleculesAtom1.Text);
                    count = count + 1;
                    valueInMoleculesAtom1.Text = count.ToString();
                }
                else if (indexOfArray == 1)
                {
                    int count = int.Parse(valueInMoleculesAtom2.Text);
                    count = count + 1;
                    valueInMoleculesAtom2.Text = count.ToString();
                }
                else if (indexOfArray == 2)
                {
                    int count = int.Parse(valueInMoleculesAtom3.Text);
                    count = count + 1;
                    valueInMoleculesAtom3.Text = count.ToString();
                }
                else if (indexOfArray == 3)
                {
                    int count = int.Parse(valueInMoleculesAtom4.Text);
                    count = count + 1;
                    valueInMoleculesAtom4.Text = count.ToString();
                }
                else if (indexOfArray == 4)
                {
                    int count = int.Parse(valueInMoleculesAtom5.Text);
                    count = count + 1;
                    valueInMoleculesAtom5.Text = count.ToString();
                }
                else if (indexOfArray == 5)
                {
                    int count = int.Parse(valueInMoleculesAtom6.Text);
                    count = count + 1;
                    valueInMoleculesAtom6.Text = count.ToString();
                }
                else if (indexOfArray == 6)
                {
                    int count = int.Parse(valueInMoleculesAtom7.Text);
                    count = count + 1;
                    valueInMoleculesAtom7.Text = count.ToString();
                }
                else if (indexOfArray == 7)
                {
                    int count = int.Parse(valueInMoleculesAtom8.Text);
                    count = count + 1;
                    valueInMoleculesAtom8.Text = count.ToString();
                }
                else if (indexOfArray == 8)
                {
                    int count = int.Parse(valueInMoleculesAtom9.Text);
                    count = count + 1;
                    valueInMoleculesAtom9.Text = count.ToString();
                }
            }
            else
            {
                if(atoms[0] == null)
                {
                    nameInMoleculesAtom1.Content = buttonString;
                    valueInMoleculesAtom1.Text = "1";
                }
                else if (atoms[1] == null)
                {
                    nameInMoleculesAtom2.Content = buttonString;
                    valueInMoleculesAtom2.Text = "1";
                }
                else if (atoms[2] == null)
                {
                    nameInMoleculesAtom3.Content = buttonString;
                    valueInMoleculesAtom3.Text = "1";
                }
                else if (atoms[3] == null)
                {
                    nameInMoleculesAtom4.Content = buttonString;
                    valueInMoleculesAtom4.Text = "1";
                }
                else if (atoms[4] == null)
                {
                    nameInMoleculesAtom5.Content = buttonString;
                    valueInMoleculesAtom5.Text = "1";
                }
                else if (atoms[5] == null)
                {
                    nameInMoleculesAtom6.Content = buttonString;
                    valueInMoleculesAtom6.Text = "1";
                }
                else if (atoms[6] == null)
                {
                    nameInMoleculesAtom7.Content = buttonString;
                    valueInMoleculesAtom7.Text = "1";
                }
                else if (atoms[7] == null)
                {
                    nameInMoleculesAtom8.Content = buttonString;
                    valueInMoleculesAtom8.Text = "1";
                }
                else if (atoms[8] == null)
                {
                    nameInMoleculesAtom9.Content = buttonString;
                    valueInMoleculesAtom9.Text = "1";
                }
                else
                {
                    MessageBox.Show("入力できる原子は9つまでです。");
                }
            }

            var connectionString = "Data Source=calc.sqlite3";
            decimal atomicMass = 0;

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                var sql = "select * from m_atom where element_symbol = @symbol";

                using (var cmd = new SQLiteCommand(connectionString))
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SQLiteParameter("symbol",buttonString));

                    var result = cmd.ExecuteNonQuery();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            atomicMass += Decimal.Parse(reader["atomic_mass"].ToString());
                            
                            // defaultで読み取り専用のため書き込み可に変更
                            totalAtomicMassText.IsReadOnly = false;

                            if (totalAtomicMassText.Text != "")
                            {
                                totalAtomicMassText.Text = (decimal.Parse(totalAtomicMassText.Text) + atomicMass).ToString();
                            }
                            else
                            {
                                totalAtomicMassText.Text = atomicMass.ToString();
                            }

                            totalAtomicMassText.IsReadOnly = true;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// 積算した分子量をコピーする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyAtomicMass_Click(object sender, RoutedEventArgs e)
        {
            if (totalAtomicMassText.Text != "")
            {
                // 積算した分子量をコピー
                Clipboard.SetDataObject(totalAtomicMassText.Text, true);
                MessageBox.Show("分子量をコピーしました。");
            }
            else
            {
                MessageBox.Show("積算する元素を選択してください。");
            }
        }

        /// <summary>
        /// 積算した分子量を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAtomicMass_Click(object sender, RoutedEventArgs e)
        {
            nameInMoleculesAtom1.Content = null;
            nameInMoleculesAtom2.Content = null;
            nameInMoleculesAtom3.Content = null;
            nameInMoleculesAtom4.Content = null;
            nameInMoleculesAtom5.Content = null;
            nameInMoleculesAtom6.Content = null;
            nameInMoleculesAtom7.Content = null;
            nameInMoleculesAtom8.Content = null;
            nameInMoleculesAtom9.Content = null;

            valueInMoleculesAtom1.Text = string.Empty;
            valueInMoleculesAtom2.Text = string.Empty;
            valueInMoleculesAtom3.Text = string.Empty;
            valueInMoleculesAtom4.Text = string.Empty;
            valueInMoleculesAtom5.Text = string.Empty;
            valueInMoleculesAtom6.Text = string.Empty;
            valueInMoleculesAtom7.Text = string.Empty;
            valueInMoleculesAtom8.Text = string.Empty;
            valueInMoleculesAtom9.Text = string.Empty;

            totalAtomicMassText.Text = string.Empty;

        }

        /// <summary>
        /// 常用対数ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonLogarithm_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "log10()";
        }

        /// <summary>
        /// 自然対数ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void naturalLogarithm_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "loge()";
        }

        private void sin_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "sin()";
        }

        private void cos_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "cos()";
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "tan()";
        }

        private void root_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "[]√()";
        }

        private void squareRoot_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "√()";
        }

        private void negativeSign_Click(object sender, RoutedEventArgs e)
        {
            formulaText.Text += "-";
        }

        /// <summary>
        /// 計算履歴グリッドの行をダブルクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculationHistoryGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView selectedItem = (DataRowView)((MultiSelector)sender).SelectedItems[0];

            formulaText.Text = selectedItem.Row.ItemArray[0].ToString();
            resultText.Text = selectedItem.Row.ItemArray[1].ToString();
        }

        /// <summary>
        /// 文字盤のスタイル編集画面オープン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStyle_Click(object sender, RoutedEventArgs e)
        {
            var buttonStyleScreen = new buttonStyle.buttonStyle(this);
            buttonStyleScreen.Show();
        }

        /// <summary>
        /// 画面上の言語編集画面オープン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void language_Click(object sender, RoutedEventArgs e)
        {
            // 言語選択画面のインスタンスを作成
            language.language languageScreen = new language.language(this);

            languageScreen.Show();
        }

        /// <summary>
        /// 言語選択時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            changeLanguage changeLanguage = new changeLanguage();
            string nowLanguage = changeLanguage.GetLanguage();

            changeLanguage.ChangeLanguage(this);
        }

        /// <summary>
        /// 周期表上のボタンを右クリックした際のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // どのボタンが押されたかを取得
            Button button = (Button)sender;

            // 検索したいボタンの文字列
            string buttonString = button.Content.ToString();

            ElementDetail elementDetail = new ElementDetail(buttonString);
            elementDetail.Show();
        }
    }
}
