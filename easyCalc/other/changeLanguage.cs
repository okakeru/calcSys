using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCalc.other
{
    class changeLanguage
    {
        /// <summary>
        /// DBから今指定されている言語を取得する処理
        /// </summary>
        /// <returns></returns>
        public string GetLanguage()
        {
            // DBから取得した言語（日本語or英語）
            string retLanguage = "";

            // アクセスするsqliteを指定
            var connectionString = "Data Source=calc.sqlite3";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                var sql = "select setting_value from m_setting where setting_name = 'language'";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    retLanguage = (string)reader["setting_value"];
                }
            }

            return retLanguage;

        }

        /// <summary>
        /// 言語選択後にMainWindowを開いた際の言語変換
        /// </summary>
        public void ChangeLanguage(MainWindow mainWindow)
        {
            // 今の言語を取得する
            string language = GetLanguage();

            if (language == "japanese")
            {
                mainWindow.fileMenu.Header = "ファイル";
                mainWindow.fileOpen.Header = "ファイルを開く";
                mainWindow.fileSave.Header = "ファイルを保存";

                mainWindow.buttonStyleMenu.Header = "ボタンスタイル";

                mainWindow.languageMenu.Header = "言語選択";

                mainWindow.formula.Content = "計算式";
                mainWindow.result.Content = "解";
            }
            else if (language == "english")
            {
                mainWindow.fileMenu.Header = "file";
                mainWindow.fileOpen.Header = "open";
                mainWindow.fileSave.Header = "save";

                mainWindow.buttonStyleMenu.Header = "buttonStyle";

                mainWindow.languageMenu.Header = "language";

                mainWindow.formula.Content = "formula";
                mainWindow.result.Content = "result";
            }
        }
    }
}
