using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMoreOOP
{
    public class Active : IAccountState
    {
        public Action OnUnfreeze { get; set; }

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }


        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Freeze() => new Frozen(this.OnUnfreeze);

        public IAccountState HolderVerified() => this;
    }
}
