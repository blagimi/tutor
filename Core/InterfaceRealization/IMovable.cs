using System;

namespace InterfaceRealization
{
    interface IMovable
    {
        protected internal void Move();
        protected internal string Name { get; set; }
        delegate void MoveHandler();
        protected internal event MoveHandler MoveEvent;
    }
}
