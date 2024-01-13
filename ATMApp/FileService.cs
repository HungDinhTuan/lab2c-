using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp
{
    public class FileService
    {
        private static readonly string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private static readonly string HEADER = "Name|Card_no|Password|Amount|Trans_date_time";

        public BankAccount convert(string line)
        {
            if (line == null || line.Trim().Equals(HEADER)) return null;
            if (string.IsNullOrEmpty(line)) return null;
            string[] chars = line.Split('|');
            DateTime dateTrans = DateTime.ParseExact(chars[4], DATE_TIME_FORMAT, null);
            BankAccount bankAccount = new BankAccount
            {
                Name = chars[0],
                CardNo = chars[1],
                Password = chars[2],
                Amount = double.Parse(chars[3]),
                DateTrans = dateTrans
            };
            return bankAccount;
        }

        public void insertToFile(BankAccount bankAccount, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(bankAccount.Name).Append("|")
                        .Append(bankAccount.CardNo).Append("|")
                        .Append(bankAccount.Password).Append("|")
                        .Append(bankAccount.Amount).Append("|")
                        .Append(bankAccount.DateTrans.ToString(DATE_TIME_FORMAT));
                    writer.WriteLine(sb.ToString());
                    Console.WriteLine("Insert file success in : " + fileName);
                }
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<BankAccount> readFile(string url)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();
            try
            {
                using (StreamReader reader = new StreamReader(url))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        BankAccount bankAccount = convert(line);
                        if (bankAccount != null)
                        {
                            bankAccounts.Add(bankAccount);
                        }
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Error reading file : " + e.Message);
                return null;
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error parsing date time : " + e.Message);
                return null;
            }
            return bankAccounts.Count == 0 ? null : bankAccounts;
        }
    }
}
