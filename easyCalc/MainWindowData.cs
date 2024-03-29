using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCalc
{
    public class MainWindowData : ViewModelBase
    {
        // 画面上の計算履歴グリッドに表示するデータのコレクション
        private ObservableCollection<calcResult> result = new ObservableCollection<calcResult>();
        public ObservableCollection<calcResult> Result
        {
            get { return result; }
            set
            {
                ViewModelBase viewModelBase = new ViewModelBase();
                result = value;
                viewModelBase.RaisePropertyChanged();
            }
        }

        //DataGridに表示するデータクラス
        public class calcResult
        {
            // 計算式
            public string formula { get; set; }

            // 解
            public string result { get; set; }
        }

    }
}
