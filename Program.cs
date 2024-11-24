using System;

namespace ATMapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();
            ITransactionRepository transactionRepository = new Transaction();
          

            ATM atm = new ATM(userRepository, transactionRepository);
            atm.Start();
        }
    }
}
