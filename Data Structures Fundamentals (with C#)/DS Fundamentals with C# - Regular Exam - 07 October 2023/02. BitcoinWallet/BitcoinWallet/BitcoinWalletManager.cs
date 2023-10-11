using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        Dictionary<string, User> Users = new Dictionary<string, User>();
        Dictionary<string, Wallet> Wallets = new Dictionary<string, Wallet>();
        Dictionary<string, Transaction> Transactions = new Dictionary<string, Transaction>();

        Dictionary<string, int> UserTransactionsCount = new Dictionary<string, int>();

        public void CreateUser(User user)
        {
            Users.Add(user.Id, user);
            UserTransactionsCount.Add(user.Id, 0);
        }

        public void CreateWallet(Wallet wallet)
        {
            Wallets.Add(wallet.Id, wallet);
        }

        public bool ContainsUser(User user)
        {
            return Users.ContainsKey(user.Id);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return Wallets.ContainsKey(wallet.Id);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return Wallets.Values
                .Where(w => w.UserId == userId);
        }

        public void PerformTransaction(Transaction transaction)
        {
            var SenderWallet = Wallets.Values.FirstOrDefault(w => w.Id == transaction.SenderWalletId);
            var ReceiverWallet = Wallets.Values.FirstOrDefault(w => w.Id == transaction.ReceiverWalletId);

            if (SenderWallet == null || ReceiverWallet == null || SenderWallet.Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            SenderWallet.Balance -= transaction.Amount;
            ReceiverWallet.Balance += transaction.Amount;

            UserTransactionsCount[GetUserByWalletId(transaction.ReceiverWalletId).Id]++;
            UserTransactionsCount[GetUserByWalletId(transaction.SenderWalletId).Id]++;

            Transactions.Add(transaction.Id, transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            return Transactions.Values
                .Where(t => Wallets.Values.Any(w => w.UserId == userId && (w.Id == t.SenderWalletId || w.Id == t.ReceiverWalletId)));
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {
            return Wallets.Values
                .OrderByDescending(w => w.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            return Users.Values
                .OrderByDescending(u => GetTotalBalance(u.Id));
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            return UserTransactionsCount
                .OrderByDescending(utc => utc.Value)
                .Select(utc => Users[utc.Key]);
        }

        private User GetUserByWalletId(string id)
        {
            return Users.Values
                .FirstOrDefault(u => Wallets[id].UserId == u.Id);
        }

        private long GetTotalBalance(string userId)
        {
            return Wallets.Values
                .Where(w => w.UserId == userId)
                .Sum(w => w.Balance);
        }
    }
}