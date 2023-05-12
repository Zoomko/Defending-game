using ModestTree.Util;
using System;

namespace Assets.CodeBase.Player
{
    public interface IDamagable
    {
        void GetDamage(int value);
        event Action<int, int, int> HealthChanged;
    }
}