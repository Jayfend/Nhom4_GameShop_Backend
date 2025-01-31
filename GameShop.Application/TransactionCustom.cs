﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace GameShop.Application
{
    public interface ITransactionCustom
    {
        TransactionScope CreateTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);
    }


    public class TransactionCustom : ITransactionCustom
    {
        public TransactionScope CreateTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = isolationLevel

                },
                TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
