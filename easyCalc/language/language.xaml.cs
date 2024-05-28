using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using easyCalc.other;

namespace easyCalc.language
{
    /// <summary>
    /// language.xaml の相互作用ロジック
    /// </summary>
    public partial class language : Window
    {
        public MainWindow mainWindow;

        public language(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            string selectedLanguage = "";

            changeLanguage changeLanguage = new changeLanguage();

            selectedLanguage = changeLanguage.GetLanguage();

            if (selectedLanguage == "japanese")
            {
                selectLanguage.SelectedIndex = 0;

                Title = "言語切替";
                mainText.Content = "言語を選んでください。";
                select.Content = "選択";
            }
            else
            {
                selectLanguage.SelectedIndex = 1;

                Title = "language";
                mainText.Content = "Please select a language.";
                select.Content = "decision";
            }

            mainWindow.Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// 決定ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void select_Click(object sender, RoutedEventArgs e)
        {
            // 切替拒否時の選択
            DialogResult changeResult = new DialogResult();

            // 言語切替時のメッセージを発行
            // 本当に切り替えてよいかを問う
            if (selectLanguage.SelectedIndex == 0)
            {
                changeResult = MessageBox.Show("言語を日本語に切り替えて本当によろしいですか？","言語切替",MessageBoxButtons.OKCancel);
            }
            else if (selectLanguage.SelectedIndex == 1)
            {
                changeResult = MessageBox.Show("Are you certain you wish to switch the language to English?", "Language Switch", MessageBoxButtons.OKCancel);
            }

            // 切替拒否時に切替処理を終了する
            if (changeResult == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // アクセスするsqliteを指定
            var connectionString = "Data Source=calc.sqlite3";

            string updateSQL = "";

            // ドロップダウンリストの選択によって発行するSQLを切り分ける
            if (selectLanguage.SelectedIndex == 0)
            {
                // 更新用sqlを用意
                updateSQL = "update m_setting set setting_value = 'japanese' where setting_name = 'language';";
            }
            else if (selectLanguage.SelectedIndex == 1)
            {
                // 更新用sqlを用意
                updateSQL = "update m_setting set setting_value = 'english' where setting_name = 'language';";
            }

            // sql発行準備
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = updateSQL;
                    var result = command.ExecuteNonQuery();
                }
            }

            // 言語切替が正常に終了したことを伝えるメッセージ
            if (selectLanguage.SelectedIndex == 0)
            {
                MessageBox.Show("言語を日本語に切り替えました。");

                // コントロールに記載されている文字列を書き換え
                Title = "言語切替";
                mainText.Content = "言語を選んでください。";
                select.Content = "選択";

            }
            else if (selectLanguage.SelectedIndex == 1)
            {
                MessageBox.Show("The language has been switched to English.");

                // コントロールに記載されている文字列を書き換え
                Title = "language";
                mainText.Content = "Please select a language.";
                select.Content = "decision";

            }
        }

        /// <summary>
        /// 画面を閉じる際の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
        }
    }
}
