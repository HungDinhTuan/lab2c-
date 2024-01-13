using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    public class BankAccount
    {
        private string name;
        private string cardNo;
        private string password;
        private double amount;
        private DateTime dateTrans;
        private static readonly double MIN_BLANCE = 50000;
        private static readonly double FEE_WITHDRAW = 0.00067;

        public BankAccount() { }

        public BankAccount(string name, string cardNo, string password, double amount, DateTime dateTrans)
        {
            this.name = name;
            this.cardNo = cardNo;
            this.password = password;
            this.amount = amount;
            this.dateTrans = dateTrans;
        }

        public string Name
        {
            get { return name; }
            set { name = value;}
        }

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value;}
        }

        public DateTime DateTrans
        {
            get { return dateTrans; }
            set { dateTrans = value; }
        }

        public void OutputInfoTrans()
        {
            Console.WriteLine("The account name               : " + Name);
            Console.WriteLine("The card no                    : " + CardNo);
            Console.WriteLine("The amount                     : " + Amount);
            Console.WriteLine("The date time transaction      : " + DateTrans);
        }

        public double Deposit(double depositNum)
        {
            return Amount;
        }

        public double Wihdraw(double withdrawNum)
        {
            return Amount;
        }
    }
}
