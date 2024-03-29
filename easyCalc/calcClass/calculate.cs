using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easyCalc.calcClass
{
    class calculate
    {
        /// <summary>
        /// 立方根以上を計算するメソッド
        /// </summary>
        /// <param name="powerNumber"></param>
        /// <param name="formula"></param>
        /// <returns></returns>
        public double rootCalc(double powerNumber,double formula)
        {
            if (formula >= 0)
            {
                // 通常のn乗根 
                return Math.Pow(formula, 1.0 / powerNumber);
            }
            else
            {
                if ((powerNumber % 2) != 0)
                {
                    // 奇数乗根の場合 
                    return -Math.Pow(-formula, 1.0 / powerNumber);
                }
                else
                {
                    // 偶数乗根の場合 
                    return double.NaN;
                }
            }
        }
    }
}
