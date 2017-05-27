using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMoreOOP
{
    class Account
    {
        public decimal Balance { get; private set; }

        private IAccountState State { get; set; }

        public Action OnUnfreeze { get; }

        public Account(Action onUnfreeze)
        {
            this.State = new NotVerified(onUnfreeze);
        }

        public void Desposit(decimal amount)
        {
            this.State = this.State.Deposit(() => { this.Balance += amount; });
        }

        public void Withdraw(decimal amount)
        {
            this.State = this.State.Deposit(() => { this.Balance -= amount; });
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();          
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerified();
        }

        public void Close()
        {
            this.State = this.State.Close();
        }

   

    }
}
