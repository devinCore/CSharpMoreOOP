using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMoreOOP
{
    public class Closed : IAccountState
    {
        public IAccountState Close() => this;
        public IAccountState Deposit(Action depositAmount) => this;
        public IAccountState Freeze() => this;
        public IAccountState HolderVerified() => this;
        public IAccountState Withdraw(Action withdrawAmount) => this;
    }
}
