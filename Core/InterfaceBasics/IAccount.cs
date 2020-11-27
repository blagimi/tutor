using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceBasics
{
    interface IAccount
    {
        int CurrentSum { get; } //  Текущая сумма по счёту
        void Put(int sum);      //  Положить деньги на счёт
        void Withdraw(int sum); //  Снять со счёта
    }
}
