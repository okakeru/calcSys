﻿using System;
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

            // 立方根以上の値をC#で使用できるものに置換
            if (formulaString.Contains("]√"))
            {
                // 正規表現でキャッチしたい文字列パターン（被開平方数）
                var pattern1 = @"√\((.*)?\)";

                // 正規表現でキャッチしたい文字列パターン（指数）
                var pattern2 = @"\[(.*)\]√";

                Regex deletePattern = new Regex(@"\[.+\]");

                // 被開平方数をC#で扱えるものに置換して式に戻す
                // まずは被開平方数を正規表現を使用して取得する
                var radicand = double.Parse(Regex.Match(formulaString, pattern1).Groups[1].Value);

                // 指数をC#で扱えるものに置換して式に戻す
                var exponent = 1 / double.Parse(Regex.Match(formulaString, pattern2).Groups[1].Value);

                var sqrtResult = Math.Pow(radicand, exponent);

                formulaString = deletePattern.Replace(formulaString,"");
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

        /// <summary>
        /// ランタノイド系表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLanthanoid_Click(object sender, RoutedEventArgs e)
        {
            // アクチノイド系が表示状態であれば非表示にする
            if (ActinoidLabel.IsVisible)
            {
                ActinoidLabel.Visibility = Visibility.Hidden;
                LanthanoidLabel.Visibility = Visibility.Visible;

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
            else
            {
                MessageBox.Show("Lanthanoids are already shown.");
            }
        }

        /// <summary>
        /// アクチノイド系表示ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActinoid_Click(object sender, RoutedEventArgs e)
        {
            // ランタノイド系が表示状態であれば非表示にする
            if (LanthanoidLabel.IsVisible)
            {
                LanthanoidLabel.Visibility = Visibility.Hidden;
                ActinoidLabel.Visibility = Visibility.Visible;

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
            else
            {
                MessageBox.Show("Actinoids are already shown.");
            }
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
        /// ルートボタンにカーソルを載せた時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void root_MouseEnter(object sender, MouseEventArgs e)
        {
            rootImage.Source = new BitmapImage(new Uri("picture/mouseOverOfRoot.png", UriKind.Relative));
        }

        /// <summary>
        /// ルートボタンからカーソルを離した時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void root_MouseLeave(object sender, MouseEventArgs e)
        {
            rootImage.Source = new BitmapImage(new Uri("picture/root.png", UriKind.Relative));
        }
    }
}
