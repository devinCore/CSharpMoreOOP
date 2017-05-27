using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMoreOOP
{
    class Frozen : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action amountTobeDeposited)
        {
            this.OnUnfreeze();
            amountTobeDeposited();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Withdraw(Action amountTobeWithdrawed)
        {
            this.OnUnfreeze();
            amountTobeWithdrawed();
            return new Active(this.OnUnfreeze);
        }

        public IAccountState Freeze()
        {
            throw new NotImplementedException();
        }

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }

        public IAccountState HolderVerified()
        {
            throw new NotImplementedException();
        }
    }
}
