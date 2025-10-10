using System;

namespace ShootEmUp
{
    public interface IInput
    {
        event Action<int> RightLeftMovement;
        event Action Fire;
    }
}