using ATMApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AtmApp
{
    public class Program
    {
        private static readonly double MIN_BLANCE = 50000;
        private static readonly string URL_FILE = "./etc/trans_account_table.txt";
        public static FileService fileService = new FileService();
        public List<BankAccount> bankAccounts = fileService.readFile(URL_FILE);

        private static void Main(string[] args)
        {
            AtmBE atmBE = new AtmBE();
            BankAccountValid baValid = new BankAccountValid();
            BankAccount newBATrans = null;

            Console.WriteLine("Enter the card number : ");
            string cardNo = Console.ReadLine();

            if (!baValid.validCardNums(cardNo))
            {
                Console.WriteLine("The card no : " + cardNo + " is the wrong fomat.");
            }

            Console.WriteLine("Enter the password : ");
            string password = Console.ReadLine();

            if (password == null)
            {
                Console.WriteLine("The password isn't epmty");
            }

            if (!atmBE.login(cardNo, password))
            {
                int lastTrans = atmBE.getListAccByCardNo(cardNo).Count;
                Console.WriteLine("|=========================================MENU=========================================|");
                Console.WriteLine("| 1. Withdraw money.                                                                   |");
                Console.WriteLine("| 2. Deposit money .                                                                   |");
                Console.WriteLine("| 0. Exit app.                                                                         |");
                Console.WriteLine("|======================================================================================|");
                Console.WriteLine("Please choose the right function : ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            double withdraw;
                            Console.WriteLine("=========================================WITHDRAW======================================|");
                            Console.WriteLine("| 1. 500000 VNĐ.                                                                       |");
                            Console.WriteLine("| 2. 1000000 VNĐ.                                                                      |");
                            Console.WriteLine("| 3. 1500000 VNĐ.                                                                      |");
                            Console.WriteLine("| 4. 2000000 VNĐ.                                                                      |");
                            Console.WriteLine("| 5. Enter the amount you would like to withdraw.                                      |");
                            Console.WriteLine("| 0. Exit app.                                                                         |");
                            Console.WriteLine("|======================================================================================|");
                            Console.WriteLine("Please choose the right function : ");
                            int choice1 = int.Parse(Console.ReadLine());
                            newBATrans = new BankAccount
                            {
                                Name = atmBE.getListAccByCardNo(cardNo)[lastTrans].Name,
                                CardNo = atmBE.getListAccByCardNo(cardNo)[lastTrans].CardNo,
                                Password = atmBE.getListAccByCardNo(cardNo)[lastTrans].Password,
                                Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].Amount,
                                DateTrans = DateTime.Now
                            };
                            switch (choice1)
                            {
                                case 1:
                                    withdraw = 500000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(withdraw),
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 2:
                                    withdraw = 1000000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(withdraw)
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 3:
                                    withdraw = 15000000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(withdraw),
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 4:
                                    withdraw = 2000000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(withdraw),
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 5:
                                    withdraw = double.Parse(Console.ReadLine());
                                    if (withdraw % MIN_BLANCE == 0)
                                    {
                                        newBATrans = new BankAccount
                                        {
                                            Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(withdraw),
                                        };
                                        newBATrans.OutputInfoTrans();
                                        fileService.insertToFile(newBATrans, URL_FILE);
                                    }
                                    else
                                    {
                                        Console.WriteLine("The amount you want to withdraw must be a multiple of 50000 VNĐ.");
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("See you again!");
                                    break;
                                default:
                                    Console.WriteLine("Please choose right function!");
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            double deposit;
                            Console.WriteLine("|=========================================DEPOSIT======================================|");
                            Console.WriteLine("| 1. 500000 VNĐ.                                                                       |");
                            Console.WriteLine("| 2. 1000000 VNĐ.                                                                      |");
                            Console.WriteLine("| 3. 1500000 VNĐ.                                                                      |");
                            Console.WriteLine("| 4. 2000000 VNĐ.                                                                      |");
                            Console.WriteLine("| 5. Enter the amount you would like to deposit.                                       |");
                            Console.WriteLine("| 0. Exit app.                                                                         |");
                            Console.WriteLine("|======================================================================================|");
                            Console.WriteLine("Please choose the right function : ");
                            int choice1 = int.Parse(Console.ReadLine());
                            switch (choice1)
                            {
                                case 1:
                                    deposit = 500000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].deposit(deposit)
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 2:
                                    deposit = 1000000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].deposit(deposit)
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 3:
                                    deposit = 15000000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(deposit)
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 4:
                                    deposit = 2000000;
                                    newBATrans = new BankAccount
                                    {
                                        Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].withdraw(deposit)
                                    };
                                    newBATrans.OutputInfoTrans();
                                    fileService.insertToFile(newBATrans, URL_FILE);
                                    break;
                                case 5:
                                    deposit = double.Parse(Console.ReadLine());
                                    if (deposit % MIN_BLANCE == 0)
                                    {
                                        newBATrans = new BankAccount
                                        {
                                            Amount = atmBE.getListAccByCardNo(cardNo)[lastTrans].deposit(deposit)
                                        };
                                        newBATrans.OutputInfoTrans();
                                        fileService.insertToFile(newBATrans, URL_FILE);
                                    }
                                    else
                                    {
                                        Console.WriteLine("The amount you want to withdraw must be a multiple of 50000 VNĐ.");
                                    }
                                    break;
                                case 0:
                                    Console.WriteLine("See you again!");
                                    break;
                                default:
                                    Console.WriteLine("Please choose right function!");
                                    break;
                            }
                            break;
                        }
                    case 0:
                        Console.WriteLine("See you again!");
                        break;
                    default:
                        Console.WriteLine("Please choose right function!");
                        break;
                }
            }
        }
    }
}