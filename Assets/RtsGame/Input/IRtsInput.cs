using System;
using RtsGame.Units;

namespace RtsGame.Input
{
    public interface IRtsInput
    {
        event Action<Unit> ActionOnUnit;
        event Action<Unit> SelectOnUnit;
    }
}
