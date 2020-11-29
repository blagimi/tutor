using System;

namespace InterfaceT
{
    interface IUser<T>
    {
        T Id { get; }
    }
}
