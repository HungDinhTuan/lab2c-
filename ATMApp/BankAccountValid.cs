using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATMApp
{
    public class BankAccountValid
    {
        public bool validCardNums(string cardNo)
        {
            Regex regex = new Regex("\\d{12}");
            Match match = regex.Match(cardNo);
            return match.Success;
        }
    }
}
