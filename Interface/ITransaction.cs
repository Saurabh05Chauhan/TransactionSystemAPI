using TransactionSystemAPI.DTO;
using TransactionSystemAPI.Model;

namespace TransactionSystemAPI.Interface
{
    public interface ITransaction
    {
        Task<TransactionModel> CreateAsync(TransactionModel transaction);
        Task<IEnumerable<TransactionModel>> GetTransactions();
        //Task<TransactionModel> CreateAsync(TransactionDTO transaction);
    }
}
