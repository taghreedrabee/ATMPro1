using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATMapp
{
    internal class FinancialTransactionRepository : IFinancialTransactionRepository
    {
        private List<TransactionInfo> _financialTransactions = new List<TransactionInfo>();

        private static readonly HashSet<string> FinancialTransactionTypes = new HashSet<string>
            {
                "Deposit",
                "Withdrawal",
                "Balance Check",
                "Transfer (Sent)",
                "Transfer (Received)",
                "Transfer (Sent - Pending)",
                "Transfer Cancelled - User Deletion",
                "Transfer Returned - Recipient Deleted",
                "Transfer (Refunded)",
                "Transfer Accepted",
                "Transfer Rejected"
            };

        public void AddTransaction(TransactionInfo transaction)
        {
            if (FinancialTransactionTypes.Contains(transaction.TransactionName))
            {
                _financialTransactions.Add(transaction);
            }
        }

        public IEnumerable<TransactionInfo> GetTransactionsByUserId(Guid userId)
        {
            return _financialTransactions.Where(t => t.UserId == userId).ToList();
        }
        public void DeleteTransaction(Guid transactionId)
        {
            var transaction = _financialTransactions.FirstOrDefault(t => t.TransactionId == transactionId);
            if (transaction != null)
            {
                _financialTransactions.Remove(transaction);
            }
        }
    }


}
