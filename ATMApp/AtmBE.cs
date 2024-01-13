using AtmApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    public class AtmBE
    {
        Program atmApp = new Program();

        public bool login(string cardNo, string password)
        {
            foreach (var bankAcc in atmApp.bankAccounts)
            {
                if(!bankAcc.CardNo.Equals(cardNo)) { 
                    Console.WriteLine("The card no " + cardNo + "doesn't exist in the system");
                    return false;
                }
                if (bankAcc.CardNo.Equals(cardNo) && bankAcc.Password.Equals(password))
                {
                    Console.WriteLine("Hi! " + bankAcc.Name);
                    return true;
                }
            }
            return false;
        }

        public List<BankAccount> getListAccByCardNo(string cardNo)
        {
            List<BankAccount> listAccByCardNo = new List<BankAccount>();
            foreach (var bankAcc in atmApp.bankAccounts)
            {
                if (bankAcc.CardNo.Equals(cardNo))
                {
                    listAccByCardNo.Add(bankAcc);
                }
            }
            return listAccByCardNo.Count == 0 ? null : listAccByCardNo;
        }
    }
}
