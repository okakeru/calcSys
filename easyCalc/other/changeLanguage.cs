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
        /// DBから原子番号と元素名を一覧で取得
        /// </summary>
        public List<string[]> GetElements()
        {
            // DBから取得した元素
            string[] elementData = new string[3];

            // DBから取得した元素一覧
            List<string[]> elements = new List<string[]>();

            // アクセスするsqliteを指定
            var connectionString = "Data Source=calc.sqlite3";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                var sql = "select atomic_number,element_name_jp,element_name_en from m_atom";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    elementData = new string[3];
                    elementData[0] = reader["atomic_number"].ToString();
                    elementData[1] = reader["element_name_jp"].ToString();
                    elementData[2] = reader["element_name_en"].ToString();
                    elements.Add(elementData);
                }
            }

            return elements;
        }

        /// <summary>
        /// 言語選択後にMainWindowを開いた際の言語変換
        /// </summary>
        public void ChangeLanguage(MainWindow mainWindow)
        {
            // 今の言語を取得する
            string language = GetLanguage();

            // 日本語、英語両方の原子番号および元素名を取得
            List<string[]> elements = GetElements();

            if (language == "japanese")
            {
                mainWindow.fileMenu.Header = "ファイル";
                mainWindow.fileOpen.Header = "ファイルを開く";
                mainWindow.fileSave.Header = "ファイルを保存";

                mainWindow.buttonStyleMenu.Header = "ボタンスタイル";

                mainWindow.languageMenu.Header = "言語選択";

                mainWindow.formula.Content = "計算式";
                mainWindow.result.Content = "解";

                mainWindow.periodicTable.Text = "周期表";
                mainWindow.TotalAtomicMass.Text = "分子量";

                mainWindow.LanthanoidLabel.Content = "ランタノイド系";
                mainWindow.ActinoidLabel.Content = "アクチノイド系";

                mainWindow.btnLanthanoid.ToolTip = "ランタノイド系";
                mainWindow.btnActinoid.ToolTip = "アクチノイド系";

                mainWindow.btnHydrogen.ToolTip = elements[0][0].ToString() + "：" + elements[0][1].ToString();
                mainWindow.btnHelium.ToolTip = elements[1][0].ToString() + "：" + elements[1][1].ToString();
                mainWindow.btnLithium.ToolTip = elements[2][0].ToString() + "：" + elements[2][1].ToString();
                mainWindow.btnBeryllium.ToolTip = elements[3][0].ToString() + "：" + elements[3][1].ToString();
                mainWindow.btnBoron.ToolTip = elements[4][0].ToString() + "：" + elements[4][1].ToString();
                mainWindow.btnCarbon.ToolTip = elements[5][0].ToString() + "：" + elements[5][1].ToString();
                mainWindow.btnNitrogen.ToolTip = elements[6][0].ToString() + "：" + elements[6][1].ToString();
                mainWindow.btnOxygen.ToolTip = elements[7][0].ToString() + "：" + elements[7][1].ToString();
                mainWindow.btnFluorine.ToolTip = elements[8][0].ToString() + "：" + elements[8][1].ToString();
                mainWindow.btnNeon.ToolTip = elements[9][0].ToString() + "：" + elements[9][1].ToString();
                mainWindow.btnSodium.ToolTip = elements[10][0].ToString() + ":" + elements[10][1].ToString();
                mainWindow.btnMagnesium.ToolTip = elements[11][0].ToString() + ":" + elements[11][1].ToString();
                mainWindow.btnAluminium.ToolTip = elements[12][0].ToString() + ":" + elements[12][1].ToString();
                mainWindow.btnSilicon.ToolTip = elements[13][0].ToString() + ":" + elements[13][1].ToString();
                mainWindow.btnPhosphorus.ToolTip = elements[14][0].ToString() + ":" + elements[14][1].ToString();
                mainWindow.btnSulfur.ToolTip = elements[15][0].ToString() + ":" + elements[15][1].ToString();
                mainWindow.btnChlorine.ToolTip = elements[16][0].ToString() + ":" + elements[16][1].ToString();
                mainWindow.btnArgon.ToolTip = elements[17][0].ToString() + ":" + elements[17][1].ToString();
                mainWindow.btnPotassium.ToolTip = elements[18][0].ToString() + ":" + elements[18][1].ToString();
                mainWindow.btnCalcium.ToolTip = elements[19][0].ToString() + ":" + elements[19][1].ToString();
                mainWindow.btnScandium.ToolTip = elements[20][0].ToString() + ":" + elements[20][1].ToString();
                mainWindow.btnTitanium.ToolTip = elements[21][0].ToString() + ":" + elements[21][1].ToString();
                mainWindow.btnVanadium.ToolTip = elements[22][0].ToString() + ":" + elements[22][1].ToString();
                mainWindow.btnChromium.ToolTip = elements[23][0].ToString() + ":" + elements[23][1].ToString();
                mainWindow.btnManganese.ToolTip = elements[24][0].ToString() + ":" + elements[24][1].ToString();
                mainWindow.btnIron.ToolTip = elements[25][0].ToString() + ":" + elements[25][1].ToString();
                mainWindow.btnCobalt.ToolTip = elements[26][0].ToString() + ":" + elements[26][1].ToString();
                mainWindow.btnNickel.ToolTip = elements[27][0].ToString() + ":" + elements[27][1].ToString();
                mainWindow.btnCopper.ToolTip = elements[28][0].ToString() + ":" + elements[28][1].ToString();
                mainWindow.btnZinc.ToolTip = elements[29][0].ToString() + ":" + elements[29][1].ToString();
                mainWindow.btnGallium.ToolTip = elements[30][0].ToString() + ":" + elements[30][1].ToString();
                mainWindow.btnGermanium.ToolTip = elements[31][0].ToString() + ":" + elements[31][1].ToString();
                mainWindow.btnArsenic.ToolTip = elements[32][0].ToString() + ":" + elements[32][1].ToString();
                mainWindow.btnSelenium.ToolTip = elements[33][0].ToString() + ":" + elements[33][1].ToString();
                mainWindow.btnBromine.ToolTip = elements[34][0].ToString() + ":" + elements[34][1].ToString();
                mainWindow.btnKrypton.ToolTip = elements[35][0].ToString() + ":" + elements[35][1].ToString();
                mainWindow.btnRubidium.ToolTip = elements[36][0].ToString() + ":" + elements[36][1].ToString();
                mainWindow.btnStrontium.ToolTip = elements[37][0].ToString() + ":" + elements[37][1].ToString();
                mainWindow.btnYttrium.ToolTip = elements[38][0].ToString() + ":" + elements[38][1].ToString();
                mainWindow.btnZirconium.ToolTip = elements[39][0].ToString() + ":" + elements[39][1].ToString();
                mainWindow.btnNiobium.ToolTip = elements[40][0].ToString() + ":" + elements[40][1].ToString();
                mainWindow.btnMolybdenum.ToolTip = elements[41][0].ToString() + ":" + elements[41][1].ToString();
                mainWindow.btnTechnetium.ToolTip = elements[42][0].ToString() + ":" + elements[42][1].ToString();
                mainWindow.btnRuthenium.ToolTip = elements[43][0].ToString() + ":" + elements[43][1].ToString();
                mainWindow.btnRhodium.ToolTip = elements[44][0].ToString() + ":" + elements[44][1].ToString();
                mainWindow.btnPalladium.ToolTip = elements[45][0].ToString() + ":" + elements[45][1].ToString();
                mainWindow.btnSilver.ToolTip = elements[46][0].ToString() + ":" + elements[46][1].ToString();
                mainWindow.btnCadmium.ToolTip = elements[47][0].ToString() + ":" + elements[47][1].ToString();
                mainWindow.btnIndium.ToolTip = elements[48][0].ToString() + ":" + elements[48][1].ToString();
                mainWindow.btnTin.ToolTip = elements[49][0].ToString() + ":" + elements[49][1].ToString();
                mainWindow.btnAntimony.ToolTip = elements[50][0].ToString() + ":" + elements[50][1].ToString();
                mainWindow.btnTellurium.ToolTip = elements[51][0].ToString() + ":" + elements[51][1].ToString();
                mainWindow.btnIodine.ToolTip = elements[52][0].ToString() + ":" + elements[52][1].ToString();
                mainWindow.btnXenon.ToolTip = elements[53][0].ToString() + ":" + elements[53][1].ToString();
                mainWindow.btnCaesium.ToolTip = elements[54][0].ToString() + ":" + elements[54][1].ToString();
                mainWindow.btnBarium.ToolTip = elements[55][0].ToString() + ":" + elements[55][1].ToString();
                mainWindow.btnHafnium.ToolTip = elements[71][0].ToString() + ":" + elements[71][1].ToString();
                mainWindow.btnTantalum.ToolTip = elements[72][0].ToString() + ":" + elements[72][1].ToString();
                mainWindow.btnTungsten.ToolTip = elements[73][0].ToString() + ":" + elements[73][1].ToString();
                mainWindow.btnRhenium.ToolTip = elements[74][0].ToString() + ":" + elements[74][1].ToString();
                mainWindow.btnOsmium.ToolTip = elements[75][0].ToString() + ":" + elements[75][1].ToString();
                mainWindow.btnIridium.ToolTip = elements[76][0].ToString() + ":" + elements[76][1].ToString();
                mainWindow.btnPlatinum.ToolTip = elements[77][0].ToString() + ":" + elements[77][1].ToString();
                mainWindow.btnGold.ToolTip = elements[78][0].ToString() + ":" + elements[78][1].ToString();
                mainWindow.btnMercury.ToolTip = elements[79][0].ToString() + ":" + elements[79][1].ToString();
                mainWindow.btnThallium.ToolTip = elements[80][0].ToString() + ":" + elements[80][1].ToString();
                mainWindow.btnLead.ToolTip = elements[81][0].ToString() + ":" + elements[81][1].ToString();
                mainWindow.btnBismuth.ToolTip = elements[82][0].ToString() + ":" + elements[82][1].ToString();
                mainWindow.btnPolonium.ToolTip = elements[83][0].ToString() + ":" + elements[83][1].ToString();
                mainWindow.btnAstatine.ToolTip = elements[84][0].ToString() + ":" + elements[84][1].ToString();
                mainWindow.btnRadon.ToolTip = elements[85][0].ToString() + ":" + elements[85][1].ToString();
                mainWindow.btnFrancium.ToolTip = elements[86][0].ToString() + ":" + elements[86][1].ToString();
                mainWindow.btnRadium.ToolTip = elements[87][0].ToString() + ":" + elements[87][1].ToString();
                mainWindow.btnRutherfordium.ToolTip = elements[103][0].ToString() + ":" + elements[103][1].ToString();
                mainWindow.btnDubnium.ToolTip = elements[104][0].ToString() + ":" + elements[104][1].ToString();
                mainWindow.btnSeaborgium.ToolTip = elements[105][0].ToString() + ":" + elements[105][1].ToString();
                mainWindow.btnBohrium.ToolTip = elements[106][0].ToString() + ":" + elements[106][1].ToString();
                mainWindow.btnHassium.ToolTip = elements[107][0].ToString() + ":" + elements[107][1].ToString();
                mainWindow.btnMeitnerium.ToolTip = elements[108][0].ToString() + ":" + elements[108][1].ToString();
                mainWindow.btnDarmstadtium.ToolTip = elements[109][0].ToString() + ":" + elements[109][1].ToString();
                mainWindow.btnRoentgenium.ToolTip = elements[110][0].ToString() + ":" + elements[110][1].ToString();
                mainWindow.btnCopernicium.ToolTip = elements[111][0].ToString() + ":" + elements[111][1].ToString();
                mainWindow.btnNihonium.ToolTip = elements[112][0].ToString() + ":" + elements[112][1].ToString();
                mainWindow.btnFlerovium.ToolTip = elements[113][0].ToString() + ":" + elements[113][1].ToString();
                mainWindow.btnMoscovium.ToolTip = elements[114][0].ToString() + ":" + elements[114][1].ToString();
                mainWindow.btnLivermorium.ToolTip = elements[115][0].ToString() + ":" + elements[115][1].ToString();
                mainWindow.btnTennessine.ToolTip = elements[116][0].ToString() + ":" + elements[116][1].ToString();
                mainWindow.btnOganesson.ToolTip = elements[117][0].ToString() + ":" + elements[117][1].ToString();
                mainWindow.btnLanthanum.ToolTip = elements[56][0].ToString() + ":" + elements[56][1].ToString();
                mainWindow.btnCerium.ToolTip = elements[57][0].ToString() + ":" + elements[57][1].ToString();
                mainWindow.btnPraseodymium.ToolTip = elements[58][0].ToString() + ":" + elements[58][1].ToString();
                mainWindow.btnNeodymium.ToolTip = elements[59][0].ToString() + ":" + elements[59][1].ToString();
                mainWindow.btnPromethium.ToolTip = elements[60][0].ToString() + ":" + elements[60][1].ToString();
                mainWindow.btnSamarium.ToolTip = elements[61][0].ToString() + ":" + elements[61][1].ToString();
                mainWindow.btnEuropium.ToolTip = elements[62][0].ToString() + ":" + elements[62][1].ToString();
                mainWindow.btnGadolinium.ToolTip = elements[63][0].ToString() + ":" + elements[63][1].ToString();
                mainWindow.btnTerbium.ToolTip = elements[64][0].ToString() + ":" + elements[64][1].ToString();
                mainWindow.btnDysprosium.ToolTip = elements[65][0].ToString() + ":" + elements[65][1].ToString();
                mainWindow.btnHolmium.ToolTip = elements[66][0].ToString() + ":" + elements[66][1].ToString();
                mainWindow.btnErbium.ToolTip = elements[67][0].ToString() + ":" + elements[67][1].ToString();
                mainWindow.btnThulium.ToolTip = elements[68][0].ToString() + ":" + elements[68][1].ToString();
                mainWindow.btnYtterbium.ToolTip = elements[69][0].ToString() + ":" + elements[69][1].ToString();
                mainWindow.btnLutetium.ToolTip = elements[70][0].ToString() + ":" + elements[70][1].ToString();
                mainWindow.btnActinium.ToolTip = elements[88][0].ToString() + ":" + elements[88][1].ToString();
                mainWindow.btnThorium.ToolTip = elements[89][0].ToString() + ":" + elements[89][1].ToString();
                mainWindow.btnProtactinium.ToolTip = elements[90][0].ToString() + ":" + elements[90][1].ToString();
                mainWindow.btnUranium.ToolTip = elements[91][0].ToString() + ":" + elements[91][1].ToString();
                mainWindow.btnNeptunium.ToolTip = elements[92][0].ToString() + ":" + elements[92][1].ToString();
                mainWindow.btnPlutonium.ToolTip = elements[93][0].ToString() + ":" + elements[93][1].ToString();
                mainWindow.btnAmericium.ToolTip = elements[94][0].ToString() + ":" + elements[94][1].ToString();
                mainWindow.btnCurium.ToolTip = elements[95][0].ToString() + ":" + elements[95][1].ToString();
                mainWindow.btnBerkelium.ToolTip = elements[96][0].ToString() + ":" + elements[96][1].ToString();
                mainWindow.btnCalifornium.ToolTip = elements[97][0].ToString() + ":" + elements[97][1].ToString();
                mainWindow.btnEinsteinium.ToolTip = elements[98][0].ToString() + ":" + elements[98][1].ToString();
                mainWindow.btnFermium.ToolTip = elements[99][0].ToString() + ":" + elements[99][1].ToString();
                mainWindow.btnMendelevium.ToolTip = elements[100][0].ToString() + ":" + elements[100][1].ToString();
                mainWindow.btnNobelium.ToolTip = elements[101][0].ToString() + ":" + elements[101][1].ToString();
                mainWindow.btnLawrencium.ToolTip = elements[102][0].ToString() + ":" + elements[102][1].ToString();

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

                mainWindow.periodicTable.Text = "Periodic Table";
                mainWindow.TotalAtomicMass.Text = "Total atomic mass";

                mainWindow.LanthanoidLabel.Content = "Lanthanoid";
                mainWindow.ActinoidLabel.Content = "Actinoid";

                mainWindow.btnHydrogen.ToolTip = elements[0][0].ToString() + "：" + elements[0][2].ToString();
                mainWindow.btnHelium.ToolTip = elements[1][0].ToString() + "：" + elements[1][2].ToString();
                mainWindow.btnLithium.ToolTip = elements[2][0].ToString() + "：" + elements[2][2].ToString();
                mainWindow.btnBeryllium.ToolTip = elements[3][0].ToString() + "：" + elements[3][2].ToString();
                mainWindow.btnBoron.ToolTip = elements[4][0].ToString() + "：" + elements[4][2].ToString();
                mainWindow.btnCarbon.ToolTip = elements[5][0].ToString() + "：" + elements[5][2].ToString();
                mainWindow.btnNitrogen.ToolTip = elements[6][0].ToString() + "：" + elements[6][2].ToString();
                mainWindow.btnOxygen.ToolTip = elements[7][0].ToString() + "：" + elements[7][2].ToString();
                mainWindow.btnFluorine.ToolTip = elements[8][0].ToString() + "：" + elements[8][2].ToString();
                mainWindow.btnNeon.ToolTip = elements[9][0].ToString() + "：" + elements[9][2].ToString();
                mainWindow.btnSodium.ToolTip = elements[10][0].ToString() + ":" + elements[10][2].ToString();
                mainWindow.btnMagnesium.ToolTip = elements[11][0].ToString() + ":" + elements[11][2].ToString();
                mainWindow.btnAluminium.ToolTip = elements[12][0].ToString() + ":" + elements[12][2].ToString();
                mainWindow.btnSilicon.ToolTip = elements[13][0].ToString() + ":" + elements[13][2].ToString();
                mainWindow.btnPhosphorus.ToolTip = elements[14][0].ToString() + ":" + elements[14][2].ToString();
                mainWindow.btnSulfur.ToolTip = elements[15][0].ToString() + ":" + elements[15][2].ToString();
                mainWindow.btnChlorine.ToolTip = elements[16][0].ToString() + ":" + elements[16][2].ToString();
                mainWindow.btnArgon.ToolTip = elements[17][0].ToString() + ":" + elements[17][2].ToString();
                mainWindow.btnPotassium.ToolTip = elements[18][0].ToString() + ":" + elements[18][2].ToString();
                mainWindow.btnCalcium.ToolTip = elements[19][0].ToString() + ":" + elements[19][2].ToString();
                mainWindow.btnScandium.ToolTip = elements[20][0].ToString() + ":" + elements[20][2].ToString();
                mainWindow.btnTitanium.ToolTip = elements[21][0].ToString() + ":" + elements[21][2].ToString();
                mainWindow.btnVanadium.ToolTip = elements[22][0].ToString() + ":" + elements[22][2].ToString();
                mainWindow.btnChromium.ToolTip = elements[23][0].ToString() + ":" + elements[23][2].ToString();
                mainWindow.btnManganese.ToolTip = elements[24][0].ToString() + ":" + elements[24][2].ToString();
                mainWindow.btnIron.ToolTip = elements[25][0].ToString() + ":" + elements[25][2].ToString();
                mainWindow.btnCobalt.ToolTip = elements[26][0].ToString() + ":" + elements[26][2].ToString();
                mainWindow.btnNickel.ToolTip = elements[27][0].ToString() + ":" + elements[27][2].ToString();
                mainWindow.btnCopper.ToolTip = elements[28][0].ToString() + ":" + elements[28][2].ToString();
                mainWindow.btnZinc.ToolTip = elements[29][0].ToString() + ":" + elements[29][2].ToString();
                mainWindow.btnGallium.ToolTip = elements[30][0].ToString() + ":" + elements[30][2].ToString();
                mainWindow.btnGermanium.ToolTip = elements[31][0].ToString() + ":" + elements[31][2].ToString();
                mainWindow.btnArsenic.ToolTip = elements[32][0].ToString() + ":" + elements[32][2].ToString();
                mainWindow.btnSelenium.ToolTip = elements[33][0].ToString() + ":" + elements[33][2].ToString();
                mainWindow.btnBromine.ToolTip = elements[34][0].ToString() + ":" + elements[34][2].ToString();
                mainWindow.btnKrypton.ToolTip = elements[35][0].ToString() + ":" + elements[35][2].ToString();
                mainWindow.btnRubidium.ToolTip = elements[36][0].ToString() + ":" + elements[36][2].ToString();
                mainWindow.btnStrontium.ToolTip = elements[37][0].ToString() + ":" + elements[37][2].ToString();
                mainWindow.btnYttrium.ToolTip = elements[38][0].ToString() + ":" + elements[38][2].ToString();
                mainWindow.btnZirconium.ToolTip = elements[39][0].ToString() + ":" + elements[39][2].ToString();
                mainWindow.btnNiobium.ToolTip = elements[40][0].ToString() + ":" + elements[40][2].ToString();
                mainWindow.btnMolybdenum.ToolTip = elements[41][0].ToString() + ":" + elements[41][2].ToString();
                mainWindow.btnTechnetium.ToolTip = elements[42][0].ToString() + ":" + elements[42][2].ToString();
                mainWindow.btnRuthenium.ToolTip = elements[43][0].ToString() + ":" + elements[43][2].ToString();
                mainWindow.btnRhodium.ToolTip = elements[44][0].ToString() + ":" + elements[44][2].ToString();
                mainWindow.btnPalladium.ToolTip = elements[45][0].ToString() + ":" + elements[45][2].ToString();
                mainWindow.btnSilver.ToolTip = elements[46][0].ToString() + ":" + elements[46][2].ToString();
                mainWindow.btnCadmium.ToolTip = elements[47][0].ToString() + ":" + elements[47][2].ToString();
                mainWindow.btnIndium.ToolTip = elements[48][0].ToString() + ":" + elements[48][2].ToString();
                mainWindow.btnTin.ToolTip = elements[49][0].ToString() + ":" + elements[49][2].ToString();
                mainWindow.btnAntimony.ToolTip = elements[50][0].ToString() + ":" + elements[50][2].ToString();
                mainWindow.btnTellurium.ToolTip = elements[51][0].ToString() + ":" + elements[51][2].ToString();
                mainWindow.btnIodine.ToolTip = elements[52][0].ToString() + ":" + elements[52][2].ToString();
                mainWindow.btnXenon.ToolTip = elements[53][0].ToString() + ":" + elements[53][2].ToString();
                mainWindow.btnCaesium.ToolTip = elements[54][0].ToString() + ":" + elements[54][2].ToString();
                mainWindow.btnBarium.ToolTip = elements[55][0].ToString() + ":" + elements[55][2].ToString();
                mainWindow.btnHafnium.ToolTip = elements[71][0].ToString() + ":" + elements[71][2].ToString();
                mainWindow.btnTantalum.ToolTip = elements[72][0].ToString() + ":" + elements[72][2].ToString();
                mainWindow.btnTungsten.ToolTip = elements[73][0].ToString() + ":" + elements[73][2].ToString();
                mainWindow.btnRhenium.ToolTip = elements[74][0].ToString() + ":" + elements[74][2].ToString();
                mainWindow.btnOsmium.ToolTip = elements[75][0].ToString() + ":" + elements[75][2].ToString();
                mainWindow.btnIridium.ToolTip = elements[76][0].ToString() + ":" + elements[76][2].ToString();
                mainWindow.btnPlatinum.ToolTip = elements[77][0].ToString() + ":" + elements[77][2].ToString();
                mainWindow.btnGold.ToolTip = elements[78][0].ToString() + ":" + elements[78][2].ToString();
                mainWindow.btnMercury.ToolTip = elements[79][0].ToString() + ":" + elements[79][2].ToString();
                mainWindow.btnThallium.ToolTip = elements[80][0].ToString() + ":" + elements[80][2].ToString();
                mainWindow.btnLead.ToolTip = elements[81][0].ToString() + ":" + elements[81][2].ToString();
                mainWindow.btnBismuth.ToolTip = elements[82][0].ToString() + ":" + elements[82][2].ToString();
                mainWindow.btnPolonium.ToolTip = elements[83][0].ToString() + ":" + elements[83][2].ToString();
                mainWindow.btnAstatine.ToolTip = elements[84][0].ToString() + ":" + elements[84][2].ToString();
                mainWindow.btnRadon.ToolTip = elements[85][0].ToString() + ":" + elements[85][2].ToString();
                mainWindow.btnFrancium.ToolTip = elements[86][0].ToString() + ":" + elements[86][2].ToString();
                mainWindow.btnRadium.ToolTip = elements[87][0].ToString() + ":" + elements[87][2].ToString();
                mainWindow.btnRutherfordium.ToolTip = elements[103][0].ToString() + ":" + elements[103][2].ToString();
                mainWindow.btnDubnium.ToolTip = elements[104][0].ToString() + ":" + elements[104][2].ToString();
                mainWindow.btnSeaborgium.ToolTip = elements[105][0].ToString() + ":" + elements[105][2].ToString();
                mainWindow.btnBohrium.ToolTip = elements[106][0].ToString() + ":" + elements[106][2].ToString();
                mainWindow.btnHassium.ToolTip = elements[107][0].ToString() + ":" + elements[107][2].ToString();
                mainWindow.btnMeitnerium.ToolTip = elements[108][0].ToString() + ":" + elements[108][2].ToString();
                mainWindow.btnDarmstadtium.ToolTip = elements[109][0].ToString() + ":" + elements[109][2].ToString();
                mainWindow.btnRoentgenium.ToolTip = elements[110][0].ToString() + ":" + elements[110][2].ToString();
                mainWindow.btnCopernicium.ToolTip = elements[111][0].ToString() + ":" + elements[111][2].ToString();
                mainWindow.btnNihonium.ToolTip = elements[112][0].ToString() + ":" + elements[112][2].ToString();
                mainWindow.btnFlerovium.ToolTip = elements[113][0].ToString() + ":" + elements[113][2].ToString();
                mainWindow.btnMoscovium.ToolTip = elements[114][0].ToString() + ":" + elements[114][2].ToString();
                mainWindow.btnLivermorium.ToolTip = elements[115][0].ToString() + ":" + elements[115][2].ToString();
                mainWindow.btnTennessine.ToolTip = elements[116][0].ToString() + ":" + elements[116][2].ToString();
                mainWindow.btnOganesson.ToolTip = elements[117][0].ToString() + ":" + elements[117][2].ToString();
                mainWindow.btnLanthanum.ToolTip = elements[56][0].ToString() + ":" + elements[56][2].ToString();
                mainWindow.btnCerium.ToolTip = elements[57][0].ToString() + ":" + elements[57][2].ToString();
                mainWindow.btnPraseodymium.ToolTip = elements[58][0].ToString() + ":" + elements[58][2].ToString();
                mainWindow.btnNeodymium.ToolTip = elements[59][0].ToString() + ":" + elements[59][2].ToString();
                mainWindow.btnPromethium.ToolTip = elements[60][0].ToString() + ":" + elements[60][2].ToString();
                mainWindow.btnSamarium.ToolTip = elements[61][0].ToString() + ":" + elements[61][2].ToString();
                mainWindow.btnEuropium.ToolTip = elements[62][0].ToString() + ":" + elements[62][2].ToString();
                mainWindow.btnGadolinium.ToolTip = elements[63][0].ToString() + ":" + elements[63][2].ToString();
                mainWindow.btnTerbium.ToolTip = elements[64][0].ToString() + ":" + elements[64][2].ToString();
                mainWindow.btnDysprosium.ToolTip = elements[65][0].ToString() + ":" + elements[65][2].ToString();
                mainWindow.btnHolmium.ToolTip = elements[66][0].ToString() + ":" + elements[66][2].ToString();
                mainWindow.btnErbium.ToolTip = elements[67][0].ToString() + ":" + elements[67][2].ToString();
                mainWindow.btnThulium.ToolTip = elements[68][0].ToString() + ":" + elements[68][2].ToString();
                mainWindow.btnYtterbium.ToolTip = elements[69][0].ToString() + ":" + elements[69][2].ToString();
                mainWindow.btnLutetium.ToolTip = elements[70][0].ToString() + ":" + elements[70][2].ToString();
                mainWindow.btnActinium.ToolTip = elements[88][0].ToString() + ":" + elements[88][2].ToString();
                mainWindow.btnThorium.ToolTip = elements[89][0].ToString() + ":" + elements[89][2].ToString();
                mainWindow.btnProtactinium.ToolTip = elements[90][0].ToString() + ":" + elements[90][2].ToString();
                mainWindow.btnUranium.ToolTip = elements[91][0].ToString() + ":" + elements[91][2].ToString();
                mainWindow.btnNeptunium.ToolTip = elements[92][0].ToString() + ":" + elements[92][2].ToString();
                mainWindow.btnPlutonium.ToolTip = elements[93][0].ToString() + ":" + elements[93][2].ToString();
                mainWindow.btnAmericium.ToolTip = elements[94][0].ToString() + ":" + elements[94][2].ToString();
                mainWindow.btnCurium.ToolTip = elements[95][0].ToString() + ":" + elements[95][2].ToString();
                mainWindow.btnBerkelium.ToolTip = elements[96][0].ToString() + ":" + elements[96][2].ToString();
                mainWindow.btnCalifornium.ToolTip = elements[97][0].ToString() + ":" + elements[97][2].ToString();
                mainWindow.btnEinsteinium.ToolTip = elements[98][0].ToString() + ":" + elements[98][2].ToString();
                mainWindow.btnFermium.ToolTip = elements[99][0].ToString() + ":" + elements[99][2].ToString();
                mainWindow.btnMendelevium.ToolTip = elements[100][0].ToString() + ":" + elements[100][2].ToString();
                mainWindow.btnNobelium.ToolTip = elements[101][0].ToString() + ":" + elements[101][2].ToString();
                mainWindow.btnLawrencium.ToolTip = elements[102][0].ToString() + ":" + elements[102][2].ToString();
            }
        }
    }
}
