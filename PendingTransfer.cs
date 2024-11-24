using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMapp
{
    internal class PendingTransfer
    {
        public Guid TransferId { get; set; }
        public Guid SenderId { get; set; }
        public string SenderUsername { get; set; }
        public Guid RecipientId { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }

        public PendingTransfer(Guid transferId, Guid senderId, string senderUsername, Guid recipientId, double amount)
        {
            TransferId = transferId;
            SenderId = senderId;
            SenderUsername = senderUsername;
            RecipientId = recipientId;
            Amount = amount;
            DateTime = DateTime.Now;
        }
    }
}
