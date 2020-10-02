﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Banking
{
    class Account
    {
        private static int NextId = 1;
        public int Id { get; private set; }
        public double Balance { get; private set; }  = 0;
        public string Description { get; set; }

        public static bool Transfer(double amount, Account FromAccount, Account ToAccount)
        {
            if (amount <= 0)
            {
                return false;
            }
            if(FromAccount == null || ToAccount == null)
            {
                return false;
            }
            var BeforeBalance = FromAccount.Balance;
            var AfterBalance = FromAccount.Withdraw(amount);
            if (BeforeBalance != AfterBalance + amount)
            {
                return false;

            }
            ToAccount.Deposit(amount);
            return true;
        }

        private bool CheckAmountGreaterThanZero(double amount)
        {
            if (amount <= 0)
            {
                //Console.WriteLine("Amount must be GT zero");
                throw new Exception("Amount must be GT zero");
                //return false;
            }
            return true;

        }

        public double Deposit(double amount)
        {
            if(!CheckAmountGreaterThanZero(amount))
            {
                Console.WriteLine("Amount must be GT zero");
                return Balance;
            }

            Balance = Balance + amount;
            return Balance;
        }
        public double Withdraw(double amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Amount must be GT zero");
                return Balance;
            }
            // Balance = Balance + amount
            Console.WriteLine("Insufficient Funds!)");
            return Balance;
        }
           
        
        public void Print()
        {
            Console.WriteLine($"Id[{Id}, Desc[{Description}], Bal[{Balance}]");
        }
        public Account(string description) {
            this.Id = NextId++;
            this.Description = description;
        
        }
        public Account(): this("New Account") {
            this.Description = "Default account";
       

        }
    }
}

