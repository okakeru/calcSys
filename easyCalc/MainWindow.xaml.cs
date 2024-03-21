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
    }
}
