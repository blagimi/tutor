using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceKovaKontrAndInvariativnost
{
    interface IBank<out T>
    {
        T CreateAccount(int sum);
    }
}
