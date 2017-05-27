using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMoreOOP
{
    public interface IAccountState
    {
        IAccountState Deposit(Action amountTobeDeposited);
        IAccountState Withdraw(Action amountTobeWithdrawed);
        IAccountState Freeze();
        IAccountState HolderVerified();
        IAccountState Close();
    }
}
