﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp
{
    internal class ManagerialTransactionRepository : IManagerialTransactionRepository
    {
        private List<TransactionInfo> _managerialTransactions = new List<TransactionInfo>();

        private static readonly HashSet<string> ManagerialTransactionTypes = new HashSet<string>
        {
            "User Creation",
            "User Deletion",
            "User Info Update",
            "Password Change",
            "Email Update",
            "Login",
            "Logout"
        };

        public void AddTransaction(TransactionInfo transaction)
        {
            if (ManagerialTransactionTypes.Contains(transaction.TransactionName))
            {
                _managerialTransactions.Add(transaction);
            }
        }

        public IEnumerable<TransactionInfo> GetTransactionsByUserId(Guid userId)
        {
            return _managerialTransactions.Where(t => t.UserId == userId).ToList();
        }
        public void DeleteTransaction(Guid transactionId)
        {
            var transaction = _managerialTransactions.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction != null)
            {
                _managerialTransactions.Remove(transaction);
            }
        }
    }
}