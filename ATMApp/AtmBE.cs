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
            for (int i = 0; i < atmApp.bankAccounts.Count; i++)
            {
                if (!atmApp.bankAccounts[i].CardNo.Equals(cardNo))
                {
                    Console.WriteLine("The card no : " + cardNo + " doesn't exist in the system.");
                    return false;
                }
                if (atmApp.bankAccounts[i].CardNo.Equals(cardNo) && atmApp.bankAccounts[i].Password.Equals(password))
                {
                    Console.WriteLine("Hi! " + atmApp.bankAccounts[i].Name);
                    return true;
                }
            }
            Console.WriteLine("The card no : " + cardNo + " failed to sign.");
            return false;
        }

        public List<BankAccount> getListAccByCardNo(string cardNo)
        {
            List<BankAccount> listAccByCardNo = new List<BankAccount>();
            for (int i = 0; i < atmApp.bankAccounts.Count; i++)
            {
                if (atmApp.bankAccounts[i].CardNo.Equals(cardNo))
                {
                    listAccByCardNo.Add(atmApp.bankAccounts[i]);
                }
            }
            return listAccByCardNo.Count == 0 ? null : listAccByCardNo;
        }
    }
}
