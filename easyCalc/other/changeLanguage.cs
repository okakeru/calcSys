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
    }
}
