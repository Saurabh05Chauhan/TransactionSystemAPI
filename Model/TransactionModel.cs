﻿namespace TransactionSystemAPI.Model
{
    public class TransactionModel
    {
        public Guid id { get; set; }    
        public DateTime Date { get; set; }
        public string Description  { get; set; }
        public int  Credit { get; set; }
        public int  Debit { get; set; }
        public int  RunningBalance { get; set; }
    }
}
