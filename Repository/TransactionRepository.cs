using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TransactionSystemAPI.Data;
using TransactionSystemAPI.DTO;
using TransactionSystemAPI.Interface;
using TransactionSystemAPI.Model;

namespace TransactionSystemAPI.Repository
{
    public class TransactionRepository : ITransaction
    {
        private readonly ApplicationDBContext dBContext;

        public TransactionRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<TransactionModel> CreateAsync(TransactionModel transaction)
        {
            var existing = dBContext.transactions.OrderByDescending(x=>x.Date).FirstOrDefault();
            if (existing != null)
            {
                if (transaction.Credit != 0)
                {
                    transaction.RunningBalance = transaction.Credit+existing.RunningBalance;

                }
                else
                {
                    transaction.RunningBalance = existing.RunningBalance- transaction.Debit;
                }
            }
            else
            {
                transaction.RunningBalance = transaction.Credit;
            }
            await this.dBContext.transactions.AddAsync(transaction);
            await this.dBContext.SaveChangesAsync();
            return transaction;
        }


        public async Task<IEnumerable<TransactionModel>> GetTransactions()
        {
            return await this.dBContext.transactions.OrderByDescending(x => x.Date).ToListAsync();
        }
    }
}
