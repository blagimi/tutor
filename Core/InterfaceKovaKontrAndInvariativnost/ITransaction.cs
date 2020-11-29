using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceKovaKontrAndInvariativnost
{
    interface ITransaction<in T>
    {
        void DoOperation(T account, int sum);
    }
}
