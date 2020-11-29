using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceT
{
    interface IAccount
    {
        int CurrentSum { get;}
        void Put(int sum);
        void Withdraw(int sum);
    }
}
