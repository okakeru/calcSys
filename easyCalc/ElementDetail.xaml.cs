using easyCalc.other;
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

namespace easyCalc
{
    /// <summary>
    /// ElementDetail.xaml の相互作用ロジック
    /// </summary>
    public partial class ElementDetail : Window
    {
        /// <summary>
        /// 元素詳細小画面
        /// </summary>
        /// <param name="element_symbol">元素記号</param>
        public ElementDetail(string element_symbol)
        {
            InitializeComponent();

            string selectedLanguage = "";

            changeLanguage changeLanguage = new changeLanguage();

            selectedLanguage = changeLanguage.GetLanguage();

            // システム側で選択している言語によって表示を変える
            if (selectedLanguage == "japanese")
            {
                Title = "元素詳細";
            }
            else
            {
                Title = "ElementDetails";
            }

            // mainWindowで選択した元素記号でDBを検索して情報を取得
            string[] selectedElement = new string[5];
            selectedElement = getElement(element_symbol);

            // 画面上のコントロールにDBから取得した値を表示
            atomicNumber.IsReadOnly = false;
            atomicSymbol.IsReadOnly = false;
            atomicName.IsReadOnly = false;
            RelativeAtomicMass.IsReadOnly = false;

            atomicNumber.Text = selectedElement[0].ToString();
            atomicSymbol.Text = selectedElement[1].ToString();

            if(selectedLanguage == "japanese")
            {
                atomicName.Text = selectedElement[2].ToString();
            }
            else
            {
                atomicName.Text = selectedElement[3].ToString();
            }
            
            RelativeAtomicMass.Text = selectedElement[4].ToString();

            // 再度読み取り専用に戻す
            atomicNumber.IsReadOnly = true;
            atomicSymbol.IsReadOnly = true;
            atomicName.IsReadOnly = true;
            RelativeAtomicMass.IsReadOnly = true;

        }

        public string[] getElement(string atomicSign)
        {
            var connectionString = "Data Source=calc.sqlite3";
            decimal atomicMass = 0;

            string[] retStrings = new string[5];

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                var sql = "select * from m_atom where element_symbol = @symbol";

                using (var cmd = new SQLiteCommand(connectionString))
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SQLiteParameter("symbol", atomicSign));

                    var result = cmd.ExecuteNonQuery();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            // 原子番号
                            retStrings[0] = reader["atomic_number"].ToString();

                            // 元素記号
                            retStrings[1] = reader["element_symbol"].ToString();

                            // 元素名日本語
                            retStrings[2] = reader["element_name_jp"].ToString();

                            // 元素名英語
                            retStrings[3] = reader["element_name_en"].ToString();

                            // 原子量
                            retStrings[4] = reader["atomic_mass"].ToString();

                        }
                    }
                }
            }

            return retStrings;

        }
    }
}
